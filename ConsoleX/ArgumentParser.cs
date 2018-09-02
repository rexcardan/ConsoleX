using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleX
{
    public class ArgumentParser
    {
        /// <summary>
        /// Retrieves a single string value for a command line key. Everything that follows the key
        /// (but is before the next key) is merged into a single string
        /// </summary>
        /// <param name="commandLineArgs">all command line args</param>
        /// <param name="key">the flag or key of the desired argument (-file would be "file")</param>
        /// <returns>the value of the argument</returns>
        public static string GetSingle(string[] commandLineArgs, string key)
        {
            if (commandLineArgs.Contains(key))
            {
                var index = commandLineArgs.ToList().IndexOf(key);
                var parts = commandLineArgs.Skip(index + 1).TakeWhile(k => !k.StartsWith("-")).ToArray();
                return string.Join(" ", parts);
            }
            return null;
        }

        /// <summary>
        /// Retrieves multiple strings for a command line key. Everything that follows the key
        /// (but is before the next key) is treated as a separate value
        /// </summary>
        /// <param name="commandLineArgs">all command line args</param>
        /// <param name="key">the flag or key of the desired argument (-file would be "file")</param>
        /// <returns>all the values of the argument</returns>
        public static string[] GetMultiple(string[] commandLineArgs, string key)
        {
            if (commandLineArgs.Contains(key))
            {
                var index = commandLineArgs.ToList().IndexOf(key);
                return commandLineArgs.Skip(index + 1).TakeWhile(k => !k.StartsWith("-")).ToArray();
            }
            return null;
        }
    }
}
