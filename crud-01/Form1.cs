using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crud_01
{
    public partial class Form1 : Form
    {
        // untuk mengambil fungsi dari class module
        Module1 mod = new Module1();
        // untuk mengambil pada column
        string id = "0";
        // apabila false berarti tambah data kalau true ubah data
        bool aksi = false;

        public Form1()
        {
            InitializeComponent();
        }

        public void awal()
        {
            dataGridView1.DataSource = mod.getData("select * from list");
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Nama";
            dataGridView1.Columns[2].HeaderText = "Alamat";
            dataGridView1.Columns[3].HeaderText = "No Telp";
            GroupBox1.Enabled = true;
            GroupBox2.Enabled = false;
            GroupBox3.Enabled = true;
            id = "0";
            aksi = false;
        }

        public void buka()
        {
            GroupBox1.Enabled = false;
            GroupBox2.Enabled = true;
            GroupBox3.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            awal();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            buka();
            MessageBox.Show(aksi+"");
            mod.clearForm(GroupBox2);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            awal();
            mod.clearForm(GroupBox2);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (mod.adaKosong(GroupBox2))
            {
                MessageBox.Show("Data masih kosong");
            }
            else
            {
                string sql;
                if (!aksi)
                {
                    sql = "insert into list values ('"+ TextBox2.Text +"','"+ TextBox3.Text +"','"+ TextBox4.Text +"')";
                    mod.exc(sql);
                    mod.clearForm(GroupBox2);
                    awal();
                    MessageBox.Show("Tambah Data");
                }
                else
                {
                    MessageBox.Show("Ubah Data");
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            aksi = true;
            buka();
        }
    }
}
