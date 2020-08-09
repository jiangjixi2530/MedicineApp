using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Medicine.App
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            Btn_FileChoose.Click += Btn_FileChoose_Click;
            Btn_Match.Click += Btn_Match_Click;
            Panel_Exit.Click += Panel_Exit_Click;
            Panel_MiniSize.Click += Panel_MiniSize_Click;
        }

        private void Panel_MiniSize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Panel_Exit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("确定退出系统吗？","提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)== DialogResult.OK)
            {
                Close();
                Environment.Exit(0);
            }
        }

        private void Btn_Match_Click(object sender, EventArgs e)
        {
            if (Label_FilePath.Text.Length == 0)
            {
                MessageBox.Show("请先选择文件");
                return;
            }
            try
            {
                ExcelHelper helper = new ExcelHelper();
                helper.OpenExcel(Label_FilePath.Text);
                List<Medichine> medichines = helper.ExcelToList<Medichine>().ToList();
                var newMedichines = medichines.Where(x => x.药品名称 != null && x.药品名称.Length > 0).GroupBy(x => new { x.药品名称, x.药品编码, x.规格, x.厂家, x.单位, x.包装规格 }).Select(y => new Medichine
                {
                    药品编码 = y.Key.药品编码,
                    药品名称 = y.Key.药品名称,
                    规格 = y.Key.规格,
                    厂家 = y.Key.厂家,
                    单位 = y.Key.单位,
                    包装规格 = y.Key.包装规格,
                    基本数量 = y.Sum(s => s.基本数量)
                }).ToList();
                var matchMedichines = helper.ExcelToList<Medichine>(1).ToList();
                foreach (var medichine in newMedichines)
                {
                    var matched = matchMedichines.Find(x => x.药品名称 == medichine.药品名称);
                    if (matched != null)
                    {
                        medichine.货位号 = matched.货位号;
                    }
                }
                newMedichines = newMedichines.OrderBy(x => x.货位号).ToList();
                helper.ImportToExcel<Medichine>(newMedichines, DateTime.Now.ToString("yyyy-MM-dd"));
                Grid_Medichines.DataSource = newMedichines;
                MessageBox.Show("匹配成功，文件已修改");
            }
            catch (Exception ex)
            {
                MessageBox.Show("出错了！！" + ex.Message);
            }
        }

        private void Btn_FileChoose_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "请选择源文件";
            openFileDialog.Filter = "Excel文件|*.xls;*.xlsx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Label_FilePath.Text = openFileDialog.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "请选择源文件";
            openFileDialog.Filter = "Excel文件|*.xls;*.xlsx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExcelHelper helper = new ExcelHelper();
                helper.OpenExcel(openFileDialog.FileName);
                List<Medichine> medichines = helper.ExcelToList<Medichine>().ToList();
                medichines.RemoveAll(x => x.基本数量 == 0);
                var newMedichines = medichines.Where(x=>x.药品名称!=null&&x.药品名称.Length>0).GroupBy(x => new { x.药品名称, x.药品编码, x.规格, x.厂家, x.单位, x.包装规格 }).Select(y => new Medichine
                {
                    药品编码 = y.Key.药品编码,
                    药品名称 = y.Key.药品名称,
                    规格 = y.Key.规格,
                    厂家 = y.Key.厂家,
                    单位 = y.Key.单位,
                    包装规格 = y.Key.包装规格,
                    基本数量 = y.Sum(s => s.基本数量)
                }).ToList();
                var matchMedichines = helper.ExcelToList<Medichine>(1).ToList();
                foreach (var medichine in newMedichines)
                {
                    var matched = matchMedichines.Find(x => x.药品名称 == medichine.药品名称);
                    if (matched != null)
                    {
                        medichine.货位号 = matched.货位号;
                    }
                }
                newMedichines = newMedichines.OrderBy(x => x.货位号).ToList();
                helper.ImportToExcel<Medichine>(newMedichines, DateTime.Now.ToString("yyyy-MM-dd"));
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            Color color = Color.FromArgb(214, 214, 214);
            Padding p = new Padding(1);
            ButtonBorderStyle style = ButtonBorderStyle.Solid;
            ControlPaint.DrawBorder(e.Graphics, panel4.ClientRectangle,
                color, p.Left, style,
                color, p.Top, style,
                color, p.Right, style,
                color, p.Bottom, style
                );
        }

        private void Grid_Medichines_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
    }
}
