using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CRUD
{
    public partial class Form1 : Form
    {
        //string strCon = @"Data Source=DESKTOP-UML28IP;Initial Catalog=COMPANY_MANAGEMENT;Integrated Security=True";
        SqlConnection sqlConn = new SqlConnection(@"Data Source=DESKTOP-UML28IP;Initial Catalog=COMPANY_MANAGEMENT;Integrated Security=True");

        private void openCon()
        {
            if(sqlConn.State == ConnectionState.Closed)
            {
                sqlConn.Open();
            }
        }

        private void closeCon()
        {
            if(sqlConn.State == ConnectionState.Open)
            {
                sqlConn.Close();
            }
        }

        private Boolean exe(string cmd)
        {
            openCon();
            Boolean check;
            try
            {
                SqlCommand sc = new SqlCommand(cmd, sqlConn);
                sc.ExecuteNonQuery();
                check = true;
            }
            catch(Exception)
            {
                check = false;
            }
            closeCon();
            return check;
        }

        private DataTable read(string cmd)
        {
            openCon();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sc = new SqlCommand(cmd, sqlConn);
                SqlDataAdapter sda = new SqlDataAdapter(sc);
                sda.Fill(dt);
            }
            catch (Exception)
            {
                dt = null;
                throw;
            }
            closeCon();
            return dt;
        }

        private void loadData()
        {
            //DataTable dt = new DataTable();
            DataTable dt = read("SELECT * FROM NHANVIEN");
            if(dt != null)
            {
                dataGridView1.DataSource = dt;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //loadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tb_maten.ResetText();
            tb_ten.ResetText();
            tb_ns.ResetText();
            tb_gt.ResetText();
            tb_cv.ResetText();
            tb_luong.ResetText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            exe("INSERT INTO NHANVIEN(MANV, TENNV, NGAYSINH, GIOITINH, CHUCVU, LUONG) VALUES(" + int.Parse(tb_maten.Text) + ", N'" + tb_ten.Text + "', '" + tb_ns.Text + "', N'" + tb_gt.Text + "', N'" + tb_cv.Text + "', " + int.Parse(tb_luong.Text) + ")");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            exe("UPDATE NHANVIEN SET TENNV = N'" + tb_ten.Text + "', NGAYSINH = '" + tb_ns.Text + "', GIOITINH = N'" + tb_gt.Text + "', CHUCVU = N'" + tb_cv.Text + "', LUONG = " + int.Parse(tb_luong.Text) + "WHERE MANV = " + tb_maten.Text);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tb_maten.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tb_ten.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tb_ns.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tb_gt.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tb_cv.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tb_luong.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            exe("DELETE FROM NHANVIEN WHERE MANV = " + int.Parse(tb_maten.Text));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataTable dt = read("SELECT * FROM NHANVIEN WHERE TENNV = N'" + tb_ten.Text + "' OR GIOITINH = N'" + tb_gt.Text + "' OR CHUCVU = N'" + tb_cv.Text + "' OR LUONG = " + int.Parse(tb_luong.Text));
            if(dt != null)
            {
                dataGridView1.DataSource = dt;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            loadData();
        }
    }
}