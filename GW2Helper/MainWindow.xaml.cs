using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using GW2Helper.ButtonLogic;
using GW2Helper.Properties;
using Microsoft.Win32;
using TimerLogic;

namespace GW2Helper
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Start ApiAccessor;
        private SolidColorBrush _brush1, _brush2;
        private ColorResolver _pickColor;
        private readonly DayPicker _pickDay;
        private TimeSpan _timer1, _timer2;


        public MainWindow()
        {
            ApiAccessor = new Start();
            _pickDay = new DayPicker();
            _brush1 = new SolidColorBrush();
            _brush2 = new SolidColorBrush();


            var dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            SetTimer(Label, ref _timer1, ref _brush1, Gw2Events.Tarir);

            SetTimer(LabelCopy, ref _timer2, ref _brush2, Gw2Events.Tequatl);
        }


        private void SetTimer(Label myLabel, ref TimeSpan myTimer, ref SolidColorBrush myBrush, Gw2Events paramEvents)
        {
            myTimer = ApiAccessor.ExposeApi(paramEvents);

            myBrush.Color = _pickColor.FromTimeSpan(myTimer);

            if (myTimer.TotalMilliseconds <= 0)
            {
                if (myTimer.Seconds > -10)
                    myLabel.Content = "Active for " + myTimer.Negate().Minutes + ":0" + myTimer.Negate().Seconds;
                else myLabel.Content = "Active for " + myTimer.Negate().Minutes + ":" + myTimer.Negate().Seconds;
                myLabel.FontSize = 17.0d;
            }
            else
            {
                myLabel.Content = myTimer.ToString();
                myLabel.FontSize = 30.0d;
            }

            myLabel.Foreground = myBrush;
        }

        private void MainWindowUiWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.F1) && Mouse.LeftButton == MouseButtonState.Pressed)
            {
                Settings.Default.Once = false;
                Settings.Default.Path = "";
                Settings.Default.Auto = false;
                Settings.Default.Save();
                MessageBox.Show("Configuration purged");
            }
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                if (Keyboard.IsKeyDown(Key.X)) Application.Current.Shutdown();
            try
            {
                DragMove();
            }
            catch (InvalidOperationException)
            {
                //throw;
            }
        }

        private void label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //    label.Content=APIAccessor.ExposeApi(gw2Events.Tequatl);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(_pickDay.PickPasteForDay());

            Button.Content = "Copied";
            var task = Task.Run(() => { Thread.Sleep(2000); });

            task.ContinueWith(t => { Dispatcher.Invoke(() => { Button.Content = "Pact Agents"; }); });
        }

        private void MainWindowUiWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _pickColor = new ColorResolver();
            var filename = Settings.Default.Path;

            if (!Settings.Default.Once)
            {
                var text =
                    "If you want GW2Helper to launch the game automatically specify your GW-64.exe or GW.exe path.\n" +
                    "This will appear only once, to reset configuration press F1+click on main helper window";
                MessageBox.Show(text);

                var dlg = new OpenFileDialog();
                dlg.FileName = "Gw2-64"; // Default file name
                dlg.DefaultExt = ".exe"; // Default file extension
                //dlg.Filter = ".exe"; // Filter files by extension

                // Show open file dialog box
                var result = dlg.ShowDialog();
                Settings.Default.Once = true;
                // Process open file dialog box results
                if (result == true)
                {
                    // Open document
                    filename = dlg.FileName;
                    Settings.Default.Path = dlg.FileName;
                    Settings.Default.Auto = true;
                }
            }

            if (Settings.Default.Auto)
            {
                try
                {
                    Process.Start(filename);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Something went wrong :(");
                    throw;
                }
            }

            Settings.Default.Save();
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            TextBox.IsEnabled = true;
            TextBox.Visibility = Visibility.Visible;
            ButtonCopy1.IsEnabled = true;
            ButtonCopy1.Visibility = Visibility.Visible;
            TextBox.Text = Settings.Default.Notes;
        }

        private void button_Copy1_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default.Notes = TextBox.Text;
            Settings.Default.Save();
            TextBox.IsEnabled = false;
            TextBox.Visibility = Visibility.Hidden;
            ButtonCopy1.IsEnabled = false;
            ButtonCopy1.Visibility = Visibility.Hidden;
        }
    }
}