using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TraversalTourProject.DtoLayer.DTOs.MailDTO;
using TraversalTourProject.Presentation.Models;

namespace TraversalTourProject.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Mail")]
    public class MailController : Controller
    {
        [HttpGet]
        [Route("SendMail")]
        public IActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        [Route("SendMail")]
        public IActionResult SendMail(MailRequestDto mailRequest)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "info@alpayakcer.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.RecieverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mailRequest.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = mailRequest.Subject;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("mail.alpayakcer.com", 587, false);
            smtpClient.Authenticate("info@alpayakcer.com", "4675190Aa**");
            if (smtpClient != null)
            {
                smtpClient.Send(mimeMessage);
                smtpClient.Disconnect(true);
                return RedirectToAction("SuccessMail");
            }
            return View();
        }

        [HttpGet]
        [Route("SuccessMail")]
        public IActionResult SuccessMail()
        {
            return View();
        }
    }
}
