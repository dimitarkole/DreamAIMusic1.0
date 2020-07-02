namespace DreamAIMusic.Data.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ILikeInfo
    {
        long CountLikes { get; set; }

        long CountDisLikes { get; set; }
    }
}
