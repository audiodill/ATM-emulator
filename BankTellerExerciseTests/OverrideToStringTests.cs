using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankTellerExercise.Classes;

namespace BankTellerExerciseTests
{
    [TestClass]
    public class OverrideToStringTests
    {
        [TestMethod]
        public void CheckToSeeIfBothTheDollarAndCentsCome()
        {
            DollarAmount x = new DollarAmount(250);
            Assert.AreEqual("$2.50", x.ToString());
        }

        [TestMethod]
        public void CheckToSeeIfOnlyCentsComeUp()
        {
            DollarAmount x = new DollarAmount(25);
            Assert.AreEqual("$0.25", x.ToString());
        }

        [TestMethod]
        public void CheckToSeeIfOnlyDollarComesUp()
        {
            DollarAmount x = new DollarAmount(300);
            Assert.AreEqual("$3.00", x.ToString());
        }

        [TestMethod]
        public void CheckToMakeSureOneDigitCentWorksProperly()
        {
            DollarAmount x = new DollarAmount(1);
            Assert.AreEqual("$0.01", x.ToString());
        }
    }
}
