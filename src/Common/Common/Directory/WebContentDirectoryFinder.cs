using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Common.Utilities.Directory
{
    public static class WebContentDirectoryFinder
    {
        public static string CalculateContentRootFolder()
        {
            var coreAssemblyDirectoryPath = Path.GetDirectoryName(typeof(WebContentDirectoryFinder).Assembly.Location);
            if (coreAssemblyDirectoryPath == null)
            {
                throw new Exception("Could not find location! " + typeof(WebContentDirectoryFinder).FullName);
            }
            var directoryInfo = new DirectoryInfo(coreAssemblyDirectoryPath);
            Console.WriteLine(directoryInfo.FullName);
            while (!DirectoryContains(directoryInfo.FullName, "Identity.Api"))
            {
                if (directoryInfo.Parent == null)
                {
                    throw new Exception("Could not find content DistributedServices.Identity folder");
                }

                directoryInfo = directoryInfo.Parent;
            }
            Console.WriteLine(directoryInfo.FullName);
            var webHostFolder = Path.Combine(directoryInfo.FullName, "Company", "Company.Api");
            if (!System.IO.Directory.Exists(webHostFolder))
            {
                throw new Exception("Could not find root folder of the web project!");
            }
            return webHostFolder;
        }
        private static bool DirectoryContains(string directory, string fileName)
        {
            return System.IO.Directory.GetDirectories(directory).Any(filePath => {
                var webHostFolder = Path.Combine(filePath, fileName);
                return System.IO.Directory.Exists(webHostFolder);
            });
        }
    }
}
