/*
 *      This example demonstrates how to use a Log4Net Logger to log to file
 *      
 *      Observe:
 *      
 *          1.  Look at the bottom of the AssemblyInfo.cs class in this project. You will see that we have configured
 *              Log4Net to look for a configuration file called log4net.config.
 *          2.  In the same entry in AssemblyInfo.cs we have set Watch=true, which means that logging framework will 
 *              watch for changes in this file and adapt accordingly (you don't need to stop the running application)
 *          3.  If you open the log4net.config file you will see a standard .NET configuration file with a single 
 *              configSection called 'log4net'. This section contains the configuration for two Appenders, RollingFileAppender
 *              and TraceAppender. The first writes trace info to file, the other to the Output window of Visual Studio
 *          4.  The last section in the log4net configSection defines the level above which messages will be written. It also
 *              attaches the two Appenders we defined.
 *              
 *      Try:
 *      
 *          1.  Run the test below. Look in the bin\debug directory for the .log file (named domain-nunit.addin.dll_hbr2.log
 *              in this instance, because the code is running under the NUnit testing process). Open the file and see
 *              that all of the messages have been written.
 *          2.  Change the level of logging in log4net.config from ALL to ERROR and run the test again. You will see that
 *              only messages of Warn or above have been written (ie, Warn, Error and Fatal). Try again using FATAL and
 *              you will see that only Fatal messages are written.
 *          
 */
using log4net;
using NUnit.Framework;

namespace Driven.LoggingAndTracing
{
    [TestFixture]
    public class LoggingToTextFile
    {
        [Test]
        public void Create_logger_and_output_info_to_text_file()
        {
            ILog log = LogManager.GetLogger(typeof(SimpleLoggingToConsole));

            log.Debug("debug stuff");
            log.Info("info stuff");
            log.Warn("warning stuff");
            log.Error("error stuff");
            log.Fatal("fatal stuff");
        }
    }
}