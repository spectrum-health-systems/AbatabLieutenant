namespace AbatabLieutenant
{
    public class Copier
    {
        public static void CopyBin(string source, string target)
        {
            CopyDir(source, target);
        }

        public static void CopyDir(string source, string target)
        {
            Maintenance.OS.RefreshDirectory(target);

            DirectoryInfo dirToCopy       = new DirectoryInfo(source);
            DirectoryInfo[] subDirsToCopy = GetSubDirs(source, target);

            foreach (FileInfo file in dirToCopy.GetFiles())
            {
                string targetPath = Path.Combine(target, file.Name);

                _=file.CopyTo(targetPath);
            }

            foreach (var (subDir, newTargetDir) in from DirectoryInfo subDir in subDirsToCopy
                                                   let newTargetDir = Path.Combine(target, subDir.Name)
                                                   select (subDir, newTargetDir))
            {
                CopyDir(subDir.FullName, newTargetDir);
            }
        }

        public static void CopyService(string source, string target, List<string> serviceFiles)
        {
            foreach (string file in serviceFiles)
            {
                if (File.Exists($@"{target}\{file}"))
                    File.Delete($@"{target}\{file}");

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
