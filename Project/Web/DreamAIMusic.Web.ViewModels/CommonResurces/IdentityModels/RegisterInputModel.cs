namespace DreamAIMusic.Web.ViewModels.CommonResurces.IdentityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class RegisterInputModel
    {
		private const int UsernameMinLength = 5;
		private const int UsernameMaxLength = 30;

		private const int NameMinLength = 1;
		private const int NameMaxLength = 30;

		private const int FamilyMinLength = 1;
		private const int FamilyMaxLength = 30;

		private const int PasswordMinLength = 8;
		private const int PasswordMaxLength = 20;


		[Required]
		[MinLength(UsernameMinLength)]
		[MaxLength(UsernameMaxLength)]
		public string Username { get; set; }

		[Required]
		[MinLength(NameMinLength)]
		[MaxLength(NameMaxLength)]
		public string Name { get; set; }

		[Required]
		[MinLength(FamilyMinLength)]
		[MaxLength(FamilyMaxLength)]

		public string Family { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		public DateTime Birthday { get; set; }

		[Compare(nameof(ConfirmPassword))]
		[MinLength(PasswordMinLength)]
		[MaxLength(PasswordMaxLength)]
		[Required]
		public string Password { get; set; }

		public string ConfirmPassword { get; set; }
    }
}
