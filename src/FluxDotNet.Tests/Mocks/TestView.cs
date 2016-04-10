namespace FluxDotNet.Tests.Mocks
{
    class TestView : IFluxViewFor<TestStore>
    {
        public string TestResult { get; private set; }

        public TestView()
        {
            this.OnChange(UpdateTestResult);
        }

        private void UpdateTestResult(TestStore store)
        {
            TestResult = store.TestResult;
        }
    }
}
