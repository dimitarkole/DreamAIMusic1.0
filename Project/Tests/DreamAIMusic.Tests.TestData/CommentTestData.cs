using DreamAIMusic.Data.Models;
using DreamAIMusic.Web.ViewModels.CommonResurces.CommentModels;
using DreamAIMusic.Web.ViewModels.User.SongModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamAIMusic.Tests.TestData
{
    public static class CommentTestData
    {
        public static string SongId => GetSongs[0].Id;

        public static string GetAllComentnsBySongId => GetSongs[0].Id;

        public static string OtherSongId => GetSongs[1].Id;
        public static string AnotherSongId => GetSongs[2].Id;

        public static string CreateUserId => Users[0].Id;

        public static CommentInputModel CreateModel => new CommentInputModel()
        {
            Text = "this is test text",
            SongId = "songId",
        };

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
            new Song(){ Id ="testSongId1", Name = "testSong1", CategoryId = Categories[0].Id, ImageExtension =".img", Mp3Extension = ".mp3", Text = "some text", UniqueSongFilesName = "unique song file name", UserId = Users[0].Id, Comments = new List<Comment>()},
            new Song(){ Id ="testSongId2", Name = "testSong2", CategoryId = Categories[1].Id, ImageExtension =".img", Mp3Extension = ".mp3", Text = "some text", UniqueSongFilesName = "unique song file name", UserId = Users[1].Id, Comments = new List<Comment>()},
            new Song(){ Id ="testSongId5", Name = "testSong5", CategoryId = Categories[2].Id, ImageExtension =".img", Mp3Extension = ".mp3", Text = "some text", UniqueSongFilesName = "unique song file name", UserId = Users[2].Id, Comments = new List<Comment>()},
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
            new Comment(){Id ="test1CommentId1", SongId = SongId, Text="comment1", UserId = Users[1].Id},
            new Comment(){Id ="test2CommentId2 a", SongId = SongId, Text="comment2 texr", UserId = Users[0].Id, ParentCommentId = "test1CommentId1"},
            new Comment(){Id ="test3ComId3", SongId = OtherSongId, Text="comment3 a", UserId = Users[2].Id},
            new Comment(){Id ="test4CommentId4", SongId = SongId, Text="comment4 sa", UserId = Users[1].Id},
            new Comment(){Id ="test5CommentId5", SongId = AnotherSongId, Text="comment5 sad",UserId = Users[2].Id},
            new Comment(){Id ="test6CommentId6", SongId = SongId, Text="comment1 gfe", UserId = Users[0].Id},
            new Comment(){Id ="test7CommentId7", SongId = AnotherSongId, Text="comment2 asds asd", UserId = Users[2].Id},
            new Comment(){Id ="testCommentId8", SongId = OtherSongId, Text="comment3 adsd", UserId = Users[1].Id},
            new Comment(){Id ="testCommentId9", SongId = SongId, Text="comment4 sdafd", UserId = Users[1].Id},
            new Comment(){Id ="testCommentId10", SongId = AnotherSongId, Text="comment5 asdsa", UserId = Users[1].Id, ParentCommentId = "test1CommentId1"},
        };
    }
}
