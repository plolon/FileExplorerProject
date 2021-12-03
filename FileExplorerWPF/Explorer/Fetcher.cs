using FileExplorerWPF.Files;
using FileExplorerWPF.Util;
using FileExplorerWPF.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace FileExplorerWPF.Explorer
{
    public static class Fetcher
    {
        public static List<FileModel> GetFiles(string path)
        {
            List<FileModel> result = new List<FileModel>();
            if (!path.IsDirectory())
                return result;

            string currentFile = "";

            try
            {
                foreach (var file in Directory.GetFiles(path))
                {
                    currentFile = file;
                    if (Path.GetExtension(file) != ".lnk")
                    {
                        FileInfo fileInfo = new FileInfo(path);
                        FileModel fileModel = new FileModel()
                        {
                            Icon = IconHelper.GetIconOfFile(file, true, false),
                            Name = fileInfo.Name,
                            Path = fileInfo.FullName,
                            DateCreated = fileInfo.CreationTime,
                            DateModified = fileInfo.LastWriteTime,
                            Type = FileType.File,
                            SizeBytes = fileInfo.Length
                        };

                        result.Add(fileModel);
                    }
                }
                return result;
            }
            catch (IOException e)
            {
                MessageBox.Show($"IO Exception getting files in directory: {e.Message}", "Exception getting files in directory");
            }
            catch (UnauthorizedAccessException e)
            {
                MessageBox.Show($"No access for a file: {e.Message}", "Exception getting files in directory");
            }
            catch (Exception e)
            {
                MessageBox.Show($"Failed to get files in '{path}', Something to do with '{currentFile}'\nException: {e.Message}", "Error");
            }

            return result;
        }

        public static List<FileModel> GetDirectories(string path)
        {
            List<FileModel> result = new List<FileModel>();
            if (!path.IsDirectory())
                return result;

            string currentDirectory = "";
            try
            {
                foreach (string dir in Directory.GetDirectories(path))
                {
                    currentDirectory = dir;

                    DirectoryInfo dInfo = new DirectoryInfo(dir);
                    FileModel dModel = new FileModel()
                    {
                        Icon = IconHelper.GetIconOfFile(dir, true, true),
                        Name = dInfo.Name,
                        Path = dInfo.FullName,
                        DateCreated = dInfo.CreationTime,
                        DateModified = dInfo.LastWriteTime,
                        Type = FileType.Folder,
                        SizeBytes = long.MaxValue
                    };

                    result.Add(dModel);
                }

                // Checks for directory shortcuts
                foreach (string file in Directory.GetFiles(path))
                {
                    if (Path.GetExtension(file) == ".lnk")
                    {
                        string realDirPath = ExplorerHelper.GetShortcutTargetFolder(file);
                        FileInfo dInfo = new FileInfo(realDirPath);
                        FileModel dModel = new FileModel()
                        {
                            Icon = IconHelper.GetIconOfFile(realDirPath, true, true),
                            Name = dInfo.Name,
                            Path = dInfo.FullName,
                            DateCreated = dInfo.CreationTime,
                            DateModified = dInfo.LastWriteTime,
                            Type = FileType.Folder,
                            SizeBytes = 0
                        };

                        result.Add(dModel);
                    }
                }

                return result;
            }

            catch (IOException e)
            {
                MessageBox.Show($"IO Exception getting folders in directory: {e.Message}", "Exception getting folders in directory");
            }
            catch (UnauthorizedAccessException e)
            {
                MessageBox.Show($"No access for a directory: {e.Message}", "Exception getting folders in directory");
            }
            catch (Exception e)
            {
                MessageBox.Show($"Failed to get directories in '{path}', Something to do with '{currentDirectory}'\nException: {e.Message}", "Error");
            }

            return result;
        }

        public static List<FileModel> GetDrives()
        {
            List<FileModel> result = new List<FileModel>();
            try
            {
                foreach (string drive in Directory.GetLogicalDrives())
                {
                    DriveInfo dInfo = new DriveInfo(drive);
                    FileModel dModel = new FileModel()
                    {
                        Icon = IconHelper.GetIconOfFile(drive, true, true),
                        Name = dInfo.Name,
                        Path = dInfo.Name,
                        DateModified = DateTime.Now,
                        Type = FileType.Drive,
                        SizeBytes = dInfo.TotalSize
                    };

                    result.Add(dModel);
                }

                return result;
            }
            catch (IOException e)
            {
                MessageBox.Show($"IO Exception getting drives: {e.Message}", "Exception getting drives");
            }
            catch (UnauthorizedAccessException e)
            {
                MessageBox.Show($"No access for a hard drive: {e.Message}", "");
            }
            return result;
        }
    }
}
