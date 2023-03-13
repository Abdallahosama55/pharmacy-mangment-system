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

namespace Design
{
    /// <summary>
    /// Interaction logic for ReportDashboard.xaml
    /// </summary>
    public partial class ReportDashboard : Window
    {
        public ReportDashboard()
        {
            InitializeComponent();
        }

        private void History_Click(object sender, RoutedEventArgs e)
        {

            Controll.Content = new History();
        }

      

        private void companies_Click(object sender, RoutedEventArgs e)
        {
            Controll.Content = new report();
        }

        private void profit_Click(object sender, RoutedEventArgs e)
        {
           Controll.Content=new Profit();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Dashboard d=new Dashboard();
            d.Show();
            this.Close();
        }
    }
}
