using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClockAlert.Modules;

namespace ClockAlertTest
{
    [TestClass]
    public class TestTimeKeeper
    {
        [TestMethod]
        public void IsItTime_WhenMinuteAndSecondAreZero_ShouldReturnTrue()
        {
            DateTime now = new DateTime(1,1,1,0,0,0);
            TimeKeeper timeKeeper = new TimeKeeper();
            bool isItTime = timeKeeper.IsItTime(now);
            Assert.IsTrue(isItTime);
        }

        [TestMethod]
        public void IsItTime_WhenMinuteIsNotZeroAndSecondIsZero_ShouldReturnFalse()
        {
            DateTime now = new DateTime(1, 1, 1, 0, 1, 0);
            TimeKeeper timeKeeper = new TimeKeeper();
            bool isItTime = timeKeeper.IsItTime(now);
            Assert.IsFalse(isItTime);
        }

        [TestMethod]
        public void IsItTime_WhenMinuteIsZeroAndSecondIsNotZero_ShouldReturnFalse()
        {
            DateTime now = new DateTime(1, 1, 1, 0, 0, 1);
            TimeKeeper timeKeeper = new TimeKeeper();
            bool isItTime = timeKeeper.IsItTime(now);
            Assert.IsFalse(isItTime);
        }

        [TestMethod]
        public void IsItTime_WhenMinuteAndSecondAreNonZero_ShouldReturnFalse()
        {
            DateTime now = new DateTime(1, 1, 1, 0, 1, 1);
            TimeKeeper timeKeeper = new TimeKeeper();
            bool isItTime = timeKeeper.IsItTime(now);
            Assert.IsFalse(isItTime);
        }

        [TestMethod]
        public void IsBetween_NowBetweenStartAndEnd_ShouldReturnTrue()
        {
            DateTime start = new DateTime(1, 1, 1, 0, 0, 0);
            DateTime now = new DateTime(1, 1, 1, 1, 1, 1);
            DateTime end = new DateTime(1, 1, 1, 23, 59, 59);
            TimeKeeper timeKeeper = new TimeKeeper();
            bool isBetween = timeKeeper.IsBetween(now,start,end);
            Assert.IsTrue(isBetween);
        }

        [TestMethod]
        public void IsBetween_NowBeforeStart_ShouldReturnFalse()
        {
            DateTime now = new DateTime(1, 1, 1, 0, 0, 0);
            DateTime start = new DateTime(1, 1, 1, 1, 1, 1);
            DateTime end = new DateTime(1, 1, 1, 23, 59, 59);
            TimeKeeper timeKeeper = new TimeKeeper();
            bool isBetween = timeKeeper.IsBetween(now, start, end);
            Assert.IsFalse(isBetween);
        }

        [TestMethod]
        public void IsBetween_NowAfterEnd_ShouldReturnFalse()
        {
            DateTime start = new DateTime(1, 1, 1, 0, 0, 0);
            DateTime end = new DateTime(1, 1, 1, 0, 59, 59);
            DateTime now = new DateTime(1, 1, 1, 1, 1, 1);
            TimeKeeper timeKeeper = new TimeKeeper();
            bool isBetween = timeKeeper.IsBetween(now, start, end);
            Assert.IsFalse(isBetween);
        }
    }
}
