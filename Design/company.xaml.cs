using Design;
using Project;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;

using System.Security.Policy;
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
    public partial class company : UserControl
    {
        Context context = new Context();
        public company()
        {
            InitializeComponent();
            FillGridOnLoad();
        }

        private void FillGridOnLoad()
        {
            
            foreach (var item in context.Company)
            {
                if (item.exist ==1)
                    CompanyGrid.Items.Add(item);

            }

        }

        private void Add_btn(object sender, RoutedEventArgs e)
        {

            bool flag = false;
            string CompName = (NameTb.Text).ToString();
            var namesOfCompanyList = context.Company;

            foreach (Company company1 in namesOfCompanyList)
            {
                if (CompName != company1.Name)
                {
                    flag = true;

                }
                else
                {
                    flag = false;
                }
            }

            if (flag)
            {
                if (NameTb.Text == string.Empty || PhoneTb.Text == string.Empty || AddressTb.Text == string.Empty)
                {
                    MessageBox.Show("Please Enter All Data");
                }
                else
                {

                    Company company = new Company()
                    {
                        Name = Convert.ToString(NameTb.Text),
                        Phone = PhoneTb.Text,
                        Address = AddressTb.Text,
                        exist=1
                    };

                    context.Company.Add(company);
                    context.SaveChanges();

                    CompanyGrid.Items.Add(company);

                    MessageBox.Show("The Company Added");
                    NameTb.Text = "";
                    PhoneTb.Text = "";
                    AddressTb.Text = "";
                }
            }
            else
            {
                MessageBox.Show("The Company is Exists !");
            }
        }

        private void Delete_btn(object sender, RoutedEventArgs e)
        {
            
            //MessageBox.Show("The Data Before Deleted" + context.Company.Count());

            string companyName = Convert.ToString(NameTb.Text);

            var comp = context.Company.First(x => x.Name == companyName);

            //context.Company.Remove(emp);

            comp.exist = 0;
            context.SaveChanges();


            CompanyGrid.Items.RemoveAt(CompanyGrid.SelectedIndex);

            PhoneTb.Text = "";
            NameTb.Text = "";
            AddressTb.Text = "";


            MessageBox.Show("The Data were Deleted");
        }

        private void Update_btn(object sender, RoutedEventArgs e)
        {
            foreach (Company company in CompanyGrid.SelectedItems)
            {
                company.Name = NameTb.Text;
                company.Phone = PhoneTb.Text;
                company.Address = AddressTb.Text;


            }

            CompanyGrid.Items.Refresh();


            foreach (Company selectedmcomp in CompanyGrid.SelectedItems)
            {
                foreach (Company company in context.Company)
                {

                    if (selectedmcomp.Name == company.Name)
                    {
                        company.Name = selectedmcomp.Name;
                        company.Id = selectedmcomp.Id;
                        company.Address = selectedmcomp.Address;
                        company.Phone = selectedmcomp.Phone;

                    }
                }
            }
            context.SaveChanges();

            MessageBox.Show("The Data is Updated");
        }

        private void RowSelected_datagrid(object sender, SelectionChangedEventArgs e)
        {


            if (CompanyGrid.SelectedItems.Count > 0)
            {

                foreach (Company obj in CompanyGrid.SelectedItems)
                {

                    NameTb.Text = obj.Name;
                    PhoneTb.Text = obj.Phone;
                    AddressTb.Text = obj.Address;


                }
            }


        }

    }
}


