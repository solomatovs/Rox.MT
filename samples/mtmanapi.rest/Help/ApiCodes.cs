using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace rox.mt4.rest
{
    public enum ApiStatusCode
    {
        success = 0,
        error = 1,
        warning = 2
    }

    /// <summary>
    /// Фабрика для создания сообщений об ошибке
    /// </summary>
    public interface IErrorFactory
    {
        IResponseError AddError(IResponseError response, Exception e);
    }

    /// <summary>
    /// Базовый класс фабрики создания ошибки
    /// </summary>
    public class ApiErrorFactory : IErrorFactory
    {
        public IResponseError AddError(IResponseError response, Exception e)
        {
            return VAddError(response, e);
        }

        /// <summary>
        /// Здесь создаем конкретное сообщение об ошибке
        /// </summary>
        /// <returns></returns>
        protected virtual IResponseError VAddError(IResponseError response, Exception e)
        {
            response.Errors.Add(new ApiError()
            {
                Message = e.Message,
                // MoreInformation = e.HelpLink
            });

            return response;
        }
    }

    public class ApiExeptionFilterOption
    {
        public List<Type> ErrorFactories { get; set; } = new List<Type>();
    }

    public class ApiExeptionFilter : ExceptionFilterAttribute
    {
        private readonly IServiceProvider provider;
        private readonly ILogger logger;
        private readonly ApiExeptionFilterOption options;

        public ApiExeptionFilter(IServiceProvider provider, IOptions<ApiExeptionFilterOption> options, ILoggerFactory loggerFactory)
        {
            this.provider = provider;
            this.options = options.Value;
            logger = loggerFactory.CreateLogger<ApiExeptionFilter>();
        }

        private IErrorFactory GetErrorFactory(Type type)
        {
            return provider?.GetService(type) as IErrorFactory;
        }

        private IEnumerable<IErrorFactory> GetErrorFactories()
        {
            foreach (var option in options.ErrorFactories)
            {
                yield return GetErrorFactory(option);
            }
        }

        public override void OnException(ExceptionContext context)
        {
            var exeption = context.Exception;
            if (exeption != null)
            {
                logger.LogDebug($"MT4Exception: {exeption.Message}");

                context.ExceptionHandled = false;

                var response = new ApiResponseError();
                foreach (var factory in GetErrorFactories())
                {
                    factory?.AddError(response, exeption);
                }

                context.Result = new BadRequestObjectResult(response);
            }

            base.OnException(context);
        }
    }


    public static class ApiControllerServiceCollectionExtensions
        {
            public static IMvcBuilder AddApiFilters(
                this IMvcBuilder mvcBuilder,
                Action<ApiExeptionFilterOption> action = null)
            {
                var options = new ApiExeptionFilterOption();
                action?.Invoke(options);

                if (options?.ErrorFactories.Count < 1)
                {
                    var defaultErrorFactory = typeof(ApiErrorFactory);
                    mvcBuilder.Services.Configure<ApiExeptionFilterOption>(o => o.ErrorFactories.Add(defaultErrorFactory));
                    options.ErrorFactories.Add(defaultErrorFactory);
                }
                else
                {
                    mvcBuilder.Services.Configure(action);
                }

                foreach (var factory in options?.ErrorFactories)
                {
                    mvcBuilder.Services.AddTransient(factory);
                }

                mvcBuilder.Services
                    .AddTransient<ApiExeptionFilter>()
                    .AddTransient<ApiResultFilter>();

                mvcBuilder.AddMvcOptions(o =>
                {
                    o.Filters.Add(typeof(ApiResultFilter));
                    o.Filters.Add(typeof(ApiExeptionFilter));
                });

                return mvcBuilder;
            }
        }

    /// <summary>
    /// 
    /// </summary>
    public interface IResponse
    {
        // ApiStatusCode status { get; set; }
    }

    /// <summary>
    /// Базовый ответ от REST API
    /// </summary>
    public class ApiResponse : IResponse
    {
        // public ApiStatusCode status { get; set; }
    }

    /// <summary>
    /// Ответ в случае полностью успешной операции
    /// Возвращаются данные от сервера
    /// </summary>
    public interface IResponseSuccess
    {
        // dynamic result { get; set; }
    }

    /// <summary>
    /// Ответ в случае полностью успешной операции
    /// Возвращаются данные от сервера
    /// </summary>
    public class ApiResponseSuccess : ApiResponse, IResponseSuccess
    {
        public ApiResponseSuccess()
        {
            // this.status = ApiStatusCode.success;
        }

        // public dynamic result { get; set; }
    }

    /// <summary>
    /// Формат сообщения об ошибке
    /// </summary>
    public interface IError
    {
        /// <summary>
        /// Сообщение для пользователя, которое может показать Front End, если захочет
        /// </summary>
        string Message { get; set; }
        ///// <summary>
        ///// Ссылка или другая дополнительная информация, которая позволит администратору или девелоперу решить проблему
        ///// </summary>
        //string MoreInformation { get; set; }
    }

    /// <summary>
    /// Формат ошибки, которая могла произойти во время обработки запроса
    /// </summary>
    public class ApiError : IError
    {
        /// <summary>
        /// Сообщение для пользователя, которое может показать Front End, если захочет
        /// </summary>
        public string Message { get; set; }
        ///// <summary>
        ///// Ссылка или другая дополнительная информация, которая позволит администратору или девелоперу решить проблему
        ///// </summary>
        //public string MoreInformation { get; set; }
    }

    /// <summary>
    /// Интерфейс сообщения об ошибке
    /// </summary>
    public interface IResponseError
    {
        IList<IError> Errors { get; set; }
    }

    /// <summary>
    /// Ответ в случае неуспешной операции
    /// </summary>
    public class ApiResponseError : ApiResponse, IResponseError
    {
        public ApiResponseError()
        {
            // this.status = ApiStatusCode.error;
        }

        public IList<IError> Errors { get; set; } = new List<IError>();
    }

    /// <summary>
    /// Дополнительная информация об ошибке
    /// </summary>
    public interface IAdditionalError : IError
    {
        dynamic AdditionalInformation { get; set; }
    }

    /// <summary>
    /// Реализует функционал дополнительной информции об ошибках
    /// </summary>
    public class ApiAdditionalError : ApiError, IAdditionalError
    {
        public dynamic AdditionalInformation { get; set; }
    }

    public class ApiResultFilter : IResultFilter
    {
        private readonly ILogger logger;

        public ApiResultFilter(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<ApiResultFilter>();
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            var reultObject = context.Result as ObjectResult;
            if (reultObject != null)
            {
                if (reultObject.Value is ApiResponseError)
                {
                    return;
                }

                context.Result = new OkObjectResult(reultObject.Value);
                return;
            }
            else
            {
                context.Result = new OkResult();
                return;
            }
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            logger.LogInformation("OnResultExecuted");
        }
    }

    internal class ContractResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            return base.CreateProperties(type, memberSerialization).Where(p => p.PropertyName != "native").ToList();
        }
    }
}
