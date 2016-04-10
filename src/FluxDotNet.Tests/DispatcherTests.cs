using System;
using Moq;
using NUnit.Framework;

namespace FluxDotNet.Tests
{
    [TestFixture()]
    public class DispatcherTests
    {
        private IDispatcher _dispatcher;

        [SetUp]
        public void SetUp()
        {
            _dispatcher = new Dispatcher();
        }

        [TearDown]
        public void TearDown()
        {
            _dispatcher = null;
        }

        [Test]
        public void RegisterShouldNotThrowException()
        {
            var callback = new Action<string>(Console.WriteLine);

            Assert.DoesNotThrow(() => _dispatcher.Register(callback));
        }

        [Test]
        public void RegisterShouldAllowMultipleCallbacksWithTheSameType()
        {
            var callback1 = new Action<string>(Console.Write);
            var callback2 = new Action<string>(Console.WriteLine);

            Assert.DoesNotThrow(() =>
            {
                _dispatcher.Register(callback1);
                _dispatcher.Register(callback2);
            });
        }

        [Test]
        public void DispatchShouldInvokeRegisteredCallbacks()
        {
            var callback1 = new Mock<Action<string>>();
            var callback2 = new Mock<Action<string>>();

            _dispatcher.Register(callback1.Object);
            _dispatcher.Register(callback2.Object);
            _dispatcher.Dispatch("Test");

            callback1.Verify(x => x("Test"), Times.Once);
            callback2.Verify(x => x("Test"), Times.Once);
        }

        [Test]
        public void DispatchShouldInvokeRegisteredCallbacksOnDispatchedType()
        {
            var callback1 = new Mock<Action<string>>();
            var callback2 = new Mock<Action<int>>();

            _dispatcher.Register(callback1.Object);
            _dispatcher.Register(callback2.Object);

            _dispatcher.Dispatch("Test");

            callback1.Verify(x => x("Test"), Times.Once);
            callback2.Verify(x => x(It.IsAny<int>()), Times.Never);
        }
    }
}
