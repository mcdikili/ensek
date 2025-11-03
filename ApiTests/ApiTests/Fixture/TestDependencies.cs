using ApiTests.Models;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTests.Fixture
{
    public static class TestDependencies
    {
        /// <summary>
        /// Configures and returns an Autofac container builder.
        /// </summary>
        /// <returns>An Autofac container builder.</returns>
        public static ContainerBuilder GetContainerBuilder()
        {
            var builder = new ContainerBuilder();

            // Register the Settings class
            builder.RegisterInstance(GetSettings())
                   .As<Settings>()
                   .SingleInstance();

            // Register other dependencies here if needed
            // Example: builder.RegisterType<SomeService>().As<ISomeService>();

            return builder;
        }

        /// <summary>
        /// Loads and returns the Settings object.
        /// </summary>
        /// <returns>A populated Settings object.</returns>
        private static Settings GetSettings()
        {
            // Replace with actual logic to load settings (e.g., from appsettings.json or environment variables)
            return new Settings
            {
                BaseUrl = "https://qacandidatetest.ensek.io",
                Username = "test",
                Password = "testing"
            };
        }
    }
}
