// AbatabLieutenant.CommandLine.cs
// Stuff for command line stuff.
// b---

namespace AbatabLieutenant
{
    public class CommandLine
    {
        /// <summary>Returns passed arguments as a `List<string>`</summary>
        /// <param name="passedArguments">Arguments passed via the command line.</param>
        /// <remarks>
        /// * Returns an empty list if no arguments were passed.
        /// </remarks>
        /// <returns>The passed arguments as a List<string>`</returns>
        public static List<string> GetArgumentList(string[] passedArguments)
        {
            return passedArguments.Length > 0
                ? passedArguments.ToList()
                : new List<string>();
        }
    }
}
