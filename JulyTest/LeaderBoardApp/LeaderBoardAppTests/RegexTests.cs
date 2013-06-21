using System;
using LeaderBoardApp.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeaderBoardAppTests
{
    [TestClass]
    public class RegexTest
    {
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
        public void CheckRegexAgeValid()
        {
            for (int i = 0; i < 10000; i++)
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

        [TestMethod]
        public void CheckRegexNumberValid()
        {
            Assert.IsTrue(CheckRegex.IsValidNumber("40000000"));
        }

        [TestMethod]
        public void CheckRegexNumberNoNumber()
        {
            Assert.IsFalse(CheckRegex.IsValidNumber(""));
        }

        [TestMethod]
        public void CheckRegexNumberName()
        {
            Assert.IsFalse(CheckRegex.IsValidNumber("john"));
        }
    }
}
