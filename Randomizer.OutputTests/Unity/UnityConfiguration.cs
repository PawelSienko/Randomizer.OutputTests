using System.Configuration;
using Common.Core.Validation;
using Microsoft.Practices.Unity;

namespace Randomizer.OutputTests.Unity
{
    public static class UnityConfiguration
    {
        // ReSharper disable once InconsistentNaming
        private static UnityContainer unity;

        public static void Configure()
        {
            string basePath = ConfigurationManager.AppSettings["basePath"];
            int executionNumber = int.Parse(ConfigurationManager.AppSettings["executionNumber"]);

            Validator.ValidateNullOrEmpty(basePath);

            unity = new UnityContainer();

            UnityLoggers unityLoggers = new UnityLoggers(unity, basePath);
            unityLoggers.RegisterTypes();

            UnityOutputTests unityOutputTests = new UnityOutputTests(unity);
            unityOutputTests.RegisterTypes();

            UnityRandomGenerators unityRandomGenerators = new UnityRandomGenerators(unity);
            unityRandomGenerators.RegisterTypes();

            unity.RegisterType<IConsoleManager, ConsoleManager>();

            UnityTestManager unityTestManager = new UnityTestManager(unity, executionNumber);
            unityTestManager.RegisterTypes();
        }

        public static UnityContainer Get => unity;
    }
}
