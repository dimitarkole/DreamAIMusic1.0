namespace DreamAIMusic.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DreamAIMusic.Data;
    using DreamAIMusic.Services.Data.Tests.ClassFixtures;
    using DreamAIMusic.Services.Data.Tests.Factories;
    using Xunit;

    public class BaseTestClass : IClassFixture<MappingsProvider>
    {
        protected readonly ApplicationDbContext context;

        public BaseTestClass()
        {
            this.context = ApplicationDbContextFactory.CreateInMemoryDatabase();
        }
    }
}
