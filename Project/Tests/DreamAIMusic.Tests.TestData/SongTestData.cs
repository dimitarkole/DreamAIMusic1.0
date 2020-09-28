using DreamAIMusic.Data.Models;
using DreamAIMusic.Web.ViewModels.User.SongModels;
using System.Collections.Generic;
using System.Linq;

namespace DreamAIMusic.Tests.TestData
{
    public class SongTestData
    {
        public static SongInputModel CreateModel => new SongInputModel()
        {
            Name = "asd",
            CategoryId = Categories[0].Id,
            ImageExtension = ".img",
            Mp3Extension = ".mp3",
            Text ="this is test text",
            UniqueSongFilesName = "Unique Song Files Name"
        };

        public static string CreateUserId => Users[0].Id;

        public static string GetOwnSongsUserId => Users[0].Id;

        public static string IsOwnSongIdTrue => GetSongs[0].Id;


        public static string IsOwnSongUserIdTrue => Users
            .Where(u => u.Id == GetSongs[0].UserId)
            .FirstOrDefault()
            .Id;


        public static string IsOwnSongUserIdFalse => Users
            .Where(u => u.Id != GetSongs[0].UserId)
            .FirstOrDefault()
            .Id;

        public static string IsOwnSongIdFalse => GetSongs[0].Id;


        public static string DeleteSongId => GetSongs[0].Id;

        public static string GetById => GetSongs[0].Id;


        public static List<Category> Categories => new List<Category>()
        {
            new Category(){ Id ="testCategoryId1", Name = "testCategory1"},
            new Category(){ Id ="testCategoryId2", Name = "testCategory2"},
            new Category(){ Id ="testCategoryId3", Name = "testCategory3"},
            new Category(){ Id ="testCategoryId4", Name = "testCategory4"},
            new Category(){ Id ="testCategoryId5", Name = "testCategory5"},
        };

        public static List<Song> GetSongs => new List<Song>()
        {
            new Song(){ Id ="testSongId1", Name = "testSong1", Category =Categories[0], CategoryId = Categories[0].Id, ImageExtension =".img", Mp3Extension = ".mp3", Text = "some text", UniqueSongFilesName = "unique song file name", User = Users[0], UserId = Users[0].Id, Comments = Comments},
            new Song(){ Id ="testSongId2", Name = "testSong2", Category =Categories[1], CategoryId = Categories[1].Id, ImageExtension =".img", Mp3Extension = ".mp3", Text = "some text", UniqueSongFilesName = "unique song file name", User = Users[1], UserId = Users[1].Id, Comments = new List<Comment>()},
            new Song(){ Id ="testSongId5", Name = "testSong5", Category =Categories[2], CategoryId = Categories[2].Id, ImageExtension =".img", Mp3Extension = ".mp3", Text = "some text", UniqueSongFilesName = "unique song file name", User = Users[2], UserId = Users[2].Id, Comments = new List<Comment>()},
            new Song(){ Id ="testSongId3", Name = "testSong3", CategoryId = Categories[0].Id, ImageExtension =".img", Mp3Extension = ".mp3", Text = "some text", UniqueSongFilesName = "unique song file name", UserId = Users[1].Id, Comments = new List<Comment>()},
            new Song(){ Id ="testSongId4", Name = "testSong4", CategoryId = Categories[1].Id, ImageExtension =".img", Mp3Extension = ".mp3", Text = "some text", UniqueSongFilesName = "unique song file name", UserId = Users[0].Id, Comments = new List<Comment>()},
        };

        public static List<ApplicationUser> Users => new List<ApplicationUser>()
        {
            new ApplicationUser(){Id="testUserId1", FirstName = "First Name1", LastName = "Last Name1", UserName= "UserName1"},
            new ApplicationUser(){Id="testUserId2", FirstName = "First Name2", LastName = "Last Name2",  UserName= "UserName3"},
            new ApplicationUser(){Id="testUserId3", FirstName = "First Name3", LastName = "Last Name3",  UserName= "UserName2"},
        };

        public static List<Comment> Comments => new List<Comment>()
        {
            new Comment(){Id ="testCommentId1", SongId = GetById, Text="comment1", User = Users[1], UserId = Users[1].Id},
            new Comment(){Id ="testCommentId2", SongId = GetById, Text="comment2", User = Users[1], UserId = Users[1].Id},
            new Comment(){Id ="testCommentId3", SongId = DeleteSongId, Text="comment3", User = Users[1], UserId = Users[1].Id},
            new Comment(){Id ="testCommentId4", SongId = GetById, Text="comment4", User = Users[1], UserId = Users[1].Id},
            new Comment(){Id ="testCommentId5", SongId = GetById, Text="comment5", User = Users[1], UserId = Users[1].Id},
        };

       /* public static SongEditModel UpdateModel => new SongEditModel()
        {
            Name = "asd",
            CategoryId = Categories[0].Id,
            Text = "this is test text",
        };*/
    }
}
