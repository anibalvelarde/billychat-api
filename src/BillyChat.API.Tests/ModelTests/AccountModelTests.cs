using Microsoft.VisualStudio.TestTools.UnitTesting;
using BillyChat.API.Domain.Models;
using System;
using BillyChat.API.Domain.Models.Enums;

namespace BillyChat.API.Tests.Models
{
    [TestClass]
    public class AccountModelTests
    {
        [TestMethod]
        public void Should_have_created_on_value_After_instantiated()
        {
            // arrange

            // act
            var account = new Account();

            // assert
            Assert.IsInstanceOfType(account.CreatedOn, typeof(DateTime));
            Assert.AreEqual(AccountType.Root, account.Type);
        }
    }
}
