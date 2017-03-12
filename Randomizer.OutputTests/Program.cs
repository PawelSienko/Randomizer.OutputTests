using System;
using System.Configuration;
using System.IO;
using System.Linq;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
using Randomizer.OutputTests.Base;
using Randomizer.OutputTests.TestManagers;
using Randomizer.OutputTests.Tests.AlphanumericString;
using Randomizer.OutputTests.Unity;

namespace Randomizer.OutputTests
{
    class Program
    {
        // ReSharper disable once InconsistentNaming
        private static IConsoleManager consoleManager;

        static Program()
        {
            Bootstrap();
        }

        static void Main(string[] args)
        {
            int executionNumbers = 0;
            if (args != null && args.Length > 0)
            {
                int.TryParse(args[0], out executionNumbers);
            }

            consoleManager.PrintHeader();

            RemovePreviousErrorFilesIfExist();
            Console.ForegroundColor = ConsoleColor.Green;
            InvokeTests<AlphanumericCharTestManager, char>("Alphanumeric char", executionNumbers, 'g', 'w');
            InvokeTests<AlphanumericCharTestManager, char>("Alphanumeric char", executionNumbers, 'F', 'L');
            InvokeTests<AlphanumericCharTestManager, char>("Alphanumeric char", executionNumbers, 'A', 'c');
            InvokeTests<AlphanumericCharTestManager, char>("Alphanumeric char", executionNumbers, 'c', '4');
            InvokeTests<AlphanumericCharTestManager, char>("Alphanumeric char", executionNumbers, 'A', '1');
            InvokeTests<IntegerTestManager, int>("integer", executionNumbers, 10, 20);
            InvokeTests<IntegerTestManager, int>("integer", executionNumbers, int.MinValue, int.MaxValue);
            InvokeTests<IntegerTestManager, int>("integers", executionNumbers, -70411, 543);
            InvokeTests<FloatTestManager, float>("float", executionNumbers, 1.9023f, 1.924565f);
            InvokeTests<FloatTestManager, float>("float", executionNumbers, -7001.9023f, 21.924f);
            InvokeTests<FloatTestManager, float>("float", executionNumbers, float.MinValue, float.MaxValue);
            InvokeTests<DecimalTestManager, decimal>("decimal", executionNumbers, 1.2234200045m, 1.32331990989m);
            InvokeTests<DecimalTestManager, decimal>("decimal", executionNumbers, -1.2234200045m, 500.32331990989m);
            InvokeTests<DecimalTestManager, decimal>("decimal", executionNumbers, decimal.MinValue, decimal.MaxValue);
            InvokeTests<LongTestManager, long>("long", executionNumbers, -4294967296L, 500000000L);
            InvokeTests<LongTestManager, long>("long", executionNumbers, -4294967297L, -4294967295L);
            InvokeTests<LongTestManager, long>("long", executionNumbers, 4294967296L, 4294967297L);
            InvokeTests<LongTestManager, long>("long", executionNumbers, long.MinValue, long.MaxValue);
            InvokeTests<ShortTestManager, short>("short", executionNumbers, -12, 15);
            InvokeTests<ShortTestManager, short>("short", executionNumbers, -100, -15);
            InvokeTests<ShortTestManager, short>("short", executionNumbers, (short)0, (short)15);
            InvokeTests<ShortTestManager, short>("short", executionNumbers, short.MinValue, short.MaxValue);
            InvokeTests<DoubleTestManager, double>("double", executionNumbers, double.MinValue, double.MaxValue);
            InvokeTests<DoubleTestManager, double>("double", executionNumbers, -1022342D, 11D);
            InvokeTests<DoubleTestManager, double>("double", executionNumbers, -1022342D, -11D);
            InvokeTests<DoubleTestManager, double>("double", executionNumbers, 1022342D, 1123421312D);
            InvokeTests<DateTimeTestManager, DateTime>("dateTime - milliseconds", executionNumbers, DateTime.Now, DateTime.Now.AddMilliseconds(2));
            InvokeTests<DateTimeTestManager, DateTime>("dateTime - seconds", executionNumbers, DateTime.Now, DateTime.Now.AddSeconds(1));
            InvokeTests<DateTimeTestManager, DateTime>("dateTime - minutes", executionNumbers, DateTime.Now, DateTime.Now.AddMinutes(1));
            InvokeTests<DateTimeTestManager, DateTime>("dateTime - hours", executionNumbers, DateTime.Now, DateTime.Now.AddHours(1));
            InvokeTests<DateTimeTestManager, DateTime>("dateTime - days", executionNumbers, DateTime.Now, DateTime.Now.AddDays(1));
            InvokeTests<DateTimeTestManager, DateTime>("dateTime - months", executionNumbers, DateTime.Now, DateTime.Now.AddMonths(1));
            InvokeTests<DateTimeTestManager, DateTime>("dateTime - years", executionNumbers, DateTime.Now, DateTime.Now.AddYears(1));
            InvokeTests<DateTimeTestManager, DateTime>("dateTime - min and max of datetime", executionNumbers, DateTime.MinValue.AddYears(1), DateTime.MaxValue.AddYears(-1));
            InvokeTests<DateTimeTestManager, DateTime>("dateTime - normal timespan 1", executionNumbers, DateTime.Now.AddYears(-1), DateTime.Now.AddMinutes(45).AddDays(11).AddSeconds(12));
            InvokeTests<DateTimeTestManager, DateTime>("dateTime - normal timespan", executionNumbers, DateTime.Now.AddHours(-7), DateTime.Now.AddMinutes(7).AddSeconds(12).AddHours(1));

            InvokeTests<AlphanumericStringTestManager, object>("alphanumeric string with exclusions", executionNumbers, 40, 'f', 'Z', '1');
            InvokeTests<AlphanumericStringTestManager, object>("alphanumeric string with exclusions", executionNumbers, 40, 'f', '@', 'B');

            InvokeTests<AlphanumericStringTestManager, object>("alphanumeric string with exclusions", executionNumbers, 40, '1', 'q', 'M');
            consoleManager.PrintFooter();

            NotifyIfErrors();
        }

        private static void RemovePreviousErrorFilesIfExist()
        {
            var errorLogsPath = GetErrorLogPath();

            if (Directory.Exists(errorLogsPath))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(errorLogsPath);
                var files = directoryInfo.GetFiles();
                if (files.Any())
                {
                    files.ForEach(file => file.Delete());
                }
            }
        }

        private static void NotifyIfErrors()
        {
            var errorLogsPath = GetErrorLogPath();
            if (Directory.GetFiles(errorLogsPath).Any())
            {
                consoleManager.PrintErrorMsg("Some errors occured. Please check location " + errorLogsPath);
            }
        }

        private static string GetErrorLogPath()
        {
            return ConfigurationManager.AppSettings["basePath"];
        }
        private static void InvokeTests<T, TInput>(string testName, int executionTimes = 0, params TInput[] parameters)
            where T : TestManagerBase<TInput>
        {
            consoleManager.PrintLine($"Start {testName} tests..............");
            var testManager = UnityConfiguration.Get.Resolve<T>();
            if (executionTimes > 0)
            {
                testManager.SetExecutionTimes(executionTimes);
            }
            testManager.ExecuteAll(parameters);
            consoleManager.PrintLine($"Stop {testName} tests..............");
        }

        private static void Bootstrap()
        {
            UnityConfiguration.Configure();
            consoleManager = UnityConfiguration.Get.Resolve<IConsoleManager>();
        }

    }
}
