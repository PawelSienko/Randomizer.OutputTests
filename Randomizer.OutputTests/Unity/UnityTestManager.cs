using System;
using Common.Core.Validation;
using Microsoft.Practices.Unity;
using Randomizer.OutputTests.Base;
using Randomizer.OutputTests.TestManagers;
using Randomizer.OutputTests.Tests.AlphanumericChar;
using Randomizer.OutputTests.Tests.AlphanumericString;
using Randomizer.OutputTests.Tests.String;

namespace Randomizer.OutputTests.Unity
{
    public class UnityTestManager : UnityBase
    {
        // ReSharper disable once InconsistentNaming
        private readonly int executionNumber;

        public UnityTestManager(UnityContainer unityContainer, int executionNumber) : base(unityContainer)
        {
            Validator.ValidateNull(unityContainer);
            Validator.ValidateCondition(executionNumber, item => item > 0);
            this.executionNumber = executionNumber;
        }

        public override void RegisterTypes()
        {
            unityContainer.RegisterType<TestManagerBase<float>, FloatTestManager>(new InjectionConstructor(unityContainer.ResolveAll<OutputTestBase<float>>(), executionNumber));
            unityContainer.RegisterType<TestManagerBase<int>, IntegerTestManager>(new InjectionConstructor(unityContainer.ResolveAll<OutputTestBase<int>>(), executionNumber));
            unityContainer.RegisterType<TestManagerBase<decimal>, DecimalTestManager>(new InjectionConstructor(unityContainer.ResolveAll<OutputTestBase<decimal>>(), executionNumber));
            unityContainer.RegisterType<TestManagerBase<long>, LongTestManager>(new InjectionConstructor(unityContainer.ResolveAll<OutputTestBase<long>>(), executionNumber));
            unityContainer.RegisterType<TestManagerBase<short>, ShortTestManager>(new InjectionConstructor(unityContainer.ResolveAll<OutputTestBase<short>>(), executionNumber));
            unityContainer.RegisterType<TestManagerBase<double>, DoubleTestManager>(new InjectionConstructor(unityContainer.ResolveAll<OutputTestBase<double>>(), executionNumber));
            unityContainer.RegisterType<TestManagerBase<DateTime>, DateTimeTestManager>(new InjectionConstructor(unityContainer.ResolveAll<OutputTestBase<DateTime>>(), executionNumber));

            unityContainer.RegisterType<TestManagerBase<object>, AlphanumericStringTestManager>(new InjectionConstructor(unityContainer.ResolveAll<AlphanumericStringOutputTest>(), executionNumber));

            unityContainer.RegisterType<TestManagerBase<object>, StringTestManager>(
                new InjectionConstructor(unityContainer.ResolveAll<StringOutputTest>(), executionNumber));

            unityContainer.RegisterType<TestManagerBase<char>, AlphanumericCharTestManager>(new InjectionConstructor(unityContainer.ResolveAll<AlphanumericCharOutputTest>(), executionNumber));
        }
    }
}
