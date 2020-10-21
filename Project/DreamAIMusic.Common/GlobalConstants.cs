namespace DreamAIMusic.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "DreamAIMusic";

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

        public static class Email
        {
            public const string SystemEmail = "info@dreamAIMusic.com";
            public const string VerificationCodeCharacters = "abcdefghijklmnopqrstuvwxyABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            public const string ApiKey = "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";
            public const int VerificationCodeLength = 6;
        }

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
