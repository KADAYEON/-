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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            dataGridView1.DataSource = DataManager.Users;
            dataGridView1.CurrentCellChanged += DataGridView1_CurrentCellChanged;


     


            button2.Click += (sender, e) =>
             {
                 try
                 {
                     User user = DataManager.Users.Single((x) => x.Id == textBox1.Text);
                     user.Name = textBox2.Text;

                     dataGridView1.DataSource = null;
                     dataGridView1.DataSource = DataManager.Users;
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show("존재하지 않는 근무자입니다.");
                 }
             };           
        }

        private void DataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                User user = dataGridView1.CurrentRow.DataBoundItem as User;
                textBox1.Text = user.Id;
                textBox2.Text = user.Name;
            }
            catch(Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("Id를 입력해야 합니다");
            else if (DataManager.Users.Exists((x) =>x.Id ==textBox1.Text))
                MessageBox.Show("사용자 Id 가 겹칩니다");
            else
            {
                User user = new User()
                {
                    Id = textBox1.Text,
                    Name = textBox2.Text
                };
                DataManager.Users.Add(user);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = DataManager.Users;
                DataManager.Save();
            }
        }

        private void button4_Click(object sender, EventArgs e) //출퇴근 처리
        {
            if (textBox3.Text == "")
                MessageBox.Show("Id를 입력해야 합니다");
            else if (textBox4.Text == "")
                MessageBox.Show("근무자 이름을 입력해주세요");
            else
            {
                User user = new User()
                {
                    Id = textBox3.Text,
                    Name = textBox4.Text,
                    AttendTime = DateTime.Now,
                    Attend = true
                    
                };

            }
        }
    }
}
