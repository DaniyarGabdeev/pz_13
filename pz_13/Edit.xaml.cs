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

namespace pz_13
{
    /// <summary>
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        public Edit(string model,string maker,string type)
        {
            InitializeComponent();
            model_txt.Text = model;
            marker_txt.Text = maker;
            type_txt.Text = type;
            using (Connector db = new Connector())
            {
                db.Product.Remove(new ProductItem() { maker = marker_txt.Text, model = model_txt.Text, type = type_txt.Text });
                db.SaveChanges();
            }
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            using(Connector db = new Connector()) 
            {
                db.Product.Add(new ProductItem() { maker = marker_txt.Text, model = model_txt.Text, type = type_txt.Text });
                db.SaveChanges();
            }
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
