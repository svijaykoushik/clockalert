using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Text.RegularExpressions;
using ClockAlert.Modules;

namespace ClockAlertTest
{   
    [TestClass]
    public class TestLogger
    {
        private readonly Regex logItemRegex = new Regex(@"(Info|Error|Warn|Fatal) ([0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12}) ([A-Za-z0-9' . - _ ! # ^ ~]+) (\[(\d{4}-[01]\d-[0-3]\d) ([0-2]\d:[0-5]\d:[0-5]\d) ([+-][0-2]\d:[0-5]\d)\]) (""[\w\s]*"")");

        [TestMethod]
        public void CreateLogItem_ShouldReturnStringInCorrectLogFormat() 
        {
            PrivateType logger = new PrivateType(typeof(Logger));
            string appId = "104DA020-2B92-48F1-BB0B-01C743615340".ToLower();
            string message = (string) logger.InvokeStatic("CreateLogItem", LogLevel.Info, appId, "johndoe", DateTime.Now, "TestMessage");
            bool isMatch = logItemRegex.IsMatch(message);
            Assert.IsTrue(isMatch);
        }

        [TestMethod]
        public void CreateLogItem_InvalidAppIdShouldReturnStringInInCorrectLogFormat()
        {
            PrivateType logger = new PrivateType(typeof(Logger));
            
            // Invalid app id because 'z' is not allowed in GUID
            string appId = "104DA020-2B92-48F1-BB0B-01C74361534Z".ToLower();
            string message = (string)logger.InvokeStatic("CreateLogItem", LogLevel.Info, appId, "johndoe", DateTime.Now, "TestMessage");
            bool isMatch = logItemRegex.IsMatch(message);
            Assert.IsFalse(isMatch);
        }

        [TestMethod]
        public void CreateLogItem_UsernameWithSpaceShouldMatchTheLogFormat()
        {
            PrivateType logger = new PrivateType(typeof(Logger));
            string appId = "104DA020-2B92-48F1-BB0B-01C743615340".ToLower();
            string message = (string)logger.InvokeStatic("CreateLogItem", LogLevel.Info, appId, "john doe", DateTime.Now, "TestMessage");
            bool isMatch = logItemRegex.IsMatch(message);
            Assert.IsTrue(isMatch);
        }
    }
}
