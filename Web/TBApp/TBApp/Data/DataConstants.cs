namespace TBApp.Data
{
    public class DataConstants
    {
        public static class User
        {
            public const int FirstNameMaxLength = 15;
            public const int LastNameMaxLength = 15;
            public const int UsernameMaxLength = 15;
        }
        public static class Task
        {
            public const int TitleMinLength = 5;
            public const int TitleMaxLength = 70;

            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 1000;
        }
        public static class Board
        {
            public const int BoardNameMinLength = 3;
            public const int BoardNameMaxLength = 30;
        }
    }
}
