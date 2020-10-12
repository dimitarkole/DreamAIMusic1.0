namespace DreamAIMusic.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "DreamAIMusic";
        public const string SystemEmail = "dim_kolev2002@abv.bg";
        public const string SystemEmailPassword = "dim_kolev2002@abv.bg";

        public const string AdministratorRoleName = "Administrator";
        public const string UserRoleName = "User";

        public const int UsernameMinLength = 5;
        public const int UsernameMaxLength = 30;

        public const int FirstNameMinLength = 1;
        public const int FirstNameMaxLength = 30;

        public const int LastNameMinLength = 1;
        public const int LastNameMaxLength = 30;

        public const int PasswordMinLength = 8;
        public const int PasswordMaxLength = 20;

        public static class Folder
        {
            public const string SongFolderPath = "/Songs/";
            public const string MusicPosterPath = "/images/DreamAIMusic.jpg";
        }

        public static class CreateFile
        {
            public const string RandomNameCharacters = "abcdefghijklmnopqrstuvwxyABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            public const int RandomNameLength = 5;
        }
    }
}
