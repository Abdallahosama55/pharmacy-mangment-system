using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.IO;
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
using Project;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace Design
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : UserControl
    {
        protected internal static string EmpN;
        protected internal static string EmpEmail;
        protected internal static int BID;
        protected internal static double BTotal;
        protected internal static double TotalProfit;
        protected internal static int Medicid;

        Context context = new Context();
        public MainWindow()
        {

            InitializeComponent();
            fillBill();

        }

        private void fillBill()
        {
            Bill bill = new Bill();
            bill.Date = DateTime.Now;
            var q = context.Employee.Where(e => e.Email == EmpN).Select(e => e.id).FirstOrDefault();
            bill.EmpId = q;
            bill.exist = 1;
            context.Bill.Add(bill);
            context.SaveChanges();
            BID = bill.Id;// context.Bill.Where(e=>e.EmpId==q).FirstOrDefault();
        }

        private void DataGridTextColumn_Click(object sender, RoutedEventArgs e)
        {

        }


        private void StackPanel_Loaded(object sender, RoutedEventArgs e)
        {

        }


        List<Medicine> Medicine = new List<Medicine>();

        private void SelectMedicines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var name = ((Medicine)SelectMedicines.SelectedItem).Name;
            var query = context.Medicine.Where(n => n.Name == name).FirstOrDefault();
            if (query.quantity == 0)
            {

                //  context.Medicine.Remove(query);
                AvailableMedicines.Text = "Available Medicines = Out Of stock";

            }
            else
            {
                AvailableMedicines.Text = "Available Medicines = " + query.quantity.ToString();
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            //SelectMedicines.ItemsSource = context.Medicine.Where(x => x.exist == 1).Select(x => x.Name).ToList();
            SelectMedicines.ItemsSource = context.Medicine.Where(x => x.exist == 1).ToList();
            SelectMedicines.DisplayMemberPath = "Name";

        }

        //Add to bill
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String name = ((Medicine)SelectMedicines.SelectedItem).Name;
            var query = context.Medicine.Where(n => n.Name == name).FirstOrDefault();


            var q = context.Employee.Where(e => e.Email == EmpN).FirstOrDefault();

            if (int.Parse(QuantityTextbox.Text.ToString()) > query.quantity)
            {
                MessageBox.Show("Not Valid Quantatity!");
            }
            else if (int.Parse(QuantityTextbox.Text.ToString()) <= query.quantity && q.exist==1)
            {

                query.quantity = query.quantity - int.Parse(QuantityTextbox.Text);
                AvailableMedicines.Text = "Available Medicines = " + query.quantity.ToString();

                
                MedBills bill = new MedBills()
                {

                    MedicineName = query.Name,
                    Quantity = int.Parse(QuantityTextbox.Text),
                    UnitPrice = query.UnitPrice,
                    TotalPrice = (query.UnitPrice * int.Parse(QuantityTextbox.Text.ToString())),
                    EmployeeName = EmpN,
                    BillId = BID,
                    Date = DateTime.Now,
                    exist = 1,
                    MedId = context.Medicine.Where(m => m.Name == query.Name).Select(n => n.ID).FirstOrDefault(),

                };
                Medicid = bill.MedId;
                var query1 = context.Medicine.Where(m => m.ID == Medicid).FirstOrDefault();
                bill.TotalProfit += query1.Profit * bill.Quantity;
                context.Add(bill);
                context.SaveChanges();
                BTotal += bill.TotalPrice;
                BillId.Content = BID;
                Totalprice.Content = BTotal;
                // Add the new Medicines object to the underlying collection for the DataGrid

                DataGridBill.Items.Add(bill);


            }

            // Refresh the DataGrid to display the new rows
            DataGridBill.Items.Refresh();

        }
        // Print Bill Button
        void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            if (printDlg.ShowDialog() == true)
            {

                printDlg.PrintVisual(DataGridBill, "Bill");

            }
            fillBill();
            DataGridBill.Items.Clear();
            BillId.Content = "";
            Totalprice.Content = "";
            QuantityTextbox.Text = " ";
            BTotal = 0;

        }

        


    }
}
