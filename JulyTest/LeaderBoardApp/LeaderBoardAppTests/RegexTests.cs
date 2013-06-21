using System;
using LeaderBoardApp.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeaderBoardAppTests
{
    [TestClass]
    public class RegexTest
    {
        #region IsValidAges Tests
        [TestMethod]
        public void CheckRegexAgeValid()
        {
            for (int i = 0; i < 150; i++)
            {
                Assert.IsTrue(CheckRegex.IsValidAge(i.ToString()));
            }
        }

        [TestMethod]
        public void CheckRegexAgeEmpty()
        {
            Assert.IsFalse(CheckRegex.IsValidAge(""));
        }

        [TestMethod]
        public void CheckRegexAgeAsWord()
        {
            Assert.IsFalse(CheckRegex.IsValidAge("nine"));
        }

        [TestMethod]
        public void CheckRegexAgeWithSpace()
        {
            Assert.IsFalse(CheckRegex.IsValidAge("1 3"));
        }
        #endregion

        #region IsValidGuardian Tests
        [TestMethod]
        public void CheckRegexGuardianValidTwoNames()
        {
            Assert.IsTrue(CheckRegex.IsValidGuardian("jill smith"));
        }

        [TestMethod]
        public void CheckRegexGuardianValidTwoNamesJoinedLast()
        {
            Assert.IsTrue(CheckRegex.IsValidGuardian("jill smith-smith"));
        }

        [TestMethod]
        public void CheckRegexGuardianInvalidTooManyNames()
        {
            Assert.IsFalse(CheckRegex.IsValidGuardian("jill smith dude"));
        }

        [TestMethod]
        public void CheckRegexGuardianValidSingleName()
        {
            Assert.IsTrue(CheckRegex.IsValidGuardian("jill"));
        }
        #endregion

        #region IsValidName Tests
        [TestMethod]
        public void CheckRegexNameValid()
        {
            Assert.IsTrue(CheckRegex.IsValidName("John"));
        }

        [TestMethod]
        public void CheckRegexNameEmpty()
        {
            Assert.IsFalse(CheckRegex.IsValidName(""));
        }

        [TestMethod]
        public void CheckRegexNameWithSpace()
        {
            Assert.IsFalse(CheckRegex.IsValidName("Joh n"));
        }

        [TestMethod]
        public void CheckRegexNameWithNumber()
        {
            Assert.IsFalse(CheckRegex.IsValidName("J0hn"));
        }

        [TestMethod]
        public void CheckRegexNameWithDash()
        {
            Assert.IsTrue(CheckRegex.IsValidName("Cloud-Lockheart"));
        }
        #endregion

        #region IsValidNumber Tests
        [TestMethod]
        public void CheckRegexNumberValid()
        {
            Assert.IsTrue(CheckRegex.IsValidContact("40000000"));
        }

        [TestMethod]
        public void CheckRegexNumberValidWithSpace()
        {
            Assert.IsTrue(CheckRegex.IsValidContact("4000 0000"));
        }

        [TestMethod]
        public void CheckRegexNumberValidWithDash()
        {
            Assert.IsTrue(CheckRegex.IsValidContact("4000-0000"));
        }

        [TestMethod]
        public void CheckRegexNumberNoNumber()
        {
            Assert.IsFalse(CheckRegex.IsValidContact(""));
        }

        [TestMethod]
        public void CheckRegexNumberName()
        {
            Assert.IsFalse(CheckRegex.IsValidContact("john"));
        }
        #endregion
    }
}
