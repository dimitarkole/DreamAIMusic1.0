using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DreamAIMusic.Web.ViewModels.CommonResurces.ProfilleModels
{
    public class PasswordChangeInputModel
    {
        [Required]
        public string NewPassword { get; set; }

        [Required]
        public string CurrentPassword { get; set; }
    }
}
