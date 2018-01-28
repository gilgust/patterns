using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Servicies;

namespace WavRedactor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static readonly ServiciesFactory serviceFactorry = new ServiciesFactory();
        static readonly IFileService _fileService = serviceFactorry.GetFileService();
        private static readonly IAudioPlayer _audioPlayer = serviceFactorry.GetAudioPlayer();
        

        public MainWindow()
        {
            InitializeComponent();

            var path_to_source = Directory.GetCurrentDirectory() + @"\media";
            TBSource.Text = path_to_source;
            DataGridSource.ItemsSource = new DirectoryInfo(path_to_source).GetFiles("*.wav");

            var path_to_target = Directory.GetCurrentDirectory() + @"\!!test_folder";
            TBTarget.Text = path_to_target;
            DataGridTarget.ItemsSource = new DirectoryInfo(path_to_target).GetFiles("*.wav");
        }

        private void ShowChange()
        {
            DataGridSource.ItemsSource = new DirectoryInfo(TBSource.Text).GetFiles("*.wav");
            DataGridTarget.ItemsSource = new DirectoryInfo(TBTarget.Text).GetFiles("*.wav");
        }

        private void Grid_mouseDK(object sender, MouseButtonEventArgs e)
        {
            var selectItem = (FileInfo)((DataGrid) sender).SelectedItem;
            TextBoxFileName.Text = selectItem.Name;
            _fileService.NameFile = selectItem.Name;
            _fileService.PathToFite = selectItem.DirectoryName;
            _fileService.TargetPath = TBTarget.Text;
            _audioPlayer.PathToFite = selectItem.DirectoryName;
            _audioPlayer.NameFile = selectItem.Name;
        }

        private void OpenButton_OnClick(object sender, RoutedEventArgs e)
        {
            _audioPlayer.Load();
        }

        private void PlayButton_OnClick(object sender, RoutedEventArgs e)
        {
            _audioPlayer.Play();
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            _fileService.SaveFile();
            ShowChange();
        }

        private void MoveButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (_fileService.IsEmpty())
            {
                MessageBox.Show("Выберите файл для удаления");
                return;
            }
            if (_fileService.TargetPath == _fileService.PathToFite)
            {
                MessageBox.Show("Выберите другую папку");
                return;
            }
            _fileService.MoveFile();
            ShowChange();
        }

        private void RemoveButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (_fileService.IsEmpty())
            {
                MessageBox.Show("Выберите файл для удаления");
                return;
            }
            _fileService.DeleteFile();
            ShowChange();
        }
    }
}