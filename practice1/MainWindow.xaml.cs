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
using practice1.prac1DataSetTableAdapters;
using System.Data;

namespace practice1
{
    
    public partial class MainWindow : Window
    {
        firmTableAdapter firm = new firmTableAdapter();
        shopTableAdapter shop = new shopTableAdapter();
        phoneTableAdapter phone = new phoneTableAdapter();
        phone_shopTableAdapter phone_shop = new phone_shopTableAdapter();
        int idFirm = 0; int idFirm1 = 0; int idPhone = 0; int idShop = 0; int sw = 0;
        public MainWindow()
        { 
            
            InitializeComponent();
            grid.ItemsSource = firm.GetData();
            select.ItemsSource = phone.GetData();
            select.DisplayMemberPath = "firm_name";
            grid1.ItemsSource = shop.GetData();
            grid2.ItemsSource = phone.GetData();
            grid3.ItemsSource = phone_shop.GetData();
            cmb1.ItemsSource = firm.GetData();
            cmb1.DisplayMemberPath = "firm_name";
            cmb2.ItemsSource = firm.GetData();
            cmb2.DisplayMemberPath = "firm_name";
            cmb3.ItemsSource = phone.GetData();
            cmb3.DisplayMemberPath = "phone_name";
            cmb4.ItemsSource = shop.GetData();
            cmb4.DisplayMemberPath = "shop_name";
        }

        private void select_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (select.SelectedItem as DataRowView).Row[0];
            MessageBox.Show(cell.ToString());
        }
        private void Badd_Click(object sender, RoutedEventArgs e)
        {
            firm.AddFirmName(tbx.Text);
            grid.ItemsSource = firm.GetData();
        }

        private void Badd1_Click(object sender, RoutedEventArgs e)
        {
            shop.AddShopName(tbx1.Text);
            grid1.ItemsSource = shop.GetData();
        }

        private void Badd2_Click(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt32(tbx22.Text);
            phone.AddPhone(tbx2.Text, tbx21.Text, a, idFirm);
            grid2.ItemsSource = phone.GetData();
        }

       

        private void cmb1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (cmb1.SelectedItem as DataRowView).Row[0];
            idFirm = (int)cell;
        }

        private void cmb2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell1 = (cmb2.SelectedItem as DataRowView).Row[0];
            idFirm1 = (int)cell1;
        }

        private void cmb4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell2 = (cmb4.SelectedItem as DataRowView).Row[0];
            idShop = (int)cell2;
        }

        private void cmb3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell3 = (cmb3.SelectedItem as DataRowView).Row[0];
            idPhone = (int)cell3;
        }

        private void Badd3_Click_1(object sender, RoutedEventArgs e)
        {
            int a1 = Convert.ToInt32(tbx3.Text);
            int b1 = Convert.ToInt32(tbx31.Text);
            int c1 = Convert.ToInt32(tbx32.Text);
            phone_shop.AddPhone_shop(a1, b1, c1, idFirm1, idPhone, idShop);
            grid3.ItemsSource = phone_shop.GetData();
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            object id = (grid.SelectedItem as DataRowView).Row[0];
            firm.DeleteFirm(Convert.ToInt32(id));
            grid.ItemsSource = firm.GetData();
        }

        private void del1_Click(object sender, RoutedEventArgs e)
        {
            object id = (grid1.SelectedItem as DataRowView).Row[0];
            shop.DeleteShop(Convert.ToInt32(id));
            grid1.ItemsSource = shop.GetData();
        }

        private void del2_Click(object sender, RoutedEventArgs e)
        {
            object id = (grid2.SelectedItem as DataRowView).Row[0];
            phone.DeletePhone(Convert.ToInt32(id));
            grid2.ItemsSource = phone.GetData();
        }

        private void del3_Click(object sender, RoutedEventArgs e)
        {
            object id = (grid3.SelectedItem as DataRowView).Row[0];
            phone_shop.DeletePhone_shop(Convert.ToInt32(id));
            grid3.ItemsSource = phone_shop.GetData();
        }

        private void Bupd_Click(object sender, RoutedEventArgs e)
        {
            object id = (grid.SelectedItem as DataRowView).Row[0];
            firm.UpdFirm(tbx.Text, Convert.ToInt32(id));
            grid.ItemsSource = firm.GetData();
        }

        private void Bupd1_Click(object sender, RoutedEventArgs e)
        {
            object id = (grid1.SelectedItem as DataRowView).Row[0];
            shop.UpdShop(tbx1.Text, Convert.ToInt32(id));
            grid1.ItemsSource = shop.GetData();
        }

        private void Bupd2_Click(object sender, RoutedEventArgs e)
        {
            object id = (grid2.SelectedItem as DataRowView).Row[0];
            int a = Convert.ToInt32(tbx22.Text);
            phone.UpdatePhone(tbx2.Text, tbx21.Text, a, idFirm, Convert.ToInt32(id));
            grid2.ItemsSource = phone.GetData();
        }

        private void Bupd3_Click(object sender, RoutedEventArgs e)
        {
            object id = (grid3.SelectedItem as DataRowView).Row[0];
            int a1 = Convert.ToInt32(tbx3.Text);
            int b1 = Convert.ToInt32(tbx31.Text);
            int c1 = Convert.ToInt32(tbx32.Text);
            phone_shop.UpdatePhone_shop(a1, b1, c1, idFirm1, idPhone, idShop, Convert.ToInt32(id));
            grid3.ItemsSource = phone_shop.GetData();
        }

        private void grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sw == 0)
            {
                tbx.Text = (grid.SelectedItem as DataRowView).Row[1].ToString();
                sw = 1;
            }
            else sw = 0;
        }

        private void grid2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (sw == 0)
            {
                tbx2.Text = (grid2.SelectedItem as DataRowView).Row[1].ToString();
                tbx21.Text = (grid2.SelectedItem as DataRowView).Row[2].ToString();
                tbx22.Text = (grid2.SelectedItem as DataRowView).Row[3].ToString();
                sw = 1;
            }
            else sw = 0;
            
        }

        private void grid3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (sw == 0)
            {
                tbx3.Text = (grid3.SelectedItem as DataRowView).Row[1].ToString();
                tbx31.Text = (grid3.SelectedItem as DataRowView).Row[2].ToString();
                tbx32.Text = (grid3.SelectedItem as DataRowView).Row[3].ToString();
                sw = 1;
            }
            else sw = 0;
            
        }

        private void grid1_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (sw == 0)
            {
                tbx1.Text = (grid1.SelectedItem as DataRowView).Row[1].ToString();
                sw = 1;
            }
            else sw = 0;
        }
    }
}
