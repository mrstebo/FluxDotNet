namespace FluxDotNet.Tests.Mocks
{
    class TestStore : Store
    {
        public string TestResult { get; private set; }

        public TestStore(IDispatcher dispatcher) 
            : base(dispatcher)
        {
            dispatcher.Register<TestAction>(OnTestAction);
        }

        private void OnTestAction(TestAction action)
        {
            TestResult = action.Result;

            EmitChange();
        }
    }
}
