using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using client_generator.App.Windows.MenuWindowStates;
using Terminal.Gui;

namespace client_generator.App.Windows
{
    public sealed class FileSelectorWindow : PopupWindow
    {

        private readonly Label _currentDirectoryText;

        private readonly ListView _filesView;

        private string _currentPath = Directory.GetCurrentDirectory();

        private List<FileSystemEntry> _fileViewSource;

        public FileSelectorWindow() : base("Code Generator - Select File")
        {
            var currentDirectoryLabel = new Label(1, 1, "Current directory:");
            _currentDirectoryText = new Label(1, 2, _currentPath);

            var listViewHolder = new View
            {
                Y = Pos.Bottom(_currentDirectoryText) + 1,
                X = 1,
                Width = Dim.Fill(1),
                Height = Dim.Fill()
            };

            _fileViewSource = GetListViewSource();
            _filesView = new ListView(_fileViewSource);
            listViewHolder.Add(_filesView);

            Add(currentDirectoryLabel, _currentDirectoryText, listViewHolder);
        }


        private List<FileSystemEntry> GetListViewSource()
        {
            var files = SortFilesList(GetFileSystemEntriesInCurrentDirectory());
            files.Insert(0, new BackFileEntry(_currentPath));
            return files;
        }

        private List<FileSystemEntry> GetFileSystemEntriesInCurrentDirectory()
        {
            var result = new List<FileSystemEntry>();
            foreach (var filePath in Directory.GetFileSystemEntries(_currentPath))
            {
                var attr = File.GetAttributes(filePath);
                var isDirectory = (attr & FileAttributes.Directory) == FileAttributes.Directory;
                result.Add(new FileSystemEntry
                {
                    FileName = Path.GetFileName(filePath),
                    ParentDirectory = _currentPath,
                    IsDirectory = isDirectory
                });
            }

            return result;
        }

        private static List<FileSystemEntry> SortFilesList(IEnumerable<FileSystemEntry> files)
        {
            return files.OrderBy(x => x.IsDirectory ? 0 : 1).ThenBy(x => x.FileName).ToList();
        }

        public override bool ProcessKey(KeyEvent keyEvent)
        {
            if (keyEvent.Key != Key.Enter)
            {
                return _filesView.ProcessKey(keyEvent);
            }

            var selectedItem = _fileViewSource[_filesView.SelectedItem];
            if (selectedItem.IsDirectory)
            {
                _currentPath = selectedItem.GoToFile();
                _currentDirectoryText.Text = _currentPath;
                _fileViewSource = GetListViewSource();
                _filesView.SetSource(_fileViewSource);
            }

            else
            {
                AppController.GetLogger()
                    .Info(
                        $"File {selectedItem.ParentDirectory}{Path.DirectorySeparatorChar}{selectedItem.FileName} was selected.");

                OnExit?.Invoke(selectedItem);
            }

            return true;
        }

    }
}
