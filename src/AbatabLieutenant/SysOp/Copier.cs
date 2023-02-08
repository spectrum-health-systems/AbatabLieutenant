namespace AbatabLieutenant.SysOp
{
    internal class Copier
    {
        public static void CopyBin(string source, string target, string logFilePath)
        {
            //Logger.LogEvent.ToConsoleAndFile(@"Copying bin\...", logFilePath);

            CopyDir(source, $@"{target}\bin", logFilePath);
        }

        public static void CopyDir(string source, string target, string logFilePath)
        {
            SysOp.Maintenance.RefreshDirectory(target, logFilePath);

            DirectoryInfo dirToCopy       = new DirectoryInfo(source);
            DirectoryInfo[] subDirsToCopy = GetSubDirs(source, target);

            foreach (FileInfo file in dirToCopy.GetFiles())
            {
                Logger.LogEvent.ToFile($"Copying {file.FullName}...", logFilePath);

                string targetPath = Path.Combine(target, file.Name);

                _=file.CopyTo(targetPath);
            }

            foreach (var (subDir, newTargetDir) in from DirectoryInfo subDir in subDirsToCopy
                                                   let newTargetDir = Path.Combine(target, subDir.Name)
                                                   select (subDir, newTargetDir))
            {
                CopyDir(subDir.FullName, newTargetDir, logFilePath);
            }
        }

        public static void CopyService(string source, string target, List<string> serviceFiles, string logFilePath)
        {
            foreach (string file in serviceFiles)
            {
                //if (File.Exists($@"{target}\{file}"))
                //    File.Delete($@"{target}\{file}");

                //Logger.LogEvent.ToFile($@"Copying {source} to {target}...", logFilePath);

                File.Copy($@"{source}\{file}", $@"{target}\{file}");
            }
        }
        private static DirectoryInfo[] GetSubDirs(string source, string target)
        {
            DirectoryInfo dir = new DirectoryInfo(source);

            if (!dir.Exists)
            {
                _=Directory.CreateDirectory(target);

            }

            return dir.GetDirectories();
        }

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
