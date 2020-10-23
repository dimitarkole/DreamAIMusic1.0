namespace DreamAIMusic.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DreamAIMusic.Common;

    public class UserSetting : Entity<int>
    {
        public SettingType Type { get; set; }

        public bool Enabled { get; set; }

        public string UserId { get; set; }
        
        public ApplicationUser User { get; set; }
    }
}
