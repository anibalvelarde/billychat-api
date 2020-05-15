using Microsoft.VisualStudio.TestTools.UnitTesting;
using BillyChat.API.Domain.Models;
using System;
using BillyChat.API.Domain.Models.Enums;

namespace BillyChat.API.Tests
{
    [TestClass]
    public class DoctorModelTests
    {
        [TestMethod]
        public void Should_have_created_on_value_After_instantiated()
        {
            // arrange

            // act
            var doc = new Doctor();

            // assert
            Assert.IsInstanceOfType(doc.CreatedOn, typeof(DateTime));
            Assert.AreEqual(0, doc.Specialties.Count);
        }
    }
}
