//
//
//

namespace AbatabLieutenant.Maintenance
{
    /// <summary>TBD</summary>
    public class OS
    {
        public static void ConfirmDirectoryExists(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        /// <summary>TBD</summary>
        /// <param name="directory"></param>
        public static void RefreshDirectory(string directory)
        {
            if (Directory.Exists(directory))
            {
                Directory.Delete(directory, true);
            }

            Directory.CreateDirectory(directory);

            //LogEvent($"  {dir}", true);
        }

        /// <summary>TBD</summary>
        /// <param name="directory"></param>
        public static void RefreshDirectories(Dictionary<string, string> directories)
        {
            foreach (var directory in directories)
            {

            }
        }

        /// <summary></summary>
        /// <param name="root"></param>
        /// <param name="files"></param>
        private static void RemoveFiles(string root, List<string> files)
        {
            foreach (var file in from file in files
                                 where File.Exists($"{root}/{file}")
                                 select file)
            {
                File.Delete($"{root}/{file}");
            }
        }
    }
}
