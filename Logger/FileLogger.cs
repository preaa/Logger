using System;
using System.IO;
using System.Text;

namespace Logger
{
    /*  Few points to consider :
     *  1. Is Logging a critical function? If yes, exceptions must be bubbled upwards for
     *  further handling 
     *  2. If not, depending on the exception, they could be suppressed and we try to log again
     *  
     * */

    /* a lot of times, we may want to log the values in a certain format, lets say
     * in a csv format, so that we can extract the text in a csv file for further
     * graphical representation
     * But if we include the formatting logic also in Logger, this violates the Single Responsibility
     * principle, hence we delegate the formating to another class
     *
     * Method injection is also an easy way to inject added dependencies but it makes the plugging of
     * all the classes in the bootstrapping process harder. For example if we were using a container like Autoface
     * we would like to introduce all the dependencies in the bootstrapping
     * Hence the FormatProvider is in the Constructor instead in the method LogWithFormat
     * 
     * */

    public class FileLogger : ILogger
    {
       
        private string filePath;
        private ILogFormatProvider logFormatProvider;


        public FileLogger(string filePath, ILogFormatProvider formatProvider)
        {
            this.filePath = filePath;
            this.logFormatProvider = formatProvider;
        }

        public void Log(string message)
        {
            try
            {
                using (var file = File.Open(this.filePath, FileMode.OpenOrCreate))
                {

                    var text = new UnicodeEncoding().GetBytes(message);
                    file.Seek(0, SeekOrigin.End);
                    file.Write(text, 0, text.Length);
                }
                    

            }
            catch (Exception ex)
            {
                // if logging is critical, throw
                // else suppress

                if (ex.GetType() == typeof(InvalidOperationException))
                {
                    // handle exception
                    // looks like the stream is already open for writing
                }
                else
                {
                    // cannot handle any other type
                    throw ex;
                }
            }

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
