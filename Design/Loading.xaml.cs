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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Design
{
    public partial class Loading : Window
    {
        DispatcherTimer timer ;

        public Loading()
        {
            timer = new DispatcherTimer();
            InitializeComponent();
            timer.Tick += new EventHandler(WaitingEvent);
            timer.Interval = new TimeSpan(0, 0, 2);
            timer.Start();

        }
        public void WaitingEvent(object source, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.Show();
            timer.Stop();

        }
    }
}
