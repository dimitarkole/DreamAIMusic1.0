namespace DreamAIMusic.Web.ViewModels.CommonResurces.CategoryModels
{
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Mapping;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
