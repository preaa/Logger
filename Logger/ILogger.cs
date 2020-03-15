using System;
namespace Logger
{
    public interface ILogger
    {

        public void Log(string message);

        public void Log(Exception ex);

        public void LogWithFormat(Exception ex);

        public void LogWithFormat(string message);
    }
}
