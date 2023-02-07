

using System;

namespace AbatabLieutenant
{
    internal static class Program
    {
        internal static void Main(string[] args)
        {
            Console.Clear();

            var passedArgument = GetPassedArgument(args);



            //DeployService();
            //Finisher(1);


        }

        internal static string GetPassedArgument(string[] args) =>
            args.Length == 0
                ? Properties.Settings.Default.DefaultBranch
                : Verification.PassedArguments.VerifyArguments(args[0])
                    ? args[0]
                    : "undefined";


    }
}