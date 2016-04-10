namespace FluxDotNet.Tests.Mocks
{
    class TestStore : Store
    {
        public string TestResult { get; private set; }

        public TestStore()
        {
            Dispatcher.Register<TestAction>(OnTestAction);
        }

        private void OnTestAction(TestAction action)
        {
            TestResult = action.Result;

            EmitChange();
        }
    }
}
