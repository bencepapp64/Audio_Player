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
using System.Windows.Threading;

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

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            if ((mp.Source != null) && (mp.NaturalDuration.HasTimeSpan))
            {
                M_Slider.Value = mp.Position.TotalSeconds;
            }
            if (M_Slider.Value == M_Slider.Maximum)
            {

            }
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
                M_Slider.Maximum = mp.NaturalDuration.TimeSpan.TotalSeconds;
            }
        }

        private void Open2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void List_Box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mp.Open(new Uri(musics[List_Box.SelectedIndex]));
            if (k == false)
            {
                k = true;
                Play.Content = "Play";
            }
            else
            {
                k = false;
                Play.Content = "Pause";
            }
        }
    }
}
