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
            Assert.IsNull(account.User);
            Assert.AreEqual(AccountType.NotSet, account.Type);
            Assert.IsFalse(account.IsValid());
        }

        [DataRow(AccountType.Admin)]
        [DataRow(AccountType.Client)]
        [DataRow(AccountType.Advisor)]
        [TestMethod]
        public void Should_Have_Created_WithUser_And_Correct_AccountType(AccountType expAcctType)
        {
            // arrange
            var aUser = Mock.Of<User>();

            // act
            var accountWithUser = Account
                .CreateAccount(expAcctType)
                .WithUser(aUser);

            // assert
            Assert.AreEqual(expAcctType, accountWithUser.Type);
        }

        [TestMethod]
        public void Should_Have_Created_WithUser_And_Intended_User()
        {
            // arrange
            var aUser = Mock.Of<User>();
            var expAcctType = AccountType.Client;

            // act
            var accountWithUser = Account
                .CreateAccount(expAcctType)
                .WithUser(aUser);

            // assert
            Assert.AreSame(aUser, accountWithUser.User);
        }

                [TestMethod]
        public void Should_Have_Created_WithUser_Then_IsValid()
        {
            // arrange
            var aUser = Mock.Of<User>();
            var expAcctType = AccountType.Client;

            // act
            var accountWithUser = Account
                .CreateAccount(expAcctType)
                .WithUser(aUser);

            // assert
            Assert.IsTrue(accountWithUser.IsValid());
        }
    }
}
