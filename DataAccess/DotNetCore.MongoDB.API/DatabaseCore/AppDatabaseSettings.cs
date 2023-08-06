namespace DotNetCore.MongoDB.API.DatabaseCore
{
    public class AppDatabaseSettings : IAppDatabaseSettings
    {
        public string DatabaseName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string StudentCollection { get; set; } = string.Empty;
        public string TeacherCollection { get; set; } = string.Empty;
    }
}
