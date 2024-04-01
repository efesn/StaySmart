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
    public class OTPUtility
    {

        private readonly string smtpServer;
        private readonly int smtpPort;
        private readonly string smtpUsername;
        private readonly string smtpPassword;

        public OTPUtility()
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

        public static string GenerateOTP()
        {
            Random rnd = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, 6).Select(s => s[rnd.Next(s.Length)]).ToArray());
        }

        public void SendOTPByEmail(string recipientEmail, string otp)
        {
            SmtpClient client = new SmtpClient(smtpServer, smtpPort)
            {
                Credentials = new NetworkCredential(smtpUsername, smtpPassword),
                EnableSsl = true
            };

            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress(smtpUsername),
                Subject = "Your Login OTP",
                Body = $"Your reservation password is: {otp}"
            };

            mailMessage.To.Add(recipientEmail);
            client.Send(mailMessage);
        }
    }
}