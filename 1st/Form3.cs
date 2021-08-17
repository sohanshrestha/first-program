using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1st
{
    public partial class Form3 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-B1F19A3\SQLEXPRESS;Initial Catalog=1stForm;Integrated Security=True");
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //open sql connection
                conn.Open();
                string st_name = std_name.Text;
                string st_address = std_address.Text;


                string querry = "Insert into std_details (name,address) values (@parameter_name,@parameter_address)";
                SqlCommand cmd = new SqlCommand(querry, conn);
                cmd.Parameters.AddWithValue("@parameter_name", st_name);
                cmd.Parameters.AddWithValue("@parameter_address", st_address);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Saved Successfully");
                std_address.Text = "";
                std_name.Text = "";

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            DisplayData();


            //string name = std_name.Text;
            //string address = std_address.Text;
            //dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, name, address);
        }
        private void DisplayData()
        {
            try
            {
                //open sql connection
                conn.Open();


                string querry = "select * from std_details ";
                SqlCommand cmd = new SqlCommand(querry, conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                dataGridView1.Rows.Clear();
                int sn = 0;
                foreach (DataRow dataRow in dt.Rows)
                {
                    sn++;
                    dataGridView1.Rows.Add(sn, dataRow["id"], dataRow["name"], dataRow["address"],"Edit");
                }

              
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //open sql connection
                conn.Open();

                if (dataGridView1.SelectedRows.Count > 0)
                {
                    //single row delete
                    //dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);

                    //multiple data delete
                    foreach(DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        int id = Convert.ToInt32(row.Cells["StdID"].Value);

                        string query = "Delete from std_details where id=@parameter_id";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@parameter_id", id);
                        cmd.ExecuteNonQuery();
                        dataGridView1.Rows.RemoveAt(row.Index);
                        MessageBox.Show("Removed Successfully.");

                    }
                    //int i = 0;
                    //foreach (DataGridViewRow row in dataGridView1.Rows)
                    //{
                    //    i++;
                    //    row.Cells["SN"].Value = i;
                    //}
                }
                else
                {
                    MessageBox.Show("Please Select rows to delete! ");
                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            DisplayData();

            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        int student_id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Action"].Index)
            {
                student_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["StdID"].Value.ToString());
                string student_name = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
                string student_address = dataGridView1.CurrentRow.Cells["Address"].Value.ToString();

                std_name.Text = student_name;
                std_address.Text = student_address;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (student_id != 0)
                {
                    //open sql connection
                    conn.Open();
                    string st_name = std_name.Text;
                    string st_address = std_address.Text;


                    string querry = "Update std_details set name=@parameter_name,address=@parameter_address where id=@parameter_id";
                    SqlCommand cmd = new SqlCommand(querry, conn);
                    cmd.Parameters.AddWithValue("@parameter_id", student_id);
                    cmd.Parameters.AddWithValue("@parameter_name", st_name);
                    cmd.Parameters.AddWithValue("@parameter_address", st_address);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Saved Successfully");
                    std_address.Text = "";
                    std_name.Text = "";
                    student_id = 0;
                }
                else
                {
                    MessageBox.Show("Please Edit data before update! ");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            DisplayData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            std_name.Text = "";
            std_address.Text = "";
            student_id = 0;
        }

        OpenFileDialog openfiledialog = new OpenFileDialog();
        private void button5_Click(object sender, EventArgs e)
        {
            openfiledialog.Filter = "Image only. |*.jpeg; *.jpg; *.png";
            if(openfiledialog.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openfiledialog.FileName);    
            }
            else
            {
                MessageBox.Show("Operation Canceled!! ");
            }
        }
    }
}
