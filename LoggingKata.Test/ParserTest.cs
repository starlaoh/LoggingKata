﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LoggingKata.Test
{
    [TestFixture]
    public class TacoParserTestFixture
    {
        [Test]
        public void ShouldReturnNullForNullOrEmptyString()
        {
            //Arrange
            var empty = "";
            string nul = null;
            var parser = new TacoParser();

            //Act
            var emptyResult = parser.Parse(empty);
            var nullResult = parser.Parse(nul);

            //Assert
            Assert.IsNull(emptyResult, "Should return null for empty strings");
            Assert.IsNull(nullResult, "Should return null for null strings");
        }

        [Test]
        public void ShouldReturnNullForNoLatAndLon()
        {
            //Arrange
            var line = "-83.2342, Testing";
            var parser = new TacoParser();

            //Act
            var result = parser.Parse(line);

            //Assert
            Assert.IsNull(result, "Should return null unless we have both the lat and long");
        }
    }
}
