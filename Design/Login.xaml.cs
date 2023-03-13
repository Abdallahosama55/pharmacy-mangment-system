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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Design
{
    public partial class Login : Window
    {
        protected internal static string empName;
        Context context = new Context();

        public Login()
        {
            InitializeComponent();
        }



        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {



        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool testadmin = txt1.Text.Contains("@admin");
            var query =
            from E in context.Employee
            where testadmin == true
            select new { E.Email, E.password, E.name };
            foreach (var item in query)
            {   
                if (txt1.Text == item.Email && txt2.Password == item.password)
                {
                    MainWindow.EmpN = item.Email;
                    MainWindow.EmpEmail = item.Email;
                    Dashboard d = new Dashboard();
                    d.Show();
                    this.Close();

                }
                else if (txt1.Text == item.Email && txt2.Password != item.password)
                {
                    //MessageBox.Show("Enter valid Password");
                }
                else if (txt1.Text != item.Email && txt2.Password == item.password)
                {
                    //MessageBox.Show("Enter valid Username");
                }
                else if (txt1.Text == "" && txt2.Password == "")
                {
                    MessageBox.Show("Enter Username and Password");

                }


            }

            bool testEmp = txt1.Text.Contains("@Employee");
            var query2 =
            from E in context.Employee
            where testEmp == true
            select new { E.Email, E.password, E.name };

            foreach (var item in query2)
            {
                if (txt1.Text == item.Email && txt2.Password == item.password)
                {
                    MainWindow.EmpN = item.Email;
                    MainWindow.EmpEmail = item.Email;
                    EmployeeDashboard ed = new EmployeeDashboard();
                    ed.Show();
                    this.Close();

                }
                else if (txt1.Text == item.Email && txt2.Password != item.password)
                {
                    MessageBox.Show("Enter valid Password");
                }
                else if (txt1.Text != item.Email && txt2.Password == item.password)
                {
                    MessageBox.Show("Enter valid Username");
                }
                
                else if (txt1.Text == "" && txt2.Password == "")
                {
                    MessageBox.Show("Enter Username and Password");

                }
                

            }
            



        }

    }

}
