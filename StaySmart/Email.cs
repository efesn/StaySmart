using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace StaySmart
{
    public class Email
    {
        private readonly string smtpServer;
        private readonly int smtpPort;
        private readonly string smtpUsername;
        private readonly string smtpPassword;

        public Email(string smtpServer, int smtpPort, string smtpUsername, string smtpPassword)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("C:\\Users\\efesn\\source\\repos\\StaySmart\\StaySmart\\appsettings.json")
                .Build();

            this.smtpServer = config.GetSection("SMTP")?["Server"] ?? throw new ArgumentNullException(nameof(smtpServer));
            this.smtpPort = int.Parse(config.GetSection("SMTP")?["Port"] ?? throw new ArgumentNullException(nameof(smtpPort)));
            this.smtpUsername = config.GetSection("SMTP")?["Username"] ?? throw new ArgumentNullException(nameof(smtpUsername));
            this.smtpPassword = config.GetSection("SMTP")?["Password"] ?? throw new ArgumentNullException(nameof(smtpPassword));
        }

        public void SendEmail(string customerEmail, string customerName, string placeName, string checkIn, string checkOut)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);

                mail.From = new MailAddress(smtpUsername);
                mail.To.Add(customerEmail);
                mail.Subject = "Reservation Created";
                mail.Body = $"Dear {customerName},\n\nYour reservation at {placeName} is confirmed. \n\nDetails:\nCheck-in: {checkIn}\nCheck-out: {checkOut}\n\n";

                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                smtpClient.EnableSsl = true;

                smtpClient.Send(mail);

                
                Console.WriteLine("Reservation confirmation email sent successfully.");
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Failed to send reservation confirmation email: " + ex.Message);
            }
        }

        public void UpdateEmail(string customerEmail, string customerName, string placeName, string checkIn, string checkOut)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);

                mail.From = new MailAddress(smtpUsername);
                mail.To.Add(customerEmail);
                mail.Subject = "Reservation Updated";
                mail.Body = $"Dear {customerName},\n\nYour reservation at {placeName} is updated. \n\nDetails:\nCheck-in: {checkIn}\nCheck-out: {checkOut}\n\n";

                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                smtpClient.EnableSsl = true;

                smtpClient.Send(mail);

                
                Console.WriteLine("Reservation updated email sent successfully.");
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Failed to send reservation updated email: " + ex.Message);
            }
        }

        public void DeleteEmail(string customerEmail, string customerName, string placeName, string checkIn, string checkOut)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);

                mail.From = new MailAddress(smtpUsername);
                mail.To.Add(customerEmail);
                mail.Subject = "Reservation Deleted";
                mail.Body = $"Dear {customerName},\n\nYour reservation at {placeName} is deleted. \n\nDetails:\nCheck-in: {checkIn}\nCheck-out: {checkOut}\n\n";

                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                smtpClient.EnableSsl = true;

                smtpClient.Send(mail);

                Console.WriteLine("Reservation deleted email sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to send reservation deleted email: " + ex.Message);
            }
        }
    }
}