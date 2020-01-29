using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace rox.mt4.rest
{
    using rox.mt4.api;

    public partial class MT4Controller
    {
        public class MailSendBox
        {
            public MailBox MailBox { get; set; }
            public IEnumerable<int> Logins { get; set; }
        }

        [HttpPost]
        public async Task MailSend([FromBody] MailSendBox mail)
        {
            if (mail == null)
                throw new ArgumentNullException(nameof(mail));
            if (mail.MailBox == null)
                throw new ArgumentNullException(nameof(mail.MailBox));
            if (mail.Logins == null && mail.Logins.Count() <= 0)
                throw new ArgumentNullException(nameof(mail.Logins));

            await Task.Run(() => manager.MailSend(mail.MailBox, mail.Logins));
        }

        [HttpGet]
        public async Task<List<MailBox>> MailsRequest(int codePage)
        {
            return await Task.Run(() => manager.MailsRequest(codePage));
        }

        #region pumping
        [HttpGet]
        public async Task<string> MailLast()
        {
            return await Task.Run(() => manager.MailLast());
        }
        #endregion


        [HttpPost]
        public async Task NewsSend([FromBody] NewsTopic news)
        {
            await Task.Run(() => manager.NewsSend(news));
        }

        #region pumping
        [HttpGet]
        public async Task<List<NewsTopic>> NewsGet(int codePage)
        {
            return await Task.Run(() => manager.NewsGet(codePage));
        }

        [HttpGet]
        public async Task<int> NewsTotal()
        {
            return await Task.Run(() => manager.NewsTotal());
        }

        [HttpGet]
        public async Task<NewsTopic> NewsTopicGet(int pos, int codePage)
        {
            return await Task.Run(() => manager.NewsTopicGet(pos, codePage));
        }

        [HttpGet]
        public async Task NewsBodyRequest(UInt32 key)
        {
            await Task.Run(() => manager.NewsBodyRequest(key));
        }

        [HttpGet]
        public async Task<string> NewsBodyGet(UInt32 key, string languageName)
        {
            return await Task.Run(() => manager.NewsBodyGet(key, languageName));
        }
        #endregion


        [HttpPost]
        public int NotificationsSend(string message, string metaquotes_ids, int[] logins)
        {
            throw new NotImplementedException();
            //await Task.CompletedTask;
            //if (logins != null && logins.Count() > 0)
            //    return await Task.Run(() => manager.NotificationsSend(logins, message));
            //else
            //    return await Task.Run(() => manager.NotificationsSend(metaquotes_ids, message));
        }
    }
}
