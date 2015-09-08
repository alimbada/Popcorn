﻿using NUnit.Framework;
using Popcorn.Converters;
using System.Windows;

namespace Popcorn.Tests.Converters
{
    [TestFixture]
    public class MultiBooleanToVisibilityConverterTest
    {
        private MultiBooleanToVisibilityConverter _converter;

        [TestFixtureSetUp]
        public void InitializeConverter()
        {
            _converter = new MultiBooleanToVisibilityConverter();
        }

        [Test]
        public void Convert_AllTrue_ReturnsVisible()
        {
            object[] trueBooleans = { true, true, true };
            Assert.AreEqual(
                _converter.Convert(trueBooleans, null, null, null), Visibility.Visible);
        }

        [Test]
        public void Convert_AllFalse_ReturnsCollapsed()
        {
            object[] falseBooleans = { false, false, false };
            Assert.AreEqual(
                _converter.Convert(falseBooleans, null, null, null), Visibility.Collapsed);
        }

        [Test]
        public void Convert_NotAllTrue_ReturnsCollapsed()
        {
            object[] notAllTrueBooleans = { true, false, true };
            Assert.AreEqual(
                _converter.Convert(notAllTrueBooleans, null, null, null), Visibility.Collapsed);
        }
    }
}
