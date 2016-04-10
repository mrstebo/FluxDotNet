using FluxDotNet.Tests.Mocks;
using NUnit.Framework;

namespace FluxDotNet.Tests
{
    [TestFixture]
    public class FluxViewForExtensionsTests
    {
        private IFluxViewFor<TestStore> _view;

        [SetUp]
        public void SetUp()
        {
            var dispatcher = Flux.Dispatcher;
            var store = new TestStore(dispatcher);

            Flux.StoreResolver.Register(store);

            _view = new TestView();
        }

        [TearDown]
        public void TearDown()
        {
            _view = null;
        }

        [Test]
        public void DispatchShouldCallOnChangeAndUpdateTestResult()
        {
            var payload = new TestAction {Result = "Changed"};

            _view.Dispatch(payload);

            Assert.AreEqual(payload.Result, ((TestView)_view).TestResult);
        }

        [Test]
        public void EmitChangeShouldDoNothing()
        {
            _view.EmitChange();

            Assert.IsNull(((TestView) _view).TestResult);
        }
    }
}
