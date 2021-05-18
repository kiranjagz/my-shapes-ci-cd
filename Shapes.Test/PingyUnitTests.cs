using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Shapes.Api.Services;
using Shapes.Api.Services.Pingy;

namespace Shapes.Test
{
    public class PingyUnitTests
    {
        private IPingy _pingy;

        [SetUp]
        public void Setup()
        {
            _pingy = new PingyModule();
        }

        [Test]
        public void Return_Pong_Message()
        {
            Assert.That(_pingy.Ping(), Is.EqualTo("Pong!"));
        }
    }
}
