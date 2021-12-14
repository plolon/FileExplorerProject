﻿using FileExplorerWPF.FileOperations;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FileExplorerWPF.Files
{
    public partial class FileControl : UserControl
    {
        public FileModel File
        {
            get => this.DataContext as FileModel;
            set => this.DataContext = value;
        }

        public Action<FileModel> NavigateToPathCallback { get; set; }

        public FileControl()
        {
            InitializeComponent();
            File = new FileModel();
        }
        public FileControl(FileModel fileModel)
        {
            InitializeComponent();
            File = fileModel;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.LeftButton == MouseButtonState.Pressed && e.ClickCount == 2)
            {
                NavigateToPathCallback?.Invoke(File);
            }
        }
        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                NavigateToPathCallback?.Invoke(File);
            }   
        }

        private void Grid_Drop(object sender, DragEventArgs e)
        {
            if (DragDropHelper.isDragging)
            {
                
                var data = e.Data.GetData(typeof(List<string>)) as List<string>;
                foreach(var x in data)
                {
                    MessageBox.Show(x);
                }
                DragDropHelper.isDragging = false;
            }
        }
    }
}
