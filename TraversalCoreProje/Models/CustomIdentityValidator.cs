using Microsoft.AspNetCore.Identity;

namespace TraversalCoreProje.Models
{
	public class CustomIdentityValidator: IdentityErrorDescriber
	{
		public override IdentityError PasswordTooShort(int length)//Şifrenin karakter uzunluğu minumum 6 dır. 
		{
			return new IdentityError()
			{
				Code = "PasswordTooShort",
				Description = $"Parola Minumum {length} karakter olmalıdır..!"
			}; 
		}
		//-------------------------------------------------------------------------------------------------------------------- 
		public override IdentityError PasswordRequiresUpper()//Büyük Harf için
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresUpper",
				Description = $"Parola en az 1 büyük harf içermelidir..!"
			};
		}
		//---------------------------------------------------------------------------------------------------------------------
		public override IdentityError PasswordRequiresLower()//Küçük Harf için
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresLower",
				Description = $"Parola en az 1 küçük harf içermelidir..!"
			};
		}
		//------------------------------------------------------------------------------------------------------------------------
		public override IdentityError PasswordRequiresNonAlphanumeric()//Şifrede  bir tane özel karakter içermelidir.
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresNonAlphanumeric",
				Description = $"Parola en az bir özel karakter içermelidir..! "
			};
		}
		//--------------------------------------------------------------------------------------------------------------------------------
	}
}
