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
using Microsoft.Win32;
using System.IO;

namespace Audio_Player
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> musics = new List<string>();
        MediaPlayer mp = new MediaPlayer();
        public bool k = true;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {   
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Title = "Open File";
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            openFileDialog.ShowDialog();

            foreach (var item in openFileDialog.FileNames)
            {
                musics.Add(item);
                List_Box.Items.Add(item);
            }
            try
            {
                mp.Open(new Uri(musics[0]));
            }
            catch (ArgumentOutOfRangeException)
            {

                MessageBox.Show("Please open a file.");
            }
            
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            
            if (k == false)
            {
                mp.Pause();
                Play.Content = "Play";
                k = true;
            }
            else {
                mp.Play();
                Play.Content = "Pause";
                k = false;
            }
        }

        private void Open2_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
