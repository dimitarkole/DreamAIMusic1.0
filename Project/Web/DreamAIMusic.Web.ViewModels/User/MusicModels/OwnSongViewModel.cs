using AutoMapper;
using DreamAIMusic.Data.Models;
using DreamAIMusic.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamAIMusic.Web.ViewModels.UserModels.MusicModels
{
    public class OwnSongViewModel : IMapFrom<Song>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public string MusicTypeId { get; set; }

        public string MusicTypeName { get; set; }

        public string Text { get; set; }

        public int Rating { get; set; }

        public long CountLikes { get; set; }

        public long CountViews { get; set; }

        public long CountDisLikes { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
               .CreateMap<Song, OwnSongViewModel>()
               .ForMember(
                   destination => destination.Rating,
                   opts => opts.MapFrom(origin =>
                        origin.CountDisLikes + origin.CountLikes == 0 ? 0 :
                            (int) ((origin.CountLikes * 1.0 / (origin.CountDisLikes + origin.CountLikes)) * 100)));
            /*
            configuration.CreateMap<Song, OwnSongViewModel>()
                            .ForMember(s => s.Rating, y => y.MapFrom(m => m.CountLikes + m.CountDisLikes != 0 ? m.CountLikes / (m.CountLikes + m.CountDisLikes) : 0));
            */// / (s.CountLikes + s.CountDisLikes), y => y.MapFrom(m => m.Rating = ));
        }
    }
}
