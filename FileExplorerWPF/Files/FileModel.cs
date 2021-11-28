﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorerWPF.Files
{
    public class FileModel
    {
        public Icon Icon { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
