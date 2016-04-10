using FluxDotNet.Tests.Mocks;
using Moq;
using NUnit.Framework;

namespace FluxDotNet.Tests
{
    [TestFixture]
    public class StoreTests
    {
        private Mock<IDispatcher> _dispatcher;
        private IStore _store;

        [SetUp]
        public void SetUp()
        {
            _dispatcher = new Mock<IDispatcher>();

            Flux.Dispatcher = _dispatcher.Object;

            _store = new TestStore();
        }

        [TearDown]
        public void TearDown()
        {
            _store = null;
            _dispatcher = null;
        }

        [Test]
        public void EmitChangeTest()
        {
            _store.EmitChange();

            _dispatcher.Verify(x => x.Dispatch(It.IsAny<ChangePayload>()), Times.Once);
        }
    }
}
