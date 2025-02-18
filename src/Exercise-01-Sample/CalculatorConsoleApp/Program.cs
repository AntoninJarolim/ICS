﻿using System;
using CommandLine;

namespace Exercise_01.CalculatorConsoleApp
{
    internal static class Program
    {
        internal static void LogException(Exception exception)
        {
            Console.WriteLine($"Exception occurred: {exception.Message}");
        }

        internal static void LogMessage(string message)
        {
            Console.WriteLine(message);
        }

        internal static void Main(string[]? args)
        {
            args ??= Array.Empty<string>();

            var parser = new Parser(with =>
            {
                with.EnableDashDash = true;
                with.HelpWriter = Console.Error;
            });
            parser.ParseArguments<CommandLineOptions>(args)
                  .WithParsed(CalculatorWrapper.Calculate);

            WaitBeforeExit();
        }

        private static void WaitBeforeExit()
        {
            Console.WriteLine("Press ANY key to continue...");
            Console.ReadKey();
        }
    }
}