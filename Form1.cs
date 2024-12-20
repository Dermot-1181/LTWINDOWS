using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using De01.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace De01
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            

        }

        private Model1 context = new Model1();

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txthoten_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbblophoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ngaysinh_ValueChanged(object sender, EventArgs e)
        {

        }

        private void bttim_Click(object sender, EventArgs e)
        {
            try
            {
                
                string keyword = txttim.Text.Trim();

               
                List<Sinhvien> listSinhVien;
                if (string.IsNullOrEmpty(keyword))
                {
                    listSinhVien = context.Sinhviens.ToList();
                }
                else
                {
                   
                    listSinhVien = context.Sinhviens
                        .Where(sv => sv.HoTenSV.Contains(keyword))
                        .ToList();
                }

             
                if (listSinhVien.Count == 0)
                {
                    MessageBox.Show($"Không tìm thấy sinh viên nào!", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

              
                BindGrid(listSinhVien);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btthem_Click(object sender, EventArgs e)
        {
            try
            {
                Sinhvien sv = new Sinhvien
                {
                    MaSV = txtMsv.Text,
                    HoTenSV = txthoten.Text,
                    NgaySinh = ngaysinh.Value,
                    MaLop = cbblophoc.SelectedValue.ToString()
                };
                context.Sinhviens.Add(sv);
                context.SaveChanges();
                MessageBox.Show("Thêm sinh viên thành công!");
                RefreshForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            

        }

        private void btsua_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(txtMsv.Text))
                {
                    MessageBox.Show("Vui lòng nhập mã sinh viên để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var maSV = txtMsv.Text.Trim();
                var sv = context.Sinhviens.FirstOrDefault(x => x.MaSV == maSV);

                if (sv == null)
                {
                    MessageBox.Show("Không tìm thấy sinh viên có mã: " + maSV, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                btluu.Enabled = true;
                btkluu.Enabled = true;

                MessageBox.Show("Đang chỉnh sửa sinh viên. Nhấn 'Lưu' để hoàn tất hoặc 'Không Lưu' để hủy bỏ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void btluu_Click(object sender, EventArgs e)
        {
            try
            {
                
                context.SaveChanges();
                MessageBox.Show("Thao tác đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                RefreshForm();
                btluu.Enabled = false;
                btkluu.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btkluu_Click(object sender, EventArgs e)
        {

        }

        private void bthoat_Click(object sender, EventArgs e)
        {
            this.Close(); var result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void RefreshForm()
        {
            txtMsv.Clear();
            txthoten.Clear();
            ngaysinh.Value = DateTime.Now;
            cbblophoc.SelectedIndex = -1;
            var listSinhVien = context.Sinhviens.ToList();
            BindGrid(listSinhVien);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

                var listLop = context.Lops.ToList();
                FillLopCombobox(listLop);

                var listSinhVien = context.Sinhviens.ToList();
                BindGrid(listSinhVien);


                btluu.Enabled = false;
                btkluu.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void FillLopCombobox(List<Lop> listLop)
        {
            cbblophoc.DataSource = listLop;
            cbblophoc.DisplayMember = "TenLop";
            cbblophoc.ValueMember = "MaLop";
        }
        private void BindGrid(List<Sinhvien> listSinhVien)
        {
            dataGridView1.Rows.Clear();
            foreach (var sv in listSinhVien)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = sv.MaSV;
                dataGridView1.Rows[index].Cells[1].Value = sv.HoTenSV;
                dataGridView1.Rows[index].Cells[2].Value = sv.NgaySinh.HasValue ? sv.NgaySinh.Value.ToString("dd/MM/yyyy") : "";
                dataGridView1.Rows[index].Cells[3].Value = sv.Lop.TenLop;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtMsv.Text = row.Cells[0].Value.ToString();
                txthoten.Text = row.Cells[1].Value.ToString();
                ngaysinh.Value = DateTime.Parse(row.Cells[2].Value.ToString());
                cbblophoc.Text = row.Cells[3].Value.ToString();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtMsv.Text = row.Cells[0].Value.ToString();

                txthoten.Text = row.Cells[1].Value.ToString();
                ngaysinh.Value = DateTime.Parse(row.Cells[2].Value.ToString());
                cbblophoc.Text = row.Cells[3].Value.ToString();
            }
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                
                string keyword = txttim.Text.Trim();

                
                if (string.IsNullOrEmpty(keyword))
                {
                    MessageBox.Show("Vui lòng nhập tên sinh viên cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            
                var listSinhVien = context.Sinhviens
                    .Where(sv => sv.HoTenSV.Contains(keyword))
                    .ToList();

      
                if (listSinhVien.Count == 0)
                {
                    MessageBox.Show($"Không tìm thấy sinh viên nào có tên chứa '{keyword}'!", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                BindGrid(listSinhVien);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
