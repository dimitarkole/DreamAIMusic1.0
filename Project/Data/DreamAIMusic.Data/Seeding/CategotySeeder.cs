namespace DreamAIMusic.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using DreamAIMusic.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class CategotySeeder : ISeeder
    {
        private readonly string[] categotyNames = new string[]
        {
            "ROC",
            "Rap",
            "R&B",
            "Chalga",
            "POP",
            "Folk",
            "Folk",
        };

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var tasks = new List<Task>();

            foreach (string name in this.categotyNames)
            {
                tasks.Add(Task.Run(async () =>
                {
                    if (!await dbContext.Categories.AnyAsync(a => a.Name == name))
                    {
                        await dbContext.Categories.AddAsync(new Category
                        {
                            Name = name,
                        });
                    }
                }));
            }

            await Task.WhenAll(tasks);
        }
    }
}
