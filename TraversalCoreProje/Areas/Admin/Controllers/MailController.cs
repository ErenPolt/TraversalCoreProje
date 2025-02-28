using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)//Mail gönderme işlemi; MailKit ve MimeKit kütüphanesi kullanldı.
        {
            MimeMessage mimeMessage = new MimeMessage();//E-postanın içeriği ve başlığını oluşturmak için mimeMessage nesnesi oluşturuldu.

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "mailRequest.SenderMail");//mail gönderene kişinin adı ve eposta adresi
            mimeMessage.From.Add(mailboxAddressFrom);//Kimden geldi..Gönderici bilgisini tutuyo

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.ReceiverMail);//Maili alan kişinin adını ve eposta adresi
            mimeMessage.To.Add(mailboxAddressTo);//Kime gitti.Alıcı bilgisini tuut
            
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mailRequest.Body;
            mimeMessage.Body=bodyBuilder.ToMessageBody();//Mesaj içerik kısmı 

            mimeMessage.Subject = mailRequest.Subject;//Formdan gelene konu başlığını tutuyor.
            
            SmtpClient Client = new SmtpClient();//MailKit kütüphanesinden gelen bir sınıf.E-postayı göndermek için SMTP protokolünü kullanıyoruz..
            Client.Connect("smtp.gmail.com", 587, false);
            //Client.Connect(): SMPT Sunucusuna bağlanmak için kullanılır. 
            //"smtp.gmail.com": SMPT'nin gmail sunucusu
            //587: port numarası
            //false:  SSL kullanmadan bağlantı kuracağını belirtir. (STARTTLS kullanılacak)
            //SSL: (Secure Sockets Layer): İşlem yaptığımızda , tüm verileri şifreler. ondan false diyerek bu güvenlik protokolünü kapattık.
            Client.Authenticate("mailRequest.SenderMail", "mailşifresi");//Otantike olma işlemi. gönderen maili ve şifresi
            Client.Send(mimeMessage);//Maili gönder..
            Client.Disconnect(true);//SMPT bağlantısnı sonlandır.
            return View();
        }
    }
}
