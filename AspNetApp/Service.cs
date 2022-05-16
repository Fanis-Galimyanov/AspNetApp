using AspNetApp.Models;
using System.Net;
using System.Net.Mail;

namespace AspNetApp
{
    public class Service
    {
        private readonly ILogger<Service> logger;
        public Service(ILogger<Service> logger)
        {
            this.logger = logger;
        }
        public void SendEmail(Order order)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.IsBodyHtml = true;
                message.From = new MailAddress("admin@giosoft.com", "Авто магазин");
                message.To.Add(order.email);
                message.Subject = "Автомобили, которые вы выбрали в наше магазине:";

                var plainView = AlternateView.CreateAlternateViewFromString("Tesla motors", null, "text/plain");
                List<string> car_names = new List<string>();
                List<LinkedResource> car_images = new List<LinkedResource>();
                var htmlView = AlternateView.CreateAlternateViewFromString("");

                int index = 0;
                string htmlView_Line = "";

                foreach (var el in order.orderDeails)
                {
                    car_images.Add(new LinkedResource("wwwroot" + el.car.img));
                    car_images[index].ContentId = "ID" + el.id;
                    htmlView_Line += ("<p>" + el.car.longDesc + "</p>" + "<img style='width: 500px' src =cid:" + car_images[index].ContentId + ">");
                    index++;
                }

                htmlView = AlternateView.CreateAlternateViewFromString(htmlView_Line, null, "text/html");

                index = 0;
                foreach (var el in order.orderDeails)
                {
                    htmlView.LinkedResources.Add(car_images[index]);
                    index++;
                }


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
