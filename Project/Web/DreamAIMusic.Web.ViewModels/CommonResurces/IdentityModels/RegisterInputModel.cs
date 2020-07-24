namespace DreamAIMusic.Web.ViewModels.CommonResurces.IdentityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class RegisterInputModel
    {
       
		private const int UsernameMinLength = 5;
		private const int PasswordMinLength = 5;

		[Required]
		[MinLength(UsernameMinLength)]
		public string Username { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Compare(nameof(ConfirmPassword))]
		[MinLength(PasswordMinLength)]
		[Required]
		public string Password { get; set; }

		public string ConfirmPassword { get; set; }
    }
}
