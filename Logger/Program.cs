using System;

namespace Logger
{
    class Program
    {
        static void Main(string[] args)
        {
         
            /*
            *
            * logger class plugin code
            *  Depending on the need, logger class can either log in the database or file
            *  and can be extended to other output formats like an event log 
            *
            */
            try
            {
                var logger = new FileLogger("Whatever the path is", null);
                logger.Log("Message");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
