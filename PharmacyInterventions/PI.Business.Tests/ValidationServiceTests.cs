using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PI.Business.Tests
{
    [TestClass]
    public class ValidationServiceTests
    {
        private ValidationService _serviceUnderTest;

        [TestInitialize]
        public void Setup()
        {
            _serviceUnderTest = new ValidationService();
        }

        /// <summary>
        /// check that numbers we know are good pass validation
        /// </summary>
        [TestMethod]
        public void ValidateNhi_ValidNumbers_AllNumbersValid()
        {
            // arrange
            bool result = true;
            var listOfNhis = new List<string>
                                 {
                                     "EPT6335","CGC2720","prp1660","ZZZ9994","HUX8660"
                                 };

            // act
            listOfNhis.ForEach(number => result = result && _serviceUnderTest.ValidateNhi(number));

            // assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// check that a number with invalid checksum will fail
        /// </summary>
        [TestMethod]
        public void ValidateNhi_InvalidNumber_FailChecksum()
        {
            var result = _serviceUnderTest.ValidateNhi("ABC1234");

            Assert.IsFalse(result);
        }
        /// <summary>
        /// check that the validation is case insensitive
        /// </summary>
        [TestMethod]
        public void ValidateNhi_ValidNumber_VaryingCase()
        {
            var result = _serviceUnderTest.ValidateNhi("zZz9994");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateNhi_InvalidNumber_NumberContainsI()
        {
            var result = _serviceUnderTest.ValidateNhi("AIB1234");

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void ValidateNhi_InvalidNumber_NumberContainsO()
        {
            var result = _serviceUnderTest.ValidateNhi("AOB1234");

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void ValidateNhi_InvalidNumber_NumberTooShort()
        {
            var result = _serviceUnderTest.ValidateNhi("PRP166");

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void ValidateNhi_InvalidNumber_NumberTooLong()
        {
            var result = _serviceUnderTest.ValidateNhi("PRP16601");

            Assert.IsFalse(result);
        }
    }
}
