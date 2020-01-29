using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Reflection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.Linq.Expressions;

namespace rox.mt4.rest
{
    using rox.mt4.api;

    public class MT4ComplexTypeModelBinderProvider : IModelBinderProvider
    {
        protected virtual IModelBinder GetBinder(
            ModelBinderProviderContext context,
            IDictionary<ModelMetadata, IModelBinder> propertyBinders,
            ILoggerFactory loggerFactory,
            bool allowValidatingTopLevelNodes)
        {
            return new MT4ComplexTypeModelBinder(
                propertyBinders,
                loggerFactory,
                allowValidatingTopLevelNodes);
        }

        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var isAssignableMT4Model = context.Metadata.ModelType.IsAssignableToGenericType(typeof(MT4Model<>));
            if (context.Metadata.IsComplexType && !context.Metadata.IsCollectionType && isAssignableMT4Model)
            {
                var propertyBinders = new Dictionary<ModelMetadata, IModelBinder>();
                for (var i = 0; i < context.Metadata.Properties.Count; i++)
                {
                    var property = context.Metadata.Properties[i];
                    propertyBinders.Add(property, context.CreateBinder(property));
                }

                var loggerFactory = context.Services.GetRequiredService<ILoggerFactory>();
                var mvcOptions = context.Services.GetRequiredService<IOptions<MvcOptions>>().Value;
                return GetBinder(
                    context,
                    propertyBinders,
                    loggerFactory,
                    /*mvcOptions.AllowValidatingTopLevelNodes*/true);
            }

            return null;
        }
    }
    public static class TypeExtensions
    {
        public static bool IsAssignableToGenericType(this Type givenType, Type genericType)
        {
            var interfaceTypes = givenType.GetInterfaces();

            foreach (var it in interfaceTypes)
            {
                if (it.IsGenericType && it.GetGenericTypeDefinition() == genericType)
                    return true;
            }

            if (givenType.IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
                return true;

            Type baseType = givenType.BaseType;
            if (baseType == null) return false;

            return IsAssignableToGenericType(baseType, genericType);
        }

        internal static int CodePage(this ModelBindingContext bindingContext)
        {
            var codePageValue = bindingContext.ValueProvider.GetValue("CodePage");
            int codePage = 0;
            if (codePageValue != ValueProviderResult.None)
            {
                var codePageString = codePageValue.FirstValue;
                if (!int.TryParse(codePageString, out codePage))
                {
                    codePage = 0;
                }
            }

            return codePage;
        }


        internal static string GetParameterValue(this ModelBindingContext bindingContext, string key)
        {
            var value = bindingContext.ValueProvider.GetValue(key);
            if (value != ValueProviderResult.None)
            {
                return value.FirstValue;
            }
            return null;
        }
    }
    public class MT4ComplexTypeModelBinder : ComplexTypeModelBinder
    {
        private Func<int, object> _modelCreator;

        public MT4ComplexTypeModelBinder(
            IDictionary<ModelMetadata, IModelBinder> propertyBinders,
            ILoggerFactory loggerFactory,
            bool allowValidatingTopLevelNodes) : base(propertyBinders, loggerFactory, allowValidatingTopLevelNodes)
        {
        }

        protected override object CreateModel(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            if (_modelCreator == null)
            {
                var modelTypeInfo = bindingContext.ModelType.GetTypeInfo();
                var constructor = modelTypeInfo.GetConstructor(new[] { typeof(int) });
                var parameter = Expression.Parameter(typeof(int), "p");

                _modelCreator = Expression
                    .Lambda<Func<int, object>>(Expression.New(constructor, parameter), parameter)
                    .Compile();
            }

            var codePage = bindingContext.CodePage();
            if (codePage == 0)
            {
                var option = bindingContext.HttpContext.RequestServices.GetRequiredService<IOptions<MT4NativeOption>>();
                codePage = option?.Value?.codePage ?? 0;
            }

            return _modelCreator(codePage);
        }
    }

    public class MT4ManagerModelBinder : MT4ComplexTypeModelBinder
    {
        public MT4ManagerModelBinder(
            IDictionary<ModelMetadata, IModelBinder> propertyBinders,
            ILoggerFactory loggerFactory,
            bool allowValidatingTopLevelNodes) : base(propertyBinders, loggerFactory, allowValidatingTopLevelNodes)
        {
        }

        protected override object CreateModel(ModelBindingContext bindingContext)
        {
            var requestServices = bindingContext.HttpContext.RequestServices;
            var tokenManager = requestServices.GetRequiredService<ITokenManager>();
            var repository = requestServices.GetRequiredService<IDictionary<string, MT4Manager>>();

            var identifier = tokenManager.TokenInRequest(bindingContext.HttpContext.Request.Headers["authorization"]);
            if (string.IsNullOrWhiteSpace(identifier))
                throw new ArgumentNullException($"token {identifier} not found in server");

            if (!repository.ContainsKey(identifier))
                throw new ArgumentNullException($"MT4Manager is not exists with token {identifier}");

            var manager = repository.First(p => p.Key == identifier).Value;

            var model = CreateModel(manager, bindingContext);
            return model;
        }

        protected virtual object CreateModel(MT4Manager manager, ModelBindingContext bindingContext)
        {
            var codePage = bindingContext.CodePage();
            
            switch (bindingContext.ModelType.Name)
            {
                case "ConSymbol":
                    var value = bindingContext.GetParameterValue("Name");
                    return manager.CfgRequestSymbol(codePage).Where(p => p.Name == value).First();

                default: break;
            }

            return null;
        }
    }
    public class MT4ManagerModelBinderProvider : MT4ComplexTypeModelBinderProvider
    {
        protected override IModelBinder GetBinder(
            ModelBinderProviderContext context,
            IDictionary<ModelMetadata, IModelBinder> propertyBinders,
            ILoggerFactory loggerFactory,
            bool allowValidatingTopLevelNodes)
        {
            try
            {
                if (context.BindingInfo.BinderModelName == nameof(MT4ManagerModelBinder))
                {
                    return new MT4ManagerModelBinder(
                        propertyBinders,
                        loggerFactory,
                        allowValidatingTopLevelNodes);
                }
            }
            catch (Exception exception)
            {
                var message = exception.Message;

                return null;
            }

            return null;
        }
    }
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
    public class FromMT4ManagerAttribute : Attribute
    {
    }

    public static class MT4ModelBindingServiceCollectionExtensions
    {
        public static IMvcBuilder AddMT4ModelBinding(this IMvcBuilder mvcBuilder, Action<MvcOptions> action = null)
        {
            if (action != null)
                mvcBuilder.AddMvcOptions(action);
            else
                mvcBuilder.AddMvcOptions(option =>
                {
                    option.ModelBinderProviders.Insert(option.ModelBinderProviders.Count - 1, new MT4ManagerModelBinderProvider());
                    option.ModelBinderProviders.Insert(option.ModelBinderProviders.Count - 1, new MT4ComplexTypeModelBinderProvider());
                });
            return mvcBuilder;
        }
    }
}
