using FirstFloor.ModernUI.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TimerLogic;
using System.Windows.Threading;
using GW2Helper.ButtonLogic;
using GW2Helper.Properties;

namespace GW2Helper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Start APIAccessor;
        private DayPicker pickDay;

        public MainWindow()
        {
            APIAccessor = new Start();
            pickDay = new DayPicker();

            DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            label.Content = APIAccessor.ExposeApi(gw2Events.Tarir);
            label_Copy.Content = APIAccessor.ExposeApi(gw2Events.Tequatl);
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
                this.DragMove();
            }
            catch (System.InvalidOperationException)
            {
                
                //throw;
            }
                
           
            
        }

        private void label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            label.Content=APIAccessor.ExposeApi(gw2Events.Tequatl);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Clipboard.SetText(pickDay.PickPasteForDay());

            button.Content = "Copied";
            var task = Task.Run(() =>
            {
                Thread.Sleep(2000);
            });

            task.ContinueWith((t) =>
            {
                Dispatcher.Invoke(() =>
                {
                    button.Content = "Pact Agents";
                });
            });
        }

        private void MainWindowUiWindow_Loaded(object sender, RoutedEventArgs e)
        {
            string filename = Settings.Default.Path;

            if (!Settings.Default.Once)
            {

                string text =
                    "If you want GW2Helper to launch the game automatically specify your GW-64.exe or GW.exe path.\n" +
                    "This will appear only once, to reset configuration press F1+click on main helper window";
                MessageBox.Show(text);
                
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.FileName = "Gw2-64"; // Default file name
                dlg.DefaultExt = ".exe"; // Default file extension
                //dlg.Filter = ".exe"; // Filter files by extension

                // Show open file dialog box
                Nullable<bool> result = dlg.ShowDialog();
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
                    System.Diagnostics.Process.Start(filename);
                }
                catch (InvalidOperationException)
                {
                    //throw;
                }
            }

            Settings.Default.Save();

        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            textBox.IsEnabled = true;
            textBox.Visibility = Visibility.Visible;
            button_Copy1.IsEnabled = true;
            button_Copy1.Visibility = Visibility.Visible;
            textBox.Text = Properties.Settings.Default.Notes;

        }

        private void button_Copy1_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default.Notes = textBox.Text;
            Settings.Default.Save();
            textBox.IsEnabled = false;
            textBox.Visibility = Visibility.Hidden;
            button_Copy1.IsEnabled = false;
            button_Copy1.Visibility = Visibility.Hidden;
        }
    }
}
