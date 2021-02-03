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

            next.IsEnabled = false;
            Play.IsEnabled = false;
            previous.IsEnabled = false;
        }
        void timer_Tick(object sender, EventArgs e)
        {
            if ((mp.Source != null) && (mp.NaturalDuration.HasTimeSpan))
            {
                M_Slider.Value = mp.Position.TotalSeconds;
            }

            Now.Content = List_Box.SelectedItem;

            if (M_Slider.Value == M_Slider.Maximum)
            {
                try
                {
                    mp.Open(new Uri(musics[List_Box.SelectedIndex + 1]));
                    List_Box.SelectedIndex += 1;
                    ButtonChanged();
                }
                catch (ArgumentOutOfRangeException)
                {

                    mp.Open(new Uri(musics[0]));
                    List_Box.SelectedIndex = 0;
                    ButtonChanged();
                }
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
            if (musics.Count != 0)
            {
                next.IsEnabled = true;
                Play.IsEnabled = true;
                previous.IsEnabled = true;
            }
        }
        
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter("save.txt");
            foreach (var item in musics)
            {
                sw.WriteLine(item);
            }
            sw.Close();
            List_Box.Items.Clear();
            musics.Clear();
            next.IsEnabled = true;
            Play.IsEnabled = true;
            previous.IsEnabled = true;
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            ButtonChanged();
        }

        private void Open2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader("save.txt");
                while (!sr.EndOfStream)
                {
                    string row = sr.ReadLine();
                    List_Box.Items.Add(row);
                    musics.Add(row);
                }

                sr.Close();
                mp.Open(new Uri(musics[0]));
                if (musics.Count != 0)
                {
                    next.IsEnabled = true;
                    Play.IsEnabled = true;
                    previous.IsEnabled = true;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please open a save.");
            }

           
        }

        private void List_Box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mp.Pause();
            mp.Open(new Uri(musics[List_Box.SelectedIndex]));
        
            ButtonChanged();
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            try
            {
                mp.Open(new Uri(musics[List_Box.SelectedIndex + 1]));
                List_Box.SelectedIndex += 1;
                ButtonChanged();
            }
            catch (ArgumentOutOfRangeException)
            {

                mp.Open(new Uri(musics[0]));
                List_Box.SelectedIndex = 0;
                ButtonChanged();
            }
            
        }
        private void Previous(object sender, RoutedEventArgs e)
        {
            try
            {
                mp.Open(new Uri(musics[List_Box.SelectedIndex - 1]));
                List_Box.SelectedIndex -= 1;
                ButtonChanged();
            }
            catch (ArgumentOutOfRangeException)
            {

                mp.Open(new Uri(musics[musics.Count-1]));
                List_Box.SelectedIndex = musics.Count -1;
                ButtonChanged();
            }
        }
        public void ButtonChanged()
        {
            if (k == false)
            {
                k = true;
                Play.Content = "Play";
                mp.Pause();
            }
            else
            {
                k = false;
                Play.Content = "Pause";
               
                mp.Play();
            }
        }

        private void M_Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            M_Slider.Maximum = mp.NaturalDuration.TimeSpan.TotalSeconds;
        }

        private void M_Slider_LostMouseCapture(object sender, MouseEventArgs e)
        {
            mp.Position = new TimeSpan(0, 0, Convert.ToInt32(M_Slider.Value));
        }

        private void V_Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mp.Volume = (double)V_Slider.Value;
        }
    }
}
