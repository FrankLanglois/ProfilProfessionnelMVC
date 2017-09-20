using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using ProfilProfessionnelMVC.Models;

namespace ProfilProfessionnelMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact( Mail e )
        {
            if( ModelState.IsValid )
            {
                if( ModelState.IsValid )
                {

                    // Prepare email
                    var toAddress = ConfigurationManager.AppSettings["MailTo"];
                    var fromAddress = e.Email.ToString();
                    var subject = "De mon Profil Professionnel, email de " + e.Name;
                    var message = new StringBuilder();
                    message.Append( "<p>Name: " + e.Name + "</p>" );
                    message.Append( "<p>Email: " + e.Email + "</p>" );
                    message.Append( "<p>Telephone: " + e.Telephone + "</p>" );
                    message.Append( e.Message );

                    //start email Thread
                    var tEmail = new Thread( () =>
                    SendEmail( toAddress, fromAddress, subject, message.ToString() ) );
                    tEmail.Start();
                }
                return View();
            }
            return View();
        }

        public void SendEmail( string toAddress, string fromAddress,
                      string subject, string message )
        {
            try
            {
                using( var mail = new MailMessage() )
                {
                    string email = ConfigurationManager.AppSettings["MailTo"];
                    string password = ConfigurationManager.AppSettings["MailPW"];
                    ;

                    var loginInfo = new NetworkCredential( email, password );


                    mail.From = new MailAddress( fromAddress );
                    mail.To.Add( new MailAddress( toAddress ) );
                    mail.Subject = subject;
                    mail.Body = message;
                    mail.IsBodyHtml = true;

                    try
                    {
                        using( var smtpClient = new SmtpClient("smtp.gmail.com", 587 ) )
                        {
                            smtpClient.EnableSsl = true;
                            smtpClient.UseDefaultCredentials = false;
                            smtpClient.Credentials = loginInfo;
                            smtpClient.Send( mail );
                        }
                    }
                    finally
                    {
                        //dispose the client
                        mail.Dispose();
                    }

                }
            }
            catch( SmtpFailedRecipientsException ex )
            {
                foreach( SmtpFailedRecipientException t in ex.InnerExceptions )
                {
                    var status = t.StatusCode;
                    if( status == SmtpStatusCode.MailboxBusy ||
                        status == SmtpStatusCode.MailboxUnavailable )
                    {
                        Response.Write( "Delivery failed - retrying in 5 seconds." );
                        System.Threading.Thread.Sleep( 5000 );
                        //resend
                        //smtpClient.Send(message);
                    }
                    else
                    {
                        Response.Write( $"Failed to deliver message to { t.FailedRecipient}");
                    }
                }
            }
            catch( SmtpException Se )
            {
                // handle exception here
                Response.Write( Se.ToString() );
            }

            catch( Exception ex )
            {
                Response.Write( ex.ToString() );
            }

        }
    }
}