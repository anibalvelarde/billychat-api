using Microsoft.VisualStudio.TestTools.UnitTesting;
using BillyChat.API.Domain.Models;
using System;
using BillyChat.API.Domain.Models.Enums;

namespace BillyChat.API.Tests
{
    [TestClass]
    public class PatientModelTests
    {
        [TestMethod]
        public void Should_have_created_on_value_After_instantiated()
        {
            // arrange

            // act
            var patient = new Patient();

            // assert
            Assert.IsInstanceOfType(patient.CreatedOn, typeof(DateTime));
            Assert.AreEqual(0, patient.Family.Count);
        }
    }
}
