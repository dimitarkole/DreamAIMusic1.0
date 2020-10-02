﻿namespace DreamAIMusic.Web.ViewModels.User.SongModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AutoMapper;
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Mapping;
    using DreamAIMusic.Web.ViewModels.CommonResurces.CommentModels;
    using DreamAIMusic.Web.ViewModels.User.SongModels;

    public class SongPlayModel : IMapFrom<Song>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string UserUserName { get; set; }

        public string UniqueSongFilesName { get; set; }

        public string ImageExtension { get; set; }

        public string Mp3Extension { get; set; }

        public virtual string CategoryId { get; set; }

        public virtual string CategoryName { get; set; }

        public string Text { get; set; }

        // public string CountViews { get; set; }

        // public long CountLikes { get; set; }

        // public long CountDisLikes { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual List<CommentViewModel> Comments { get; set; }

        public SongUserViewModel User { get; set; }
    }
}
