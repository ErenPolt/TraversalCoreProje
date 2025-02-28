using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.MailDTOs
{
    public class MaildRequestDTOs
    {
        public string Name { get; set; }//Maili gönderen kişinin ismi
        public string SenderMail { get; set; }//Gönderen kişi
        public string ReceiverMail { get; set; }//Alıcı kişi
        public string Subject { get; set; }//Konu
        public string Body { get; set; }//Mesaj içeriği
    }
}
