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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();

            button1.Click += (sender, e) => //추가
            {
                try
                {
                    if (DataManager.Products.Exists(x => x.Reservation == true))
                    {
                        MessageBox.Show("이미 예약중인 상품입니다.");
                    }
                    else
                    {
                       Reservation reservation =new Reservation()
                        {
                            Isbn = textBox1.Text,
                            ProductName = textBox2.Text,
                            Name =textBox3.Text,
                            BuyName=textBox5.Text,
                            Buy =true
                        };
                      
                        DataManager.Reservations.Add(reservation);
                    }

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = DataManager.Products;
                    DataManager.Save();
                }
                catch (Exception ex)
                {

                }
            };

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
