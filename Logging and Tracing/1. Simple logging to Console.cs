/*
 *      This example demonstrates how to create a simple Log4Net Logger and log things to the Console
 *      
 *      Terminology:
 *      
 *          1.  Logger      -   This is the object that you write debug and trace messages to.
 *          2.  Appender    -   A thing which takes a log message and puts it somewhere. You configure Appenders in a 
 *                              config file.
 *          2.  Trace Level -   There are 5 trace levels. In order of increasing severity and decreasing quantity:
 *                              Debug, Info, Warn, Error, Fatal
 *                              
 *          
 *      Observe:
 *      
 *          1.  We create a logger using the name of the class we are logging in. This info gets added when the 
 *              message is output to an Appender
 *          2.  BasicConfigurator.Configure() configures a simple Console Appender so that messages are written to the 
 *              Console window.
 *          
 */
using log4net;
using log4net.Config;
using NUnit.Framework;

namespace Driven.LoggingAndTracing
{
    [TestFixture]
    public class SimpleLoggingToConsole
    {
        [Test]
        public void Create_logger_and_output_info_to_console()
        {
            ILog log = LogManager.GetLogger(typeof (SimpleLoggingToConsole));
            
            BasicConfigurator.Configure();

            log.Debug("debug stuff");
            log.Info("info stuff");
            log.Warn("warning stuff");
            log.Error("error stuff");
            log.Fatal("fatal stuff");
        }
    }
}