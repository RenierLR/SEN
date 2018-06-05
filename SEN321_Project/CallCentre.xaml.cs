using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace SEN321_Project
{
    /// <summary>
    /// Interaction logic for CallCentre.xaml
    /// </summary>
    public partial class CallCentre : Window
    {
        System.Timers.Timer timer = new System.Timers.Timer();
        Stopwatch stopwatch = new Stopwatch();
        string elapsed;

        SolidColorBrush red = new SolidColorBrush(Color.FromArgb(0xFF, Convert.ToByte(253), Convert.ToByte(114), Convert.ToByte(114)));
        SolidColorBrush green = new SolidColorBrush(Color.FromArgb(0xFF, Convert.ToByte(147), Convert.ToByte(237), Convert.ToByte(154)));
        SolidColorBrush gray = new SolidColorBrush(Color.FromArgb(0xFF, Convert.ToByte(196), Convert.ToByte(196), Convert.ToByte(196)));
        SolidColorBrush blue = new SolidColorBrush(Color.FromArgb(0xFF, Convert.ToByte(154), Convert.ToByte(211), Convert.ToByte(245)));

        public CallCentre()
        {
            InitializeComponent();
            timer.Elapsed += Timer_Elapsed;
            timer.Interval = 1000;
            btnStop.IsEnabled = false;
            btnSubmit.IsEnabled = false;
        }
        
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke((Action)delegate
            {
                TimeSpan ts = TimeSpan.FromMilliseconds(stopwatch.ElapsedMilliseconds);

                elapsed = string.Format("{0:0} Hours, {1:0} Minutes, {2:0} Seconds", ts.Hours, ts.Minutes, ts.Seconds);
            });
        }

        private void Start(object sender, RoutedEventArgs e) {
            txtMemo.Text = "";
            timer.Start();
            stopwatch.Start();
            btnStart.Background = gray;
            btnStart.IsEnabled = false;
            btnStop.Background = red;
            btnStop.IsEnabled = true;
        }

        private void Stop(object sender, RoutedEventArgs e) {
            timer.Stop();
            stopwatch.Stop();

            stopwatch.Reset();

            btnStop.Background = gray;
            btnStop.IsEnabled = false;
            btnSubmit.Background = blue;
            btnSubmit.IsEnabled = true;
        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            List<string> CallLogParam = new List<string>();
            CallLogParam.Add(string.Format("Call on {0}", DateTime.UtcNow.ToString()));
            CallLogParam.Add(string.Format("Memo: {0}", txtMemo.Text));
            CallLogParam.Add(string.Format("Duration: {0}", elapsed));
            CallLog.getInstance().CallLogWrite(CallLogParam);
            btnStart.Background = green;
            btnStart.IsEnabled = true;
            btnSubmit.Background = gray;
            btnSubmit.IsEnabled = false;
            txtMemo.Text = "";
        }
    }
}
