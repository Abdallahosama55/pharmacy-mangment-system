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
    public partial class Profit : UserControl
    {
        Context context = new Context();

        public Profit()
        {
            InitializeComponent();
            

        }
    
        private void Show_Click(object sender, RoutedEventArgs e)
        {
            double sum = 0;
            var query = context.MedBills.Where(b => b.Date.Month == ShowDate.SelectedDate.Value.Month).ToList();
            foreach (var item in query)
            {
                sum += item.TotalProfit;
            }
            Badgett.Content = sum;

        }



        private void Showday_Click(object sender, RoutedEventArgs e)
        {
            double sum = 0;
            var query = context.MedBills.Where(b => b.Date.Day == ShowDate.SelectedDate.Value.Day).ToList();
            foreach (var item in query)
            {
                sum += item.TotalProfit;
                //MessageBox.Show(""+item.TotalProfit);
            }
            Badgett.Content = sum;
        }

        private void Showyear_Click(object sender, RoutedEventArgs e)
        {
            double sum = 0;
            var query = context.MedBills.Where(b => b.Date.Year == ShowDate.SelectedDate.Value.Year);
            foreach (var item in query)
            {
                sum += item.TotalProfit;
            }
            Badgett.Content = sum;
        }
    }
}