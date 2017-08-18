using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public ActionResult Send()
        {
            MailModel model = new MailModel();
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Send(MailModel model)
        {
            MailMessage m = new MailMessage();
            m.To.Add(new MailAddress(model.ToAddress));
            m.From = new MailAddress("srikanth@st.com");
            m.Subject = "Testing";
            m.IsBodyHtml = true;  // body contains HTML
            m.Body = model.Body;


            Attachment a1 = new Attachment(Request.MapPath("~/web.config"));
            m.Attachments.Add(a1);

            SmtpClient smtp = new SmtpClient("127.0.0.1", 25);

            // log on to mail server - Authenticate the sender 
            try
            {
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = false;
                smtp.Credentials =
                    new System.Net.NetworkCredential("srikanth@st.com", "s");
                smtp.Send(m);
                ViewBag.Message = "Mail Sent Successfully!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error : " + ex.Message;
            }
            return View(model);
        }
    }
}