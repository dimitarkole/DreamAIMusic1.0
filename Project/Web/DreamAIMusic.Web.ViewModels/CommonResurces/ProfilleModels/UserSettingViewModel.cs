namespace DreamAIMusic.Web.ViewModels.CommonResurces.ProfilleModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DreamAIMusic.Common;

    public class UserSettingViewModel
    {
        public int Id { get; set; }

        public SettingType Type { get; set; }

        public bool Enabled { get; set; }
    }
}
