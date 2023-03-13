
using Design;
using Project;
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

namespace Design
{
    public partial class Dashboard : Window
    {
        Context context = new Context();
        public Dashboard()
        {
            InitializeComponent();
           Controll.Content=new dashboardcontent(); 

        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            this.IsTabStop = true;
        }

        private void Medicine_Click(object sender, RoutedEventArgs e)
        {
            Controll.Content = new Midicine();
        }

        private void company_click(object sender, RoutedEventArgs e)
        {
            Controll.Content = new company();
        }

        private void Employee_click(object sender, RoutedEventArgs e)
        {
            Controll.Content = new Employee();
        }

        private void report_click(object sender, RoutedEventArgs e)
        {
            //Controll.Content = new report();
            ReportDashboard r=new ReportDashboard();
            r.Show();
            this.Close();
        }

        private void return_click(object sender, RoutedEventArgs e)
        {
            Controll.Content = new Return();
        }

        private void bill_click(object sender, RoutedEventArgs e)
        {
            Controll.Content = new MainWindow();
        }

        private void logout_click(object sender, RoutedEventArgs e)
        {
            
            Login l = new Login();
            l.Show();
            this.Close();

        }
    }
}
