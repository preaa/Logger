using System;
namespace Logger
{
    public class DatabaseLogger : ILogger
    {
        public DatabaseLogger()
        {
        }

        public void Log(string message)
        {
            throw new NotImplementedException();
        }

        public void Log(Exception ex)
        {
            throw new NotImplementedException();
        }

        public void LogWithFormat(Exception ex)
        {
            throw new NotImplementedException();
        }

        public void LogWithFormat(string message)
        {
            throw new NotImplementedException();
        }
    }
}
