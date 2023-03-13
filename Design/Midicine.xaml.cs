using Project;
using System;
using System.Collections.Generic;
using System.Data;
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
using static System.Net.Mime.MediaTypeNames;


namespace Design
{
    /// <summary>
    /// Interaction logic for Midicine.xaml
    /// </summary>
    public partial class Midicine : UserControl
    {
        Context context = new Context();
        public Midicine()

        {
            InitializeComponent();
            fillGrid();
            FillcCompanyName();

        }



        private void FillcCompanyName()
        {
                CompNametb.ItemsSource = context.Company.Where(x => x.exist == 1).ToList();
                CompNametb.DisplayMemberPath = "Name";

        }

        private void fillGrid()
        {
            foreach (var item in context.Medicine)
            {
                if(item.exist==1)
                    MidGrid.Items.Add(item);

            }


        }

        private void midGrid_Selected(object sender, SelectionChangedEventArgs e)
        {
            if (MidGrid.SelectedItems.Count > 0)
            {

                foreach (Medicine obj in MidGrid.SelectedItems)
                {

                    Nametb.Text = obj.Name;
                    pricetb.Text = obj.UnitPrice.ToString();
                    Quantitytb.Text = obj.quantity.ToString();
                    ProdDate.Text = Convert.ToString(obj.ProductionDate.ToString());
                    ExpDate.Text = Convert.ToString(obj.ExpDate);
                    var comp = obj.CompID;
                    CompNametb.Text = context.Company.Where(x => x.Id == comp).Select(x => x.Name).FirstOrDefault().ToString();
                    TypeCb.Text = obj.Type;
                    comprice.Text = obj.CompanyPrice.ToString();

                }
            }


        }

        private void AddBtn_click(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            string MedicineName = (Nametb.Text).ToString();
            var namesOfMedicineLst = context.Medicine;

            foreach (Medicine medicine in namesOfMedicineLst)
            {
                if (MedicineName != medicine.Name)
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
                String name = ((Company)CompNametb.SelectedItem).Name;

                var q = context.Company.Where(i => i.Name == name).Select(i => i.Id).FirstOrDefault();
                var typeMedicine = TypeCb.Text;


                if (Nametb.Text == string.Empty || pricetb.Text == string.Empty || ProdDate.SelectedDate == null || Quantitytb.Text == string.Empty || ExpDate.SelectedDate == null)
                {
                    MessageBox.Show("Please Enter All Data");
                }
                else if (q.ToString() == "0")
                {
                    MessageBox.Show("The CompanyName Not Found");
                }
                else
                {
                    Medicine Med = new Medicine()
                    {

                        Name = Convert.ToString(Nametb.Text),
                        CompID = q,
                        Type = typeMedicine,
                        UnitPrice = Convert.ToDouble(pricetb.Text),
                        quantity = Convert.ToInt32(Quantitytb.Text),
                        ProductionDate = Convert.ToDateTime(ProdDate.Text),
                        ExpDate = Convert.ToDateTime(ExpDate.Text),
                        EnteredDate = DateTime.Now,
                        exist = 1,
                        CompanyPrice = Convert.ToDouble(comprice.Text),
                        Profit = Convert.ToDouble(pricetb.Text) - Convert.ToDouble(comprice.Text),

                    };

                    context.Medicine.Add(Med);
                    context.SaveChanges();
                    MidGrid.Items.Add(Med);
                    MessageBox.Show("The Medicine Added");
                    Nametb.Text = "";
                    TypeCb.Text = "";
                    pricetb.Text = "";
                    Quantitytb.Text = "";
                    ProdDate.Text = "";
                    ExpDate.Text = "";
                    comprice.Text = "";
                    CompNametb.SelectedIndex = -1;

                }
            }
            else
            {
                MessageBox.Show("The Medicine Exists !");
            }

        }
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

            string medicineName = Convert.ToString(Nametb.Text);
            var mid = context.Medicine.First(em => em.Name == medicineName);
            //context.Medicine.Remove(mid);
            mid.exist = 0;

            MidGrid.Items.RemoveAt(MidGrid.SelectedIndex);

            Nametb.Text = "";
            pricetb.Text = "";
            ProdDate.Text = "";
            ExpDate.Text = "";
            Quantitytb.Text = "";
            CompNametb.Text = "";
            TypeCb.Text = "";
            comprice.Text = "";
            
            context.SaveChanges();
            MessageBox.Show("The Data were Deleted");

        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {

            String name = ((Company)CompNametb.SelectedItem).Name;

            var q = context.Company.Where(i => i.Name == name).Select(i => i.Id).First();

            foreach (Medicine mo in MidGrid.SelectedItems)
            {
                mo.Name = Convert.ToString(Nametb.Text);
                mo.CompID = q;
                mo.UnitPrice = Convert.ToDouble(pricetb.Text);
                mo.quantity = Convert.ToInt32(Quantitytb.Text);
                mo.ExpDate = Convert.ToDateTime(ExpDate.Text);
                mo.ProductionDate = Convert.ToDateTime(ProdDate.Text);
                mo.CompanyPrice= Convert.ToDouble(comprice.Text);
                mo.Profit = Convert.ToDouble(pricetb.Text) - Convert.ToDouble(comprice.Text);
                mo.Type = TypeCb.Text;
            }

            MidGrid.Items.Refresh();

            var m = (Medicine)context.Medicine.Where(x => x.ID == q).First();
            foreach (Medicine selectedmid in MidGrid.SelectedItems)
            {
                foreach (Medicine emp in context.Medicine)
                {

                    if (selectedmid.Name == m.Name)
                    {
                        m.Name = selectedmid.Name;
                        m.CompID = selectedmid.CompID;
                        m.UnitPrice = selectedmid.UnitPrice;
                        m.quantity = selectedmid.quantity;
                        m.ExpDate = selectedmid.ExpDate;
                        m.ProductionDate = selectedmid.ProductionDate;
                        m.Type = TypeCb.Text;
                        m.Profit = selectedmid.Profit;
                        m.CompanyPrice = selectedmid.CompanyPrice;
                    }
                }
            }
            context.SaveChanges();
            MessageBox.Show("The Medicine is Updated");

        }


    }
}
