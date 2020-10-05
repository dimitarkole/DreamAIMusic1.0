namespace DreamAIMusic.Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public enum Reaction
    {
        [Display(Name = "User like")]
        Like = 1,
        [Display(Name = "Users dislike")]
        Dislike = 2,
    }
}
