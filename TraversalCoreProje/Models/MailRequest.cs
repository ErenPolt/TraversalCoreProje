namespace TraversalCoreProje.Models
{
    public class MailRequest
    {
        public  string Name { get; set; }//Maili gönderen kişinin ismi
        public  string SenderMail { get; set; }//Gönderen kişi
        public  string ReceiverMail { get; set; }//Alıcı kişi
        public  string Subject { get; set; }//Konu
        public  string Body { get; set; }//Mesaj içeriği
    }
}
