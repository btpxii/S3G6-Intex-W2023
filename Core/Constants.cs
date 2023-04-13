namespace Intex2.Core
{
    public static class Constants
    {
        public static class Roles
        {
            public const string Administrator = "Administrator";
            public const string Researcher = "Researcher";
            public const string User = "User";
        }

        public static class Policies
        {
            public const string RequireAdmin = "RequireAdmin";
            public const string RequireResearcher = "RequireResearcher";
            public const string RequireUser = "RequireUser";
        }
    }
}
