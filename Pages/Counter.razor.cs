using Microsoft.AspNetCore.Components;

namespace BlazorTest.Pages
{
    public partial class Counter: ComponentBase
    {
        [Inject]
        private Features.Counter CounterFeature { get; set; }
        private int currentCount = 0;

        public Counter()
        {
        }

        public void IncrementCount()
        {
            currentCount++;
        }
    }
}
