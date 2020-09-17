using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DreamAIMusic.Web.ViewModels.CommonResurces.ProfilleModels
{
    public class ChangePermissionsInputModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string[] Roles { get; set; }
    }
}
