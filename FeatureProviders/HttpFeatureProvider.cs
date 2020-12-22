﻿using FeatureToggle;
using FeatureToggle.Internal;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;

namespace BlazorTest.FeatureProviders
{
    public class HttpFeatureProvider : IBooleanToggleValueProvider, IDateTimeToggleValueProvider, ITimePeriodProvider, IDaysOfWeekToggleValueProvider, IAssemblyVersionProvider
    {
        IConfigurationRoot _configuration;

        public IConfigurationRoot Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    var builder = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory).AddJsonFile("appSettings.json");
                    Configuration = builder.Build();
                }

                return _configuration;
            }
            set
            {
                _configuration = value;
            }
        }

        public bool EvaluateBooleanToggleValue(IFeatureToggle toggle)
        {
            var client = new RestClient("https://localhost:44325/");
            var response = client.Get<JsonEnabledResponse>(new RestRequest("api/configuration/feature", Method.GET));
            var result = response.Data;
            return result.Enabled;
        }

        public DateTime EvaluateDateTimeToggleValue(IFeatureToggle toggle)
        {
            throw new NotImplementedException();
        }

        public Tuple<DateTime, DateTime> EvaluateTimePeriod(IFeatureToggle toggle)
        {
            throw new NotImplementedException();
        }

        public Version EvaluateVersion(IFeatureToggle toggle)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DayOfWeek> GetDaysOfWeek(IFeatureToggle toggle)
        {
            throw new NotImplementedException();
        }
    }
}
