using DreamAIMusic.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamAIMusic.Data.Models
{
    public class UserSetting : Entity<int>
    {
        public SettingType Type { get; set; }

        public bool Enabled { get; set; }

        public string UserId { get; set; }
        
        public ApplicationUser User { get; set; }
    }
}
