namespace _clone.Scripts.Services.LogService
{
    public interface ILogService : IService
    {
        void Log(string msg);
        void LogError(string msg);
        void LogWarning(string msg);
    }
}