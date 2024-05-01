using RandomChatSrc.Models;

namespace RandomChatTests.Models
{
    [TestClass]
    public class UserUnitTests
    {
        [TestMethod]
        public void TestUserConstructor_SetsProperties()
        {
            // Arrange
            string name = "John";
            var interests = new List<Interest> { new Interest("Music"), new Interest("Art") };

            // Act
            var user = new User(name, interests);

            // Assert
            Assert.IsNotNull(user.Id);
            Assert.AreEqual(name, user.Name);
            CollectionAssert.AreEqual(interests, user.Interests);
        }

        [TestMethod]
        public void TestUserConstructor_DefaultInterests_IsEmptyList()
        {
            // Arrange
            string name = "John";

            // Act
            var user = new User(name);

            // Assert
            Assert.IsNotNull(user.Id);
            Assert.AreEqual(name, user.Name);
            Assert.IsNotNull(user.Interests);
            Assert.AreEqual(0, user.Interests.Count);
        }

        [TestMethod]
        public void TestAddInterest_AddsInterestToList()
        {
            // Arrange
            var user = new User("John");
            var interest = new Interest("Music");

            // Act
            user.AddInterest(interest);

            // Assert
            CollectionAssert.Contains(user.Interests, interest);
        }
    }
}