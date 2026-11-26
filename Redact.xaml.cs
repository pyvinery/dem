
using System;
using System.Linq;
using System.Windows;

namespace dem
{
    public partial class Redact : Window
    {
        demEntities db = new demEntities();
        private string article;

        public Redact(string articul = null)
        {
            InitializeComponent();

            article = articul;

            if (article != null)
            {
                var t = db.Tovar.FirstOrDefault(x => x.Articul == article);

                if (t != null)
                {
                    txtArticle.Text = t.Articul;
                    txtArticle.IsReadOnly = true;
                    txtName.Text = t.Name;
                    txtEdIzm.Text = t.EdIzm;
                    txtPrice.Text = t.Price.ToString();
                    txtPostav.Text = t.Postav;
                    txtProizvod.Text = t.Proizvod;
                    txtCategoria.Text = t.Categoria;
                    txtSale.Text = t.Sale.ToString();
                    txtKolichestvo.Text = t.Kolichestvo.ToString();
                    txtDescription.Text = t.Description;
                    txtPhoto.Text = t.Photo;
                }
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtArticle.Text) ||
                    string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Заполните артикул и название");
                    return;
                }

                if (!decimal.TryParse(txtPrice.Text, out decimal price) ||
                    price < 0 || price > 99999999.99m)
                {
                    MessageBox.Show("Введите правильную цену");
                    return;
                }

                if (!byte.TryParse(txtSale.Text, out byte sale))
                {
                    MessageBox.Show("Неверная скидка");
                    return;
                }

                if (!byte.TryParse(txtKolichestvo.Text, out byte quantity))
                {
                    MessageBox.Show("Неверное количество");
                    return;
                }

                Tovar t;

                if (article == null)
                {
                    if (db.Tovar.Any(x => x.Articul == txtArticle.Text))
                    {
                        MessageBox.Show("Такой артикул уже существует");
                        return;
                    }

                    t = new Tovar();
                    t.Articul = txtArticle.Text;
                    db.Tovar.Add(t);
                }
                else
                {
                    t = db.Tovar.First(x => x.Articul == article);
                }

                t.Name = txtName.Text;
                t.EdIzm = txtEdIzm.Text;
                t.Price = price;
                t.Postav = txtPostav.Text;
                t.Proizvod = txtProizvod.Text;
                t.Categoria = txtCategoria.Text;
                t.Sale = sale;
                t.Kolichestvo = quantity;
                t.Description = txtDescription.Text;
                t.Photo = txtPhoto.Text;

                db.SaveChanges();

                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения: " + ex.Message);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
