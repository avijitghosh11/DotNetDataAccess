namespace DotNetCore.MongoDB.API.DatabaseCore
{
    public interface IAppDatabaseSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
        string StudentCollection { get; set; }
        string TeacherCollection { get; set; }
    }
}
