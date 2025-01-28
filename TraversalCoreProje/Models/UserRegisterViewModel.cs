using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.Models
{
	public class UserRegisterViewModel//Kullanıcı Kayıt Modeli
	{
		[Required(ErrorMessage = "Lütfen Adınızı Giriniz..!")]
        public string Name { get; set; }


		[Required(ErrorMessage = "Lütfen Soyadınızı Giriniz..!")]
		public string Surname { get; set; }


		//[Required(ErrorMessage = "Lütfen Cinsiyetinizi Giriniz..!")]
		//public string Gender { get; set; }



		[Required(ErrorMessage = "Lütfen Kullancı adınızı Giriniz..!")]
		public string Username { get; set; }


		[Required(ErrorMessage = "Lütfen Mail Adresini Giriniz..!")]
		public string Mail { get; set; }


		[Required(ErrorMessage = "Lütfen Şifreyi  Giriniz..!")]
		public string Password { get; set; }


		[Required(ErrorMessage = "Lütfen Şifreyi Tekrar Giriniz..!")]
		[Compare("Password", ErrorMessage = "Şifreler uyumlu değil..!")]
		public string ConfirmPassword { get; set; }
	}
}
