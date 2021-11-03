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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            label5.Text = DataManager.Products.Count.ToString(); //전체 물품 수
            label6.Text = DataManager.Users.Count.ToString(); //오늘 근무자 수
            label7.Text = DataManager.Products.Where((x) => x.Reservation).Count().ToString();//예약 걸린 물품 수
            label8.Text = DataManager.Products.Where((x) => x.IsNeeded).Count().ToString();  //재고부족 물품수

            dataGridView1.DataSource = DataManager.Products;
            dataGridView2.DataSource = DataManager.Users;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e) //전체 물품수
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                Product product = dataGridView1.CurrentRow.DataBoundItem as Product;
                textBox1.Text = product.Isbn;
                textBox2.Text = product.ProductName;
            }
            catch (Exception ex)
            {

            }
        }

        private void dataGridView2_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                User user = dataGridView1.CurrentRow.DataBoundItem as User;
                textBox3.Text = user.Id.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e) //판매
        {
            Product product = DataManager.Products.Single(x => x.Isbn == textBox1.Text); //하나를 반환해준다
            if (product.Reservation)
            {
                MessageBox.Show("이미 예약중인 상품입니다.");
            }
            else
            {
                User user = DataManager.Users.Single(x => x.Id == textBox3.Text);
                product.Amount--;
                MessageBox.Show("/" + product.ProductName + "/을 " + user.Name + "/님이 판매하였습니다.");
                
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = DataManager.Products;
                DataManager.Save();

                
            }
        }

        private void button2_Click(object sender, EventArgs e) //예약버튼 누르면 예약관리 페이지로 이동
        {
            new Form4().ShowDialog();
            /* if (textBox1.Text.Trim() == "")
             {

             }
             else if (textBox2.Text.Trim() == "")
             {

             }
             else
             {
                 try
                 {
                     Product product = DataManager.Products.Single(x => x.Isbn == textBox1.Text); //하나를 반환해준다
                     if (product.Reservation)
                     {
                         MessageBox.Show("이미 예약중인 상품입니다.");
                     }
                     else
                     {
                         User user = DataManager.Users.Single(x => x.Id == textBox3.Text);
                         product.Reservation = true;

                         dataGridView1.DataSource = null;
                         dataGridView1.DataSource = DataManager.Products;
                         DataManager.Save();
                     }
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show("존재하지 않는 근무자/품목 입니다.");
                 }
             }*/
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 직원관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
        }

        private void 예약관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form3().ShowDialog();
        }

        private void 예약관리ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Form4
                ().ShowDialog();
        }
    }
}
