using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using DataLibrary.Database;
using DataLibrary.Security;

namespace DataLibrary.Config
{
    public class MailHelper
    {
        public static bool SendMail(string toEmail, string subject, string content)
        {
            try
            {
                using (var db = new MyDbDataContext())
                {
                    MailConfig configWebsite = db.MailConfigs.FirstOrDefault() ?? new MailConfig();
                    Company company = db.Companies.FirstOrDefault() ?? new Company();
                    string host = configWebsite.Smtp;
                    int port = (int)configWebsite.Port;
                    
                    string email = configWebsite.Email;
                    string password = CryptorEngine.Decrypt(configWebsite.Password, true);

                    var smtpClient = new SmtpClient(host, port)
                    {
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(email, password),
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        EnableSsl = true,
                        Timeout = 100000
                    };

                    var mail = new MailMessage
                    {
                        Body = content,
                        Subject = subject,
                        From = new MailAddress(company.Email, company.CompanyName)
                    };

                    mail.To.Add(new MailAddress(toEmail));
                    mail.BodyEncoding = Encoding.UTF8;
                    mail.IsBodyHtml = true;
                    mail.Priority = MailPriority.High;

                    smtpClient.Send(mail);

                    return true;
                }
            }
            catch (SmtpException smex)
            {
                return false;
            }
        }
    }
}