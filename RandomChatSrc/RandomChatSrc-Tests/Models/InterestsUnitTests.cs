using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomChatSrc.Models;
using System;

namespace RandomChatTests.Models
{
    [TestClass]
    public class InterestUnitTests
    {
        [TestMethod]
        public void TestInterestConstructor_SetsInterestName()
        {
            // Arrange
            string interestName = "Music";

            // Act
            var interest = new Interest(interestName);

            // Assert
            Assert.AreEqual(interestName, interest.InterestName);
        }

        [TestMethod]
        public void TestEquals_TwoInterestsWithSameName_ReturnsTrue()
        {
            // Arrange
            string interestName = "Music";
            var interest1 = new Interest(interestName);
            var interest2 = new Interest(interestName);

            // Act
            bool result = interest1.Equals(interest2);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestEquals_TwoInterestsWithDifferentNames_ReturnsFalse()
        {
            // Arrange
            var interest1 = new Interest("Music");
            var interest2 = new Interest("Art");

            // Act
            bool result = interest1.Equals(interest2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestEquals_NullObject_ReturnsFalse()
        {
            // Arrange
            var interest = new Interest("Music");

            // Act
            bool result = interest.Equals(null);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestEquals_NonInterestObject_ReturnsFalse()
        {
            // Arrange
            var interest = new Interest("Music");
            var nonInterestObject = new object();

            // Act
            bool result = interest.Equals(nonInterestObject);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestEquals_SameInterestObject_ReturnsTrue()
        {
            // Arrange
            var interest = new Interest("Music");

            // Act
            bool result = interest.Equals(interest);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
