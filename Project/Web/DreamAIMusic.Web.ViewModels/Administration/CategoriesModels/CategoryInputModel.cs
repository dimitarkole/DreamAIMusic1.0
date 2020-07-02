using DreamAIMusic.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using DreamAIMusic.Data.Models;
namespace DreamAIMusic.Web.ViewModels.Administration.CategoriesModels
{
    public class CategoryInputModel : IMapTo<Category>
    {
        public string Name { get; set; }
    }
}
