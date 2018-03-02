using System;
using System.Collections.Generic;
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
using System.Windows.Forms;
using System.IO;
using Application = System.Windows.Forms.Application;

namespace Copy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Model _model;
        private Stream _path;

        public MainWindow()
        {
            InitializeComponent();

            _model = new Model();
            this.DataContext = _model;
        }


        //select file
        private void Path_OnClick(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.InitialDirectory = Application.StartupPath;
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                _model.SourcePath = ofd.FileName;

        }

        //select directory
        private void DirectoryPathButton_OnClick(object sender, RoutedEventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                _model.DirectoryPath = fbd.SelectedPath;
            _model.SourcePath = _model.DirectoryPath;

        }

        //set target path
        private void TargetPath_OnClick(object sender, RoutedEventArgs e)
        {
            var sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                _model.TargetPath = sfd.FileName;
        }

        // start copy
        private void CopyButton_OnClick(object sender, RoutedEventArgs e)
        {
            _model.Copy();
        }
    }
}
