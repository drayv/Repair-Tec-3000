namespace RepTec.App
{
    public static class Startup
    {
        public static void AppStartup()
        {
            DataAccess.Startup.SeedData();
        }
    }
}