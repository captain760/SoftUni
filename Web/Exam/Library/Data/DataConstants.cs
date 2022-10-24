namespace Library.Data
{
    public class DataConstants
    {
        public static class User
        {
            public const int UserNameMaxLength = 20;
            public const int EmailMaxLength = 60;
            public const int PasswordMaxLength = 20;
            public const int UserNameMinLength = 5;
            public const int EmailMinLength = 10;
            public const int PasswordMinLength = 5;
            public const string ErrorUserId = "User ID is invalid!";
        }
        public static class Book
        {
            public const int TitleMinLength = 10;
            public const int TitleMaxLength = 50;
            public const int AuthorMinLength = 5;
            public const int AuthorMaxLength = 50;
            public const int DescriptionMinLength =5;
            public const int DescriptionMaxLength = 5000;
            public const string ErrorBookId = "Book ID is invalid!";
        }
        public static class Category
        {
            public const int CategoryNameMinLength = 5;
            public const int CategoryNameMaxLength = 50;
        }
    }
}
