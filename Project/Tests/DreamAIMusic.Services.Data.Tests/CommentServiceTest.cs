namespace DreamAIMusic.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Common;
    using DreamAIMusic.Tests.TestData;
    using DreamAIMusic.Web.ViewModels.CommonResurces.CommentModels;
    using Xunit;

    public class CommentServiceTest : BaseTestClass
    {
        [Fact]
        public async Task CreateComment_WithValidData_ShouldWorkCorrect()
        {
            var commentService = await this.CreateCommentService(new List<Comment>());
            var model = CommentTestData.CreateModel;
            var userId = CommentTestData.CreateUserId;

            await commentService.Create(model, userId);

            Assert.True(this.context.Comments.Any(c => c.Text == model.Text
                && c.UserId == userId
                && c.SongId == model.SongId));
        }

        [Fact]
        public async Task GetAllComment_WithValidData_ShouldWorkCorrect()
        {
            var commentService = await this.CreateCommentService(new List<Comment>());
            var getAllComentnsBySongId = CommentTestData.GetAllComentnsBySongId;
            int expextedCount = this.context.Comments
                .Where(c => c.SongId == getAllComentnsBySongId)
                .Count();

            var results = commentService.All<CommentViewModel>(getAllComentnsBySongId).ToList();

            Assert.Equal(expextedCount, results.Count);
            foreach (var result in results)
            {
                Assert.True(this.context.Comments.Any(c => c.Id == result.Id
                    && c.Text == result.Text));
            }
        }

        private async Task<CommentService> CreateCommentService(List<Comment> comments)
        {
            var users = CommentTestData.Users;
            var category = CommentTestData.Categories;
            var songs = CommentTestData.GetSongs;

            await this.context.Users.AddRangeAsync(users);
            await this.context.Categories.AddRangeAsync(category);
            await this.context.Songs.AddRangeAsync(songs);
            await this.context.Comments.AddRangeAsync(comments);
            await this.context.SaveChangesAsync();
            var service = new CommentService(this.context);

            return service;
        }
    }
}
