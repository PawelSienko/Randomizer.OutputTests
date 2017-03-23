using Common.Core.Validation;
using Microsoft.Practices.Unity;
using Randomizer.Interfaces.ReferenceTypes;
using Randomizer.Interfaces.ValueTypes;
using Randomizer.Types;

namespace Randomizer.OutputTests.Unity
{
    public class UnityRandomGenerators : UnityBase
    {
        public UnityRandomGenerators(UnityContainer unityContainer) : base(unityContainer)
        {
            Validator.ValidateNull(unityContainer);
        }

        public override void RegisterTypes()
        {
            unityContainer.RegisterType<IRandomFloat, RandomFloatGenerator>(new InjectionConstructor());
            unityContainer.RegisterType<IRandomInteger, RandomIntegerGenerator>(new InjectionConstructor());
            unityContainer.RegisterType<IRandomDecimal, RandomDecimalGenerator>(new InjectionConstructor());
            unityContainer.RegisterType<IRandomLong, RandomLongGenerator>(new InjectionConstructor());
            unityContainer.RegisterType<IRandomShort, RandomShortGenerator>(new InjectionConstructor());
            unityContainer.RegisterType<IRandomDouble, RandomDoubleGenerator>(new InjectionConstructor());
            unityContainer.RegisterType<IRandomDateTime, RandomDateTimeGenerator>(new InjectionConstructor());

            unityContainer.RegisterType<IRandomAlphanumericString, RandomAlphanumericStringGenerator>(new InjectionConstructor());
            unityContainer.RegisterType<IRandomString, RandomStringGenerator>(new InjectionConstructor());
            unityContainer.RegisterType<IRandomCharacter, RandomAlphanumericCharGenerator>(new InjectionConstructor());
        }
    }
}
