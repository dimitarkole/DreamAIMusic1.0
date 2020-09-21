namespace DreamAIMusic.Tests.TestData
{
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Web.ViewModels.Administration.CategoriesModels;
    using System.Collections.Generic;

    public static class CategoryTestsData
    {
        public static CategoryInputModel CreateModel => new CategoryInputModel()
        {
            Name = "asd",
        };

        public static List<Category> GetCategories => new List<Category>()
        {
            new Category { Id = "2", Name ="asd2"},
            new Category { Id = "1", Name ="asd1"},
            new Category { Id = "4", Name ="asd4"},
            new Category { Id = "3", Name ="asd3"},
            new Category { Id = "5", Name ="asd5"},
        };

        public static CategoryEditModel UpadateModel => new CategoryEditModel()
        {
            Name = "asd Update",
        };

        public static string UpdateCategoryId => GetCategories[0].Id;

        public static string DeleteCategoryId => GetCategories[0].Id;

        public static string GetCategoryId => GetCategories[0].Id;
    }
}
