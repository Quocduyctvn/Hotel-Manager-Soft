using Hotel.Client.DTOs;
using Hotel.Data;
using Hotel.Data.Entities;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using OfficeOpenXml.FormulaParsing.Excel.Functions;
using Org.BouncyCastle.Asn1.Pkcs;

namespace Hotel.Client.Controllers
{
    public class ContactController : ControllerBase
    {
        // Biến configuration để lấy thông tin cấu hình mail
        private readonly IConfiguration _configuration;
        public ContactController(ApplicationDbContext DbContext, IConfiguration configuration) : base(DbContext)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Send(ContactDTO contact)
        {
            if (ModelState.IsValid)
            {
                AppContact appContact = new AppContact
                {
                    Name = contact.Name,
                    Phone = contact.Phone,
                    Email = contact.Email,
                    Content = contact.Content,
                    CreatedDate = DateTime.Now
                };
                _HotelDbContext.AppContacts.Add(appContact);
                // Gửi email thông báo bằng MailKit
                SendMail(appContact);

                TempData["Message"] = "Gửi thông tin thành công";
                _HotelDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Có lỗi xảy ra, vui lòng kiểm tra lại thông tin");
                return View("Index");
            }
        }

        private bool SendMail(AppContact contact)
        {
            string subject = "Phản hồi thông tin liên hệ";
            string body = "Cảm ơn bạn đã liên hệ với chúng tôi, chúng tôi sẽ phản hồi lại bạn trong thời gian sớm nhất\n"
                + "Dưới đây là nội dung bạn đã gửi:\n\n"
                + "Họ tên: " + contact.Name + "\n"
                + "Số điện thoại: " + contact.Phone + "\n"
                + "Email: " + contact.Email + "\n"
                + "Nội dung: " + contact.Content + "\n\n";
            // sender email
            string senderName = _configuration["MailSettings:SenderName"];
            string senderEmail = _configuration["MailSettings:SenderEmail"];
            string senderPassword = _configuration["MailSettings:Password"];
            string smtpServer = _configuration["MailSettings:Server"];
            int smtpPort = int.Parse(_configuration["MailSettings:Port"]);


            using (MimeMessage emailMessage = new MimeMessage())
            {
                //Tạo 1 địa chỉ mail người gửi
                MailboxAddress emailFrom = new MailboxAddress(senderName, senderEmail);
                //add địa chỉ mail người gửi vào mimemessage
                emailMessage.From.Add(emailFrom);
                //tạo 1 địa chỉ mail người nhận
                MailboxAddress emailTo = new MailboxAddress(contact.Name, contact.Email);
                //add địa chỉ mail người nhận vào mimemessage
                emailMessage.To.Add(emailTo);
                //thêm mail CC và BCC nếu cần
                //emailMessage.Cc.Add(new MailboxAddress("Cc Receiver", "cc@example.com"));
                //emailMessage.Bcc.Add(new MailboxAddress("Bcc Receiver", "bcc@example.com"));
                //Gán tiêu đề mail
                emailMessage.Subject = subject;
                //Tạo đối tượng chứa nội dung mail
                BodyBuilder emailBodyBuilder = new BodyBuilder();
                emailBodyBuilder.TextBody = body;
                //Gán nội dung mail vào mimemessage
                emailMessage.Body = emailBodyBuilder.ToMessageBody();
                //tạo đối tượng SmtpClient từ Mailkit.Net.Smtp namespace, không dùng  System.Net.Mail nhé
                using (SmtpClient mailClient = new SmtpClient())
                {
                    //Kết nối tới server smtp.gmail
                    mailClient.Connect(smtpServer, smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
                    //đăng nhập
                    mailClient.Authenticate(senderEmail, senderPassword);
                    //gửi mail
                    mailClient.Send(emailMessage);
                    //ngắt kết nối
                    mailClient.Disconnect(true);
                }
            }
            // Gửi email thông báo bằng MailKit
            return true;
        }
    }
}
