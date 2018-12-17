using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BleemSync.Utilities
{
    public class Filesystem
    {
        public static string GetExecutingDirectory()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);

            return Path.GetDirectoryName(path);
        }

        public static string GetGamesDirectory(string gamesDir = "")
        {
            var currentPath = GetExecutingDirectory();

            if (gamesDir != "" && !gamesDir.StartsWith("/"))
            {
                return Path.Join(currentPath, Path.Combine(gamesDir.Split('/')));
            }
            else if (gamesDir.StartsWith("/"))
            {
                return gamesDir;
            }
            else
            {
                return Path.Join(currentPath, "..", "Games");
            }
        }
    }
}
