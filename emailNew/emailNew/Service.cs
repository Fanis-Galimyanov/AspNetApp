using System.Net;
using System.Net.Mail;

namespace emailNew
{
    public class Service
    {
        private readonly ILogger<Service> logger;
        public Service(ILogger<Service> logger)
        {
            this.logger = logger;
        }
        public void SendEmail()
        {
            try
            {
                MailMessage message = new MailMessage();
                message.IsBodyHtml = true;
                message.From = new MailAddress("admin@itpark.com", "ITPark");
                message.To.Add("fanisga@yandex.ru");
                message.Subject = "Сообщение от System.Net.Mail";
                //message.Body = "Сообщение от System.Net.Mail";

                var plainView = AlternateView.CreateAlternateViewFromString("Просто текст. Текст 1", null, "text/plain");
                var htmlView = AlternateView.CreateAlternateViewFromString("Текскт рядом с рисунком..<img src=cid:companylogo>" +
                    "<img src=cid:dtId> <img src=cid:companylogo> <img src=cid:dtId> <img src=cid:companylogo>",
                                                                            null, "text/html");

                LinkedResource logo = new LinkedResource("wwwroot/img/s.jpg");
                LinkedResource dt = new LinkedResource("wwwroot/img/ms.jpg");
                logo.ContentId = "companylogo";
                dt.ContentId = "dtId";

                htmlView.LinkedResources.Add(logo);
                htmlView.LinkedResources.Add(dt);

                message.AlternateViews.Add(plainView);
                message.AlternateViews.Add(htmlView);

                using (SmtpClient client = new SmtpClient("smtp.gmail.com"))
                {
                    client.Credentials = new NetworkCredential("soportmedimist@gmail.com", "kazan_tatarstan");
                    client.Port = 587;
                    client.EnableSsl = true;

                    client.Send(message);
                    logger.LogInformation("Сообщение отправлено успешно!");
                }

            }
            catch (Exception e)
            {
                logger.LogError(e.GetBaseException().Message);
            }

        }
    }
}
