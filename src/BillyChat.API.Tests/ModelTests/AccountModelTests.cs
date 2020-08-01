using Microsoft.VisualStudio.TestTools.UnitTesting;
using BillyChat.API.Domain.Models;
using System;
using BillyChat.API.Domain.Models.Enums;
using Moq;

namespace BillyChat.API.Tests.Models
{
    [TestClass]
    public class AccountModelTests
    {
        [TestMethod]
        public void Should_Have_Created_Plain_After_Instantiated()
        {
            // arrange

            // act
            var account = new Account();

            // assert
            Assert.IsInstanceOfType(account.CreatedOn, typeof(DateTime));
            Assert.IsInstanceOfType(account.LastUpdatedOn, typeof(DateTime));
            Assert.IsNull(account.AccountNumber);
            Assert.IsNull(account.UserInfo);
            Assert.AreEqual(AccountType.NotSet, account.Type);
        }

        [TestMethod]
        public void Should_Have_Created_WithUser_When_Invoked()
        {
            // arrange
            var aUser = Mock.Of<User>();
            var expAcctType = AccountType.Client;

            // act
            var accountWithUser = Account
                .CreateAccount(expAcctType)
                .WithUser(aUser);

            // assert
            Assert.AreSame(aUser, accountWithUser.UserInfo);
            Assert.AreEqual(expAcctType, accountWithUser.Type);
        }
    }
}
