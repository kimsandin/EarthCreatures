using ClashOfTheCharacters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ClashOfTheCharacters.Controllers
{
    public class HelpController : Controller
    {
        // GET: Help
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Faq()
        {
            return View();
        }

        public ActionResult Gameguide()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ViewResult ContactForm()
        {
            return View();
        }
        [HttpPost]
        public ViewResult ContactForm(ContactRequest contactRequest)
        {
            if (ModelState.IsValid)
            {
                var customerName = contactRequest.Name;
                var customerEmail = contactRequest.Email;
                var customerRequest = contactRequest.SupportRequest;
                var customerPhone = contactRequest.Phone;
                var supportEmail = "creatures@cimoco.se";
                //TODO: Email question to support
                try
                {
                    WebMail.SmtpServer = "smtp01.binero.se";
                    WebMail.SmtpPort = 587;
                    WebMail.SmtpUseDefaultCredentials = false;
                    WebMail.EnableSsl = true;
                    WebMail.UserName = "creatures@cimoco.se";
                    WebMail.Password = "123456";
                    WebMail.From = supportEmail;
                    WebMail.Send(to: supportEmail, subject: "Help request from - " + customerName,
                        body: "Support request from: " + customerName + ", \nPhonenumber: " + customerPhone + ", \nEmail: " + customerEmail + ", \nQuestion: " + customerRequest


                    );
                    return View("Thanks", contactRequest);
                }
                catch (Exception)//(NullReferenceException ex)
                {
                    //ViewBag.ErrorMessage = ex.Message;
                    return View("SendEmailError");
                }
            }
            else
            {
                // there is a validation error
                return View();
            }

        }
    }
}