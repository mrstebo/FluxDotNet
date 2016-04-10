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
            var store = new TestStore();

            Assert.DoesNotThrow(() => _storeResolver.Register(store));
        }

        [Test]
        public void GetStoreShouldReturnRegisteredStore()
        {
            var store = new TestStore();

            _storeResolver.Register(store);

            var result = _storeResolver.GetStore<TestStore>();

            Assert.AreSame(store, result);
        }

        [Test]
        public void GetStoreShouldReturnLastRegisteredStore()
        {
            var store1 = new TestStore();
            var store2 = new TestStore();

            _storeResolver.Register(store1);
            _storeResolver.Register(store2);

            var result = _storeResolver.GetStore<TestStore>();

            Assert.AreSame(store2, result);
        }

        [Test]
        public void GetStoreWithUnregisteredStoreShouldThrowStoreNotRegisteredException()
        {
            Assert.Throws<NullStoreException>(() => _storeResolver.GetStore<TestStore>());
        }
    }
}
