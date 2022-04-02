using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace K64_HTTT_Web.Controllers
{
    //https://www.mikesdotnetting.com/article/268/how-to-send-email-in-asp-net-mvc
    public class ApiSendMailController : ApiController
    {
        [Route("api/Mail/SendMail")]
        [HttpGet]
        public async Task<HttpResponseMessage> Send_Way1(string mail_to, string mail_body)
        {
            HttpResponseMessage result = null;

            var mail_from = new MailAddress("iLeaf HTTT <ileafvn@gmail.com>");
            //var mail_to = new MailAddress("HoaTX VNUF <hoatx@vnuf.edu.vn>");

            var mesg = new MailMessage();
            mesg.From = mail_from;
            mesg.To.Add(mail_to);
            mesg.Subject = "Demo Send Mail - API";
            mesg.Body = mail_body; //"Nội dung gửi test API";
            mesg.IsBodyHtml = true;
            // Cho phép đính kèm tập tin
            //mesg.Attachments.Add(new Attachment(HttpContext.Current.Server.MapPath("~/App_Data/Test.docx")));

            try
            {
                using (var smtp = new SmtpClient())
                {
                    // Gửi thử
                    await smtp.SendMailAsync(mesg);
                    await Task.FromResult(0);
                }
                result = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return result;
        }

        //[HttpPost]
        //public async Task<HttpResponseMessage> Send_Way2()
        //{
        //    HttpResponseMessage result = null;

        //    var mail_from = new MailAddress("iLeaf HTTT <ileafvn@gmail.com>");
        //    var mail_to = new MailAddress("HoaTX VNUF <hoatx@vnuf.edu.vn>");

        //    var mesg = new MailMessage();
        //    mesg.From = mail_from;
        //    mesg.To.Add(mail_to);
        //    mesg.Subject = "Demo Send Mail - API";
        //    mesg.Body = "Nội dung gửi test API";
        //    mesg.IsBodyHtml = true;
        //    try
        //    {
        //        using (var smtp = new SmtpClient())
        //        {
        //            // Gửi thử
        //            await smtp.SendMailAsync(mesg);
        //            await Task.FromResult(0);
        //        }
        //        result = Request.CreateResponse(HttpStatusCode.OK);
        //    }
        //    catch (Exception ex)
        //    {
        //        result = Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }

        //    return result;
        //}
    }
}
