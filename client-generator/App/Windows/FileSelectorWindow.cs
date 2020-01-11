using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terminal.Gui;

namespace client_generator.App.Windows
{
    public sealed class FileSelectorWindow : Window
    {

        private FileSelectorReceiver _receiver;

        private readonly Label _currentDirectoryText;

        private string _currentPath = Directory.GetCurrentDirectory();

        private readonly ListView _filesView;

        private List<FileSystemEntry> _fileViewSource;

        public FileSelectorWindow(FileSelectorReceiver receiver) : base(
            "Code Generator - Select File")
        {
            _receiver = receiver;

            var currentDirectoryLabel = new Label(1, 1, "Current directory:");
            _currentDirectoryText = new Label(1, 2, _currentPath);

            var listViewHolder = new View()
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
                _receiver.Invoke(selectedItem);
                AppController.GetLogger()
                    .Info(
                        $"File {selectedItem.ParentDirectory}{Path.DirectorySeparatorChar}{selectedItem.FileName} was selected.");
                _receiver = null;
            }

            return true;
        }

    }
}
