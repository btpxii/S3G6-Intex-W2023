namespace Intex2.Core
{
    // Didn't implement, but constants to use in place of strings when referencing roles
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
