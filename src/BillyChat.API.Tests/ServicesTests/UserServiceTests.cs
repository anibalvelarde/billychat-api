using System;
using System.Threading.Tasks;
using BillyChat.API.Domain.Exceptions;
using BillyChat.API.Domain.Models;
using BillyChat.API.Domain.Repositories;
using BillyChat.API.Domain.Services;
using BillyChat.API.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BillyChat.API.Tests.Services
{
    [TestClass]
    public class UserServiceTests
    {
        [DataRow(new object[] {""})]
        [DataRow(new object[] {null})]
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public async Task Should_Throw_When_Name_IsNot_Valid(object[] badData)
        {
            // arrange...
            var fakeRepo = Mock.Of<IUserRepository>();
            IUserService svc = new UserService(fakeRepo);

            // act...
            await svc.CreateAsync((string)badData[0], "some-phone", "some-email"); 
        }

        [DataRow(new object[] {""})]
        [DataRow(new object[] {null})]
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public async Task Should_Throw_When_Phone_IsNot_Valid(object[] badData)
        {
            // arrange...
            var fakeRepo = Mock.Of<IUserRepository>();
            IUserService svc = new UserService(fakeRepo);

            // act...
            await svc.CreateAsync((string)badData[0], "some-phone", "some-email"); 
        }

        [DataRow(new object[] {""})]
        [DataRow(new object[] {null})]
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public async Task Should_Throw_When_Email_IsNot_Valid(object[] badData)
        {
            // arrange...
            var fakeRepo = Mock.Of<IUserRepository>();
            IUserService svc = new UserService(fakeRepo);

            // act...
            await svc.CreateAsync("some-name", "some-phone", (string)badData[0]); 
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateResourceException))]
        public async Task Should_Throw_When_Aonther_User_Has_Same_Phone()
        {
            // arrange...
            string expPhone = "some-phone";
            var mockRepo = new Mock<IUserRepository>(MockBehavior.Strict);
            mockRepo.Setup(_ => _.ExistsWtihPhoneAsync(expPhone)).ReturnsAsync(false);
            mockRepo.Setup(_ => _.ExistsWithEmailAsync(It.IsAny<string>())).ReturnsAsync(true);
            IUserService svc = new UserService(mockRepo.Object);

            try
            {
                // act...
                await svc.CreateAsync("some-name", expPhone, "some-email");
            }
            finally
            {
                // Verify
                mockRepo.VerifyAll();                
            }

        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateResourceException))]
        public async Task Should_Throw_When_Aonther_User_Has_Same_Email()
        {
            // arrange...
            string expEmail = "some-email";
            var mockRepo = new Mock<IUserRepository>(MockBehavior.Strict);
            mockRepo.Setup(_ => _.ExistsWithEmailAsync(expEmail)).ReturnsAsync(true);
            mockRepo.Setup(_ => _.ExistsWtihPhoneAsync(It.IsAny<string>())).ReturnsAsync(false);
            IUserService svc = new UserService(mockRepo.Object);

            try
            {
                // act...
                await svc.CreateAsync("some-name", "some-phone", expEmail);
            }
            finally
            {
                // Verify
                mockRepo.VerifyAll();                
            }

        }

        [TestMethod]
        public async Task Should_Update_Existing_User_Correctly()
        {
            // TODO: Complete this test...
            Assert.Inconclusive();
            // // arrange...
            // User expUser = Mock.Of<User>();
            // User currentUser = Mock.Of<User>(); 
            // string expName = "some-name", expEmail = "some-email", expPhone = "some-phone";
            // var mockRepo = new Mock<IUserRepository>(MockBehavior.Strict);
            // mockRepo.Setup(_ => _.CreateAsync(expName, expPhone, expEmail)).ReturnsAsync(expUser);
            // mockRepo.Setup(_ => _.ExistsWithEmailAsync(expEmail)).ReturnsAsync(false);
            // mockRepo.Setup(_ => _.ExistsWtihPhoneAsync(It.IsAny<string>())).ReturnsAsync(false);
            // IUserService svc = new UserService(mockRepo.Object);

            // // act...
            // var result = await svc.UpdateAsync(expUser, currentUser);

            // // assert & verify...
            // Assert.AreSame(expUser, result);
            // mockRepo.VerifyAll();
        }
    }
}