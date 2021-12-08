using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileExplorerWPF.Util.Helpers
{
    public static class DriveHelper
    {
        public static List<string> AvailableDrives()
        {
            return DriveInfo.GetDrives().Select(x => x.Name).ToList();
        }
    }
}
