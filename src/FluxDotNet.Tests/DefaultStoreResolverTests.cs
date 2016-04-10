using FluxDotNet.Tests.Mocks;
using NUnit.Framework;

namespace FluxDotNet.Tests
{
    [TestFixture]
    public class DefaultStoreResolverTests
    {
        private IStoreResolver _storeResolver;

        [SetUp]
        public void SetUp()
        {
            _storeResolver = new DefaultStoreResolver();
        }

        [TearDown]
        public void TearDown()
        {
            _storeResolver = null;
        }

        [Test]
        public void RegisterShouldNotThrowException()
        {
            var dispatcher = new Dispatcher();
            var store = new TestStore(dispatcher);

            Assert.DoesNotThrow(() => _storeResolver.Register(store));
        }

        [Test]
        public void GetStoreShouldReturnRegisteredStore()
        {
            var dispatcher = new Dispatcher();
            var store = new TestStore(dispatcher);

            _storeResolver.Register(store);

            var result = _storeResolver.GetStore<TestStore>();

            Assert.AreSame(store, result);
        }

        [Test]
        public void GetStoreShouldReturnLastRegisteredStore()
        {
            var dispatcher = new Dispatcher();
            var store1 = new TestStore(dispatcher);
            var store2 = new TestStore(dispatcher);

            _storeResolver.Register(store1);
            _storeResolver.Register(store2);

            var result = _storeResolver.GetStore<TestStore>();

            Assert.AreSame(store2, result);
        }

        [Test]
        public void GetStoreWithUnregisteredStoreShouldThrowStoreNotRegisteredException()
        {
            Assert.Throws<StoreNotRegisteredException>(() => _storeResolver.GetStore<TestStore>());
        }
    }
}
