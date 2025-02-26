using UnityEngine;

namespace _clone.Scripts.Services.LogService
{
    public class LogService : ILogService
    {
        private readonly ILogger logger = Debug.unityLogger;

        public void Log(string msg) => logger.Log(msg);

        public void LogError(string msg) => logger.Log(LogType.Error, msg);
        
        public void LogWarning(string msg) => logger.Log(LogType.Warning, msg);
    }
}