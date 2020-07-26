using Microsoft.VisualStudio.TestTools.UnitTesting;
using BillyChat.API.Domain.Models;
using System;

namespace BillyChat.API.Tests.Models
{
    [TestClass]
    public class UserModelTests
    {
        [TestMethod]
        public void Should_have_correct_values_When_instantiated()
        {
            // arrange

            // act
            var user = new User();

            // assert
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void Should_have_created_on_value_After_instantiated()
        {
            // arrange

            // act
            var user = new User();

            // assert
            Assert.IsInstanceOfType(user.CreatedOn, typeof(DateTime));
        }
    }
}
