using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Reflection;

namespace DesktopApp.Helpers
{
    public class Email
    {
        private string FromAddress;
        private string FromPassword;

        private string ToAddress;
        private string EmailSubject;
        private string EmailBody;

        public Email(string to, string subject, string body)
        {
            ToAddress = to;
            EmailSubject = subject;
            EmailBody = body;
        }

        public void Send()
        {
            try
            {
                GetAccess();
                GetEmailBody(EmailSubject, EmailBody);

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(FromAddress, FromPassword)
                };

                using (var message = new MailMessage(FromAddress, ToAddress)
                {
                    IsBodyHtml = true,
                    Subject = EmailSubject,
                    Body = EmailBody
                })
                {
                    smtp.Send(message);
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void GetEmailBody(string subject, string body)
        {
            var emailBody = ReadResource("emailBody.html");

            emailBody = emailBody.Replace("#TITLE#", subject);
            emailBody = emailBody.Replace("#BODY#", body);

            EmailBody = emailBody;
        }

        public string ReadResource(string name)
        {
            // Determine path
            var assembly = Assembly.GetExecutingAssembly();
            string resourcePath = name;
            // Format: "{Namespace}.{Folder}.{filename}.{Extension}"
            resourcePath = assembly.GetManifestResourceNames().Single(str => str.EndsWith(name));            

            using (Stream stream = assembly.GetManifestResourceStream(resourcePath))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        private void GetAccess()
        {
            var emailFile = File.ReadAllLines(@"C:\Temp\email.txt");

            if(emailFile.Length != 2)
            {
                throw new Exception("Niepoprawny plik z danymi konta pocztowego");
            }

            FromAddress = emailFile[0].Trim();
            FromPassword = emailFile[1].Trim();
        }


    }
}
