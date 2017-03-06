using System;
using System.Configuration;
using Common.Core.Validation;
using Microsoft.Practices.Unity;
using Randomizer.Interfaces.ReferenceTypes;
using Randomizer.Interfaces.ValueTypes;
using Randomizer.OutputTests.Base;
using Randomizer.OutputTests.TestManagers;
using Randomizer.OutputTests.Tests.AlphanumericChar;
using Randomizer.OutputTests.Tests.AlphanumericString;
using Randomizer.OutputTests.Tests.DateTime;
using Randomizer.OutputTests.Tests.Decimal;
using Randomizer.OutputTests.Tests.Double;
using Randomizer.OutputTests.Tests.Float;
using Randomizer.OutputTests.Tests.Integer;
using Randomizer.OutputTests.Tests.Long;
using Randomizer.OutputTests.Tests.Short;

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

            RegisterLoggers(basePath);
            unity.RegisterType<IRandomFloat, RandomFloatGenerator>(new InjectionConstructor());
            unity.RegisterType<IRandomInteger, RandomIntegerGenerator>(new InjectionConstructor());
            unity.RegisterType<IRandomDecimal, RandomDecimalGenerator>(new InjectionConstructor());
            unity.RegisterType<IRandomLong, RandomLongGenerator>(new InjectionConstructor());
            unity.RegisterType<IRandomShort, RandomShortGenerator>(new InjectionConstructor());
            unity.RegisterType<IRandomDouble, RandomDoubleGenerator>(new InjectionConstructor());
            unity.RegisterType<IRandomDateTime, RandomDateTimeGenerator>(new InjectionConstructor());

            unity.RegisterType<IRandomAlphanumericString, RandomAlphanumericStringGenerator>(new InjectionConstructor());
            unity.RegisterType<IRandomCharacter, RandomAlphanumericCharGenerator>(new InjectionConstructor());

            unity.RegisterType<IConsoleManager, ConsoleManager>();

            RegisterOutputTests();

            unity.RegisterType<TestManagerBase<float>, FloatTestManager>(new InjectionConstructor(unity.ResolveAll<OutputTestBase<float>>(), executionNumber));
            unity.RegisterType<TestManagerBase<int>, IntegerTestManager>(new InjectionConstructor(unity.ResolveAll<OutputTestBase<int>>(), executionNumber));
            unity.RegisterType<TestManagerBase<decimal>, DecimalTestManager>(new InjectionConstructor(unity.ResolveAll<OutputTestBase<decimal>>(), executionNumber));
            unity.RegisterType<TestManagerBase<long>, LongTestManager>(new InjectionConstructor(unity.ResolveAll<OutputTestBase<long>>(), executionNumber));
            unity.RegisterType<TestManagerBase<short>, ShortTestManager>(new InjectionConstructor(unity.ResolveAll<OutputTestBase<short>>(), executionNumber));
            unity.RegisterType<TestManagerBase<double>, DoubleTestManager>(new InjectionConstructor(unity.ResolveAll<OutputTestBase<double>>(), executionNumber));
            unity.RegisterType<TestManagerBase<DateTime>, DateTimeTestManager>(new InjectionConstructor(unity.ResolveAll<OutputTestBase<DateTime>>(), executionNumber));
            unity.RegisterType<TestManagerBase<string>, AlphanumericStringTestManager>(new InjectionConstructor(unity.ResolveAll<AlphanumericStringOutputTest>(), executionNumber));
            unity.RegisterType<TestManagerBase<char>, AlphanumericCharTestManager>(new InjectionConstructor(unity.ResolveAll<AlphanumericCharOutputTest>(), executionNumber));
        }

        private static void RegisterOutputTests()
        {
            RegisterOutputTest(typeof(OutputTestBase<float>), typeof(FloatInRangeOutputTest), typeof(IRandomFloat), "floatInRange",
                "floatInRangeLog");
            RegisterOutputTest(typeof(OutputTestBase<float>), typeof(FloatPositiveValueOutputTest), typeof(IRandomFloat), "floatPositive",
                "positiveFloatLog");
            RegisterOutputTest(typeof(OutputTestBase<float>), typeof(FloatNegativeValueOutputTest), typeof(IRandomFloat), "floatNegative",
                "negativeFloatLog");

            RegisterOutputTest(typeof(OutputTestBase<int>), typeof(IntegerInRangeOutputTest), typeof(IRandomInteger), "integerInRange",
                "intInRangeLog");
            RegisterOutputTest(typeof(OutputTestBase<int>), typeof(IntegerPositiveValueOutputTest), typeof(IRandomInteger), "integerPositive",
                "intPositiveLog");
            RegisterOutputTest(typeof(OutputTestBase<int>), typeof(IntegerNegativeValueOutputTest), typeof(IRandomInteger), "integerNegative",
                "intNegativeLog");

            RegisterOutputTest(typeof(OutputTestBase<decimal>), typeof(DecimalInRangeOutputTest), typeof(IRandomDecimal), "decimalInRange",
                "decimalInRangeLog");
            RegisterOutputTest(typeof(OutputTestBase<decimal>), typeof(DecimalPositiveValueOutputTest), typeof(IRandomDecimal), "decimalPositive",
                "decimalPositiveLog");
            RegisterOutputTest(typeof(OutputTestBase<decimal>), typeof(DecimalNegativeValueOutputTest), typeof(IRandomDecimal), "decimalNegative",
                "decimalNegativeLog");

            RegisterOutputTest(typeof(OutputTestBase<long>), typeof(LongInRangeOutputTest), typeof(IRandomLong), "longInRangte",
               "longInRangeLog");
            RegisterOutputTest(typeof(OutputTestBase<long>), typeof(LongPositiveValueOutputTest), typeof(IRandomLong), "longPositive",
                "longPositiveLog");
            RegisterOutputTest(typeof(OutputTestBase<long>), typeof(LongNegativeValueOutputTest), typeof(IRandomLong), "longNegative",
                "longNegativeLog");

            RegisterOutputTest(typeof(OutputTestBase<short>), typeof(ShortInRangeOutputTest), typeof(IRandomShort), "shortInRange",
               "shortInRangeLog");
            RegisterOutputTest(typeof(OutputTestBase<short>), typeof(ShortPositiveValueOutputTest), typeof(IRandomShort), "shortPositive",
                "shortPositiveLog");
            RegisterOutputTest(typeof(OutputTestBase<short>), typeof(ShortNegativeValueOutputTest), typeof(IRandomShort), "shortNegative",
                "shortNegativeLog");

            RegisterOutputTest(typeof(OutputTestBase<double>), typeof(DoubleInRangeOutputTest), typeof(IRandomDouble), "doubleInRange",
               "doubleInRangeLog");
            RegisterOutputTest(typeof(OutputTestBase<double>), typeof(DoublePositiveValueOutputTest), typeof(IRandomDouble), "doublePositive",
                "doublePositiveLog");
            RegisterOutputTest(typeof(OutputTestBase<double>), typeof(DoubleNegativeValueOutputTest), typeof(IRandomDouble), "doubleNegative",
                "doubleNegativeLog");

            RegisterOutputTest(typeof(OutputTestBase<DateTime>), typeof(DateTimeInRangeOutputTest), typeof(IRandomDateTime), "dateTimeInRange",
               "dateTimeInRangeLog");
            RegisterOutputTest(typeof(OutputTestBase<DateTime>), typeof(DateTimePositiveValueOutputTest), typeof(IRandomDateTime), "dateTimePositive",
                "dateTimePositiveLog");
            RegisterOutputTest(typeof(OutputTestBase<DateTime>), typeof(DateTimeNegativeValueOutputTest), typeof(IRandomDateTime), "dateTimeNegative",
                "dateTimeNegativeLog");

            RegisterOutputTest(typeof(AlphanumericStringOutputTest), typeof(AlphanumericStringDefaultLengthOutputTest), typeof(IRandomAlphanumericString), "alphanumericStringDefault",
              "stringDefaultLengthLog");
            RegisterOutputTest(typeof(AlphanumericStringOutputTest), typeof(AlphanumericStringFixedLengthOutputTest), typeof(IRandomAlphanumericString), "alphanumericStringFixed",
                "stringFixedLengthLog");
            RegisterOutputTest(typeof(AlphanumericStringOutputTest), typeof(AlphanumericStringLowercaseOutputTest), typeof(IRandomAlphanumericString), "alphanumericStringLower",
                "stringLowercaseLog");
            RegisterOutputTest(typeof(AlphanumericStringOutputTest), typeof(AlphanumericStringUppercaseOutputTest), typeof(IRandomAlphanumericString), "alphanumericStringUpper",
                "stringUppercaseLog");

            RegisterOutputTest(typeof(AlphanumericCharOutputTest), typeof(AlphanumericRandomCharOutputTest), typeof(IRandomCharacter), "charDefault",
              "randomCharacterLog");
            RegisterOutputTest(typeof(AlphanumericCharOutputTest), typeof(AlphanumericCharInRangeOutputTest), typeof(IRandomCharacter), "charInRange",
                "randomCharacterInRangeLog");
        }

        private static void RegisterOutputTest(Type baseType, Type concreteType, Type randomInputInterface,
            string registerName, string loggerRegisterName)
        {
            try
            {
                unity.RegisterType(baseType, concreteType, registerName,
                    new InjectionConstructor(new ResolvedParameter(randomInputInterface)
                        , new ResolvedParameter(typeof(ILogger), loggerRegisterName)));
            }
            catch (Exception exp)
            {
                
            }
        }

        private static void RegisterLoggers(string basePath)
        {

            RegisterLogger("floatInRangeLog", "floatInRange.log", basePath);
            RegisterLogger("positiveFloatLog", "positiveFloat.log", basePath);
            RegisterLogger("negativeFloatLog", "negativeFloat.log", basePath);

            RegisterLogger("intInRangeLog", "intInRange.log", basePath);
            RegisterLogger("intPositiveLog", "intPositive.log", basePath);
            RegisterLogger("intNegativeLog", "intNegative.log", basePath);

            RegisterLogger("decimalInRangeLog", "decimalInRange.log", basePath);
            RegisterLogger("decimalPositiveLog", "decimalPositive.log", basePath);
            RegisterLogger("decimalNegativeLog", "decimalNegative.log", basePath);

            RegisterLogger("longInRangeLog", "longInRange.log", basePath);
            RegisterLogger("longPositiveLog", "longPositive.log", basePath);
            RegisterLogger("longNegativeLog", "longNegative.log", basePath);

            RegisterLogger("shortInRangeLog", "shortInRange.log", basePath);
            RegisterLogger("shortPositiveLog", "shortPositive.log", basePath);
            RegisterLogger("shortNegativeLog", "shortNegative.log", basePath);

            RegisterLogger("doubleInRangeLog", "doubleInRange.log", basePath);
            RegisterLogger("doublePositiveLog", "doublePositive.log", basePath);
            RegisterLogger("doubleNegativeLog", "doubleNegative.log", basePath);

            RegisterLogger("dateTimeInRangeLog", "dateTimeInRange.log", basePath);
            RegisterLogger("dateTimePositiveLog", "dateTimePositive.log", basePath);
            RegisterLogger("dateTimeNegativeLog", "dateTimeNegative.log", basePath);

            RegisterLogger("stringDefaultLengthLog", "stringDefaultLength.log", basePath);
            RegisterLogger("stringFixedLengthLog", "stringFixedLength.log", basePath);
            RegisterLogger("stringLowercaseLog", "stringLowercase.log", basePath);
            RegisterLogger("stringUppercaseLog", "stringUppercase.log", basePath);

            RegisterLogger("randomCharacterLog", "randomCharacter.log", basePath);
            RegisterLogger("randomCharacterInRangeLog", "randomCharacter.log", basePath);
        }

        private static void RegisterLogger(string registerName, string logFileName, string basePath)
        {
            unity.RegisterType<ILogger, FileLogger>(registerName, new InjectionConstructor(basePath, logFileName));
        }
        public static UnityContainer Get => unity;
    }
}
