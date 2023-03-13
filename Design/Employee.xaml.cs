using Design;
using iTextSharp.text;
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
using static System.Net.Mime.MediaTypeNames;

namespace Design
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Employee : UserControl
    {
        int id;
        Context context = new Context();
        public Employee()
        {
            InitializeComponent();
            foreach (var item in context.Employee)
            {
                if (item.exist == 1)
                    EmpGrid.Items.Add(item);

            }


        }


        private void AddBtn_Click_1(object sender, RoutedEventArgs e)
        {

            if (EmpName.Text == string.Empty && EmpAge.Text == string.Empty && EmpPassword.Text == string.Empty)
            {
                MessageBox.Show("Please Enter All Data");
            }
            else
            {

                EmployeeClass emp = new EmployeeClass()
                {

                    name = EmpName.Text,
                    salary = Int32.Parse(EmpSalary.Text),
                    Age = Int32.Parse(EmpAge.Text),
                    phone = EmpPhone.Text,
                    password = EmpPassword.Text,
                    Email = EmpEmail.Text,
                    exist = 1
                };
                bool EmailFoundflag = true;
                foreach (var item in context.Employee)
                {
                    if (item.Email == emp.Email)
                    {
                        EmailFoundflag = false;
                    }
                }
                if (EmailFoundflag == false)
                {
                    MessageBox.Show("Please enter another Email");
                }
                else
                {
                    context.Employee.Add(emp);
                    context.SaveChanges();
                    EmpGrid.Items.Add(emp);
                    MessageBox.Show("Your Employee Added Successfully");
                }



            }

        }

        private void EmpGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EmpGrid.SelectedItems.Count > 0)
            {

                foreach (EmployeeClass obj in EmpGrid.SelectedItems)
                {
                    EmpEmail.Text = obj.Email.ToString();
                    EmpName.Text = obj.name;
                    EmpSalary.Text = obj.salary.ToString();
                    EmpPhone.Text = obj.phone.ToString();
                    EmpPassword.Text = obj.password.ToString();
                    EmpAge.Text = obj.Age.ToString();

                }
            }


        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EmpGrid.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Are You Sure To Update?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    foreach (EmployeeClass obj in EmpGrid.SelectedItems)
                    {
                        obj.Email = EmpEmail.Text;
                        obj.name = EmpName.Text;
                        obj.salary = Int32.Parse(EmpSalary.Text);
                        obj.Age = Int32.Parse(EmpAge.Text);
                        obj.phone = EmpPhone.Text;
                        obj.password = EmpPassword.Text;
                    }
                    EmpGrid.Items.Refresh();
                    EmployeeClass selectedemp = (EmployeeClass)EmpGrid.SelectedItem;
                    var employee = context.Employee.Where(c => c.id == selectedemp.id);
                    foreach (EmployeeClass emp in employee)
                    {
                        emp.Email = selectedemp.Email;
                        emp.name = selectedemp.name;
                        emp.salary = selectedemp.salary;
                        emp.Age = selectedemp.Age;
                        emp.phone = selectedemp.phone;
                        emp.password = selectedemp.password;
                    }
                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Your Data is not Updated");
                    foreach (EmployeeClass obj in EmpGrid.SelectedItems)
                    {
                        EmpEmail.Text = obj.Email.ToString();
                        EmpName.Text = obj.name;
                        EmpSalary.Text = obj.salary.ToString();
                        EmpPhone.Text = obj.phone.ToString();
                        EmpPassword.Text = obj.password.ToString();
                        EmpAge.Text = obj.Age.ToString();

                    }
                }

            }
            else
            {
                MessageBox.Show("Please Choose Employee To Update");

            }


        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EmpGrid.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Are You Sure To Delete?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {

                    var q = (EmployeeClass)EmpGrid.SelectedItem;

                    //context.Employee.Remove(q);
                    q.exist = 0;
                    
                    var BillQ = context.Bill.Where(x=>x.EmpId == q.id).FirstOrDefault();
                    BillQ.exist = 0;

                    var MedBillq = context.MedBills.Where(x => x.BillId == BillQ.Id).ToList();
                    foreach(var item in MedBillq)
                    {
                        item.exist = 0;
                    }

                    context.SaveChanges();
                    EmpGrid.Items.RemoveAt(EmpGrid.SelectedIndex);

                    EmpName.Text = "";
                    EmpSalary.Text = "";
                    EmpPhone.Text = "";
                    EmpPassword.Text = "";
                    EmpAge.Text = "";
                    EmpEmail.Text = "";
                }
                else
                {
                    MessageBox.Show("Ok Your Data Isnot Deleted");
                }
            }
            else
            {
                MessageBox.Show("Please Choose Employee To Delete");
            }
        }


    }
}