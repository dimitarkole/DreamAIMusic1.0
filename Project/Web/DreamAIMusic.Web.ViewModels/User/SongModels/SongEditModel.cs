namespace DreamAIMusic.Web.ViewModels.User.SongModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AutoMapper;
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Mapping;

    public class SongEditModel : IMapTo<Song>//, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public string CategoryId { get; set; }

        public string Text { get; set; }

        public string Image { get; set; }

        /* public void CreateMappings(IProfileExpression configuration)
            {
                throw new NotImplementedException();
            }*/
    }
}
