using Project;
using System.Windows.Controls;
using System.Windows;
using System;

using iTextSharp.xmp.impl;
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
using System.Windows.Shapes;
using System.Xml.Linq;
using static Azure.Core.HttpHeader;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Design
{
    /// <summary>
    /// Interaction logic for Return.xaml
    /// </summary>
    public partial class Return : UserControl
    {
        Context context = new Context();
        protected internal static string MedName;
        protected internal static double MedProfit;
        public Return()
        {
            InitializeComponent();
        }



        private void showDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(BIllIdTB.Text);
            var name = MedName;
            var exist = context.MedBills.Any(x => x.BillId == id);
            var billexist = context.Bill.Any(x => x.Id == id);
            if (exist == true)
            {
                var q = context.MedBills.Where(x => x.BillId == id).FirstOrDefault();
                var bill = context.Bill.Where(x => x.Id == q.BillId).FirstOrDefault();
                DateTime day = bill.Date;
                DateTime daynow = DateTime.Now;
                int validDay = (daynow - day).Days;

                if (validDay > 1)
                {
                    MessageBox.Show("Not Valid To Return");
                }
                else
                {

                    // int id = ((Company)CompNametb.SelectedItem).Id;

                    foreach (var item in context.MedBills)
                    {
                        if (item.BillId == id)
                        {

                            BillGrid.Items.Add(item);
                             }

                    }
                }
            }
            else
            {
                MessageBox.Show("please enter valid Bill Id");
            }

        }


        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(BIllIdTB.Text);
            int oldQ = Convert.ToInt32(Quantytb.Text);


            var name = MedName;
            var q = context.MedBills.Where(x => x.MedicineName == name && x.BillId == id).FirstOrDefault();
            var med = context.Medicine.Where(x => x.Name == name).FirstOrDefault();
            var bill = context.Bill.Where(x => x.Id == q.BillId).FirstOrDefault();
            if (oldQ == q.Quantity)
            {
                MedProfit = med.Profit * oldQ;
                q.TotalProfit -= MedProfit;
                med.quantity += q.Quantity;
                context.MedBills.Remove(q);
                //context.Bill.Remove(bill);
                //BillGrid.Items.Clear();
                BillGrid.Items.RemoveAt(BillGrid.SelectedIndex);
                BillGrid.Items.Refresh();
                Quantytb.Text = "";


            }
            else if (Convert.ToInt32(Quantytb.Text) < 0 || (Convert.ToInt32(Quantytb.Text) > q.Quantity))
            {
                MessageBox.Show("NotValid");
            }
            else
            {
                med.quantity += Convert.ToInt32(Quantytb.Text);
                q.Quantity -= Convert.ToInt32(Quantytb.Text);
                // context.SaveChanges();
                BillGrid.Items.Refresh();
            }
            context.SaveChanges();
            var exist = context.MedBills.Any(x => x.BillId == id);
            var billexist = context.Bill.Any(x => x.Id == id);
            if (billexist == true && exist == false)
            {
                var bills = context.Bill.Where(x => x.Id == id).FirstOrDefault();
                context.Bill.Remove(bills);
            }
            context.SaveChanges();
            if (BillGrid.Items.Count == 0)
            {
                BIllIdTB.Text = "";
            }

        }
        private void BillGrid_Selected(object sender, SelectionChangedEventArgs e)
        {
            if (BillGrid.SelectedItems.Count > 0)
            {

                foreach (MedBills obj in BillGrid.SelectedItems)
                {
                    Quantytb.Text = obj.Quantity.ToString();

                    MedName = obj.MedicineName.ToString();


                }
            }
        }
    }
}