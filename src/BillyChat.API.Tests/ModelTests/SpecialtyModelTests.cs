using Microsoft.VisualStudio.TestTools.UnitTesting;
using BillyChat.API.Domain.Models;
using System;
using BillyChat.API.Domain.Models.Enums;

namespace BillyChat.API.Tests
{
    [TestClass]
    public class SpecialtyModelTests
    {
        [TestMethod]
        public void Should_have_created_on_value_After_instantiated()
        {
            // arrange

            // act
            var spec = new Specialty();

            // assert
            Assert.IsFalse(spec.IsVerified);
            Assert.AreEqual(string.Empty, spec.VerifiedBy);
            Assert.AreEqual(DateTime.MinValue, spec.VerifiedOnDate);
        }

        [TestMethod]
        public void Should_be_verified_only_once()
        {
            // arrange
            var s = new Specialty();

            // act
            s.SetAsVerified(
                MakeFakeInstitution(),
                "Test Method"
            );

            // assert
            Assert.IsTrue(s.IsVerified);
            Assert.AreEqual(
                DateTime.UtcNow.ToShortDateString(),
                s.VerifiedOnDate.DateTime.ToShortDateString()
            );
        }

        [TestMethod]
        public void Should_throw_when_already_verified()
        {
            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                // arrange
                var s = new Specialty();
                s.SetAsVerified(
                    MakeFakeInstitution(),
                    "Already Verified"
                );

                // act
                s.SetAsVerified(MakeFakeInstitution(), "Re-Verified");
            });
        }

        private Institution MakeFakeInstitution()
        {
            return new Institution()
            {
                Id = 1,
                Address = "some address",
                Name = "some institution",
                Phone = "555-555-5555",
                Url = "www.someurl.com"
            };
        }
    }
}
