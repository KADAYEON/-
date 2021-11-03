using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 가게관리_최종
{
    public partial class Form3 : Form //재고 관리
    {
        public Form3()
        {
            InitializeComponent();

            dataGridView1.DataSource = DataManager.Products;
            dataGridView1.CurrentCellChanged += DataGridView1_CurrentCellChanged;

            button1.Click += (sender, e) => //추가
             {
                 try
                 {
                     if (DataManager.Products.Exists(x => x.Isbn == textBox1.Text))
                     {
                         MessageBox.Show("이미 존재하는 상품입니다.");
                     }
                     else
                     {
                         Product product = new Product()
                         {
                             Isbn = textBox1.Text,
                             ProductName = textBox2.Text,
                             Amount = int.Parse(textBox3.Text),
                             Price = int.Parse(textBox4.Text),
                             Company = textBox5.Text
                         };
                         DataManager.Products.Add(product);
                     }

                     dataGridView1.DataSource = null;
                     dataGridView1.DataSource = DataManager.Products;
                     DataManager.Save();
                 }
                 catch (Exception ex)
                 {

                 }
             };

            button2.Click += (sender, e) => //수정
            {
                try
                {
                    Product product = DataManager.Products.Single(x => x.Isbn == textBox1.Text);
                    product.ProductName = textBox2.Text;
                    product.Amount = int.Parse(textBox3.Text);
                    product.Price = int.Parse(textBox4.Text);
                    product.Company = textBox5.Text;

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = DataManager.Products;
                    DataManager.Save();
                }catch(Exception ex)
                {

                }
            };
        }

        private void Button2_Click(object sender, EventArgs e) //수정
        {
            throw new NotImplementedException();
        }

        private void DataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                Product product = dataGridView1.CurrentRow.DataBoundItem as Product;
                textBox1.Text = product.Isbn;
            }catch(Exception ex)
            {

            }
            /*throw new NotImplementedException();*/
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                Product product = dataGridView1.CurrentRow.DataBoundItem as Product;
                textBox1.Text = product.Isbn;
                textBox2.Text = product.ProductName;
                textBox3.Text = product.Amount.ToString();
                textBox4.Text = product.Price.ToString();
                textBox5.Text = product.Company;
                

            }
            catch(Exception ex)
            {

            }
            
        }

        private void button3_Click(object sender, EventArgs e) //삭제
        {
            try
            {
                Product product = DataManager.Products.Single(x => x.Isbn == textBox1.Text);
                DataManager.Products.Remove(product);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = DataManager.Products;
                DataManager.Save();
            }catch(Exception ex)
            {

            }
        }
    }
}
