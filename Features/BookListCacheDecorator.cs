using FeatureToggle;
using System;

namespace BlazorTest.Features
{
    public class BookListCacheDecorator : FixedTimeCacheDecorator
    {
        public BookListCacheDecorator(IFeatureToggle toggleToWrap, TimeSpan cacheDuration, Func<DateTime> alternativeNowProvider = null) : base(toggleToWrap, cacheDuration, alternativeNowProvider)
        {
        }
    }
}
