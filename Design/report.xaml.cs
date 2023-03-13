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
using Project;
namespace Design
{
    public partial class report : UserControl
    {
        Context context = new Context();
        public report()
        {
            InitializeComponent();
            FillCompanyName();

        }
        private void FillCompanyName()
        {
            //CompNametb.ItemsSource = context.Company.Where(x => x.exist == 1).Select(x => x.Name).ToList();
            CompNametb.ItemsSource = context.Company.Where(x => x.exist == 1).ToList();
            CompNametb.DisplayMemberPath = "Name";

        }
        private void fillGrid()
        {
            int id = ((Company)CompNametb.SelectedItem).Id;

            foreach (var item in context.Medicine)
            {
                if (item.CompID == id)
                {

                    MidGrid.Items.Add(item);
                }

            }



        }

        private void CompNametb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MidGrid.Items.Clear();
            fillGrid();

        }


      
       
    }
}
