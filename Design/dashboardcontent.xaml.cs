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
    public partial class dashboardcontent : UserControl
    {
        Context context=new Context();
        public dashboardcontent()
        {
            InitializeComponent();


            //Label l = new Label();
            //if (l.Name == "Employees")
            //{
            //    l.Content = context.Employee.Count().ToString();
            //}
            //if (l.Name == "Campanies")
            //{
            //    l.Content = context.Company.Count().ToString();
            //}
            //if (l.Name == "avaliable")
            //{
            //    l.Content = context.Medicine.Count().ToString();
            //}
        }


        private void On_DashBoardLoaded(object sender, RoutedEventArgs e)
        {
        
            ComCount.Content = context.Company.Count().ToString();

            empCount.Content = context.Employee.Count().ToString();

            midCount.Content = context.Medicine.Count().ToString();

            billCount.Content = context.MedBills.Count().ToString();
        }
    }
}
