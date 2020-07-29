namespace DreamAIMusic.Web.ViewModels.UserModels.SongModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using AutoMapper;
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Mapping;
    using DreamAIMusic.Web.ViewModels.CommonResurces.CategoryModels;
    using Microsoft.AspNetCore.Http;

    public class SongInputModel : IMapTo<Song>//, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string Path { get; set; }

        // 6045ff71-7af1-4b03-a805-f6da3ba1a800
        public string MusicCategoryId { get; set; }

       // public List<CategoryViewModel> Categories { get; set; }

        public string Text { get; set; }

        /*[Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        public IFormFile File { get; set; }

      /*  public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Song, SongInputModel>()
                            .ForMember(s => s.Categories, y => y.Ignore())
                            .ForMember(s => s.File, y => y.Ignore());
        }
      */

    }
}
