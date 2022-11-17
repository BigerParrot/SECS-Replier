using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SECSCtrlLibs
{
    public partial class FileOpenForm : Form
    {
        List<ListViewItem> nowItems = new List<ListViewItem>();
        List<string> lastPath = new List<string>();
        bool isHomePage = true;
        private string pathSelect = string.Empty;
        EFileFormType style = EFileFormType.Files;

        public string PathSelect { get { return pathSelect; } }

        public EFileFormType Style { set { style = value; } get { return style; } }
        public FileOpenForm(EFileFormType style)
        {
            InitializeComponent();

            this.style = style;
            ListViewSet();
            DoHomePage();
        }

        private void ListViewSet()
        {
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Name = "file_name";
            buttonColumn.Text = "File Name";
            int columnIndex = 0;
            if (dgv_main.Columns["file_name"] == null)
            {
                dgv_main.Columns.Insert(columnIndex, buttonColumn);
            }

            dgv_main.Columns.Add("type","Type");
            dgv_main.Columns.Add("file_path","File Path");

            dgv_main.Columns[0].Width = 150;
            dgv_main.Columns[1].Width = 50;
            dgv_main.Columns[2].Width = 400;
        }
        private void DoHomePage()
        {
            dgv_main.Rows.Clear();
            int x = 0;
            isHomePage = true;
            lastPath.Clear();
            foreach (DriveInfo info in DriveInfo.GetDrives())
            {
                DataGridViewRow item = (DataGridViewRow)dgv_main.Rows[x].Clone();
                item.Cells[0].Value = info.Name;
                item.Cells[1].Value = "Driver";
                dgv_main.Rows.Add(item);
                x++;
            }
        }

        private void DoPathRefresh(string path)
        {
            tbx_path.Text = string.Format(path);
            dgv_main.Rows.Clear();
            isHomePage = false;
            lastPath.Add(path);
            string[] folders = Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly);
            string[] filePaths = Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly);
            int x = 0;
            foreach (string info in folders)
            {
                DataGridViewRow item = (DataGridViewRow)dgv_main.Rows[x].Clone();
                item.Cells[0].Value = Path.GetFileName(info);
                item.Cells[1].Value = "Folder";
                item.Cells[2].Value = info;
                dgv_main.Rows.Add(item);
                x++;
            }

            if (style == EFileFormType.Files)
            {
                x = 0;
                foreach (string info in filePaths)
                {
                    DataGridViewRow item = (DataGridViewRow)dgv_main.Rows[x].Clone();
                    item.Cells[0].Value = Path.GetFileName(info);
                    item.Cells[1].Value = Path.GetExtension(info);
                    item.Cells[2].Value = info;
                    dgv_main.Rows.Add(item);
                    x++;
                }
            }
        }

        private void Selection(string path, string fileName)
        {
            DialogResult result;
            result = MessageBox.Show(string.Format("Would you like to open file: {0}", fileName),"Check",MessageBoxButtons.YesNo);
            if (result.Equals(DialogResult.Yes))
            {
                pathSelect = path;
                this.Close();
            }
        }

        private void dgv_main_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgvNow = (DataGridView)sender;
            string path = string.Empty;
            if (dgvNow.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (dgv_main.Rows.Count > e.RowIndex + 1)
                {
                    if (isHomePage)
                    {
                        path = dgv_main.Rows[e.RowIndex].Cells[0].Value.ToString();
                    }
                    else
                    {
                        path = dgv_main.Rows[e.RowIndex].Cells[2].Value.ToString();
                    }
                    if (Directory.Exists(path))
                    {
                        DoPathRefresh(path);
                    }
                    else if (!isHomePage)
                    {
                        try
                        {
                            Selection(path, Path.GetFileName(path));
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.ToString());
                        }
                    }
                }
            }
        }

        private void btn_HomePage_Click(object sender, EventArgs e)
        {
            DoHomePage();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            if (lastPath.Count > 1)
            {
                string path = lastPath[lastPath.Count - 2];
                lastPath.Remove(lastPath[lastPath.Count - 1]);
                lastPath.Remove(lastPath[lastPath.Count - 1]);
                DoPathRefresh(path);
            }
            else
            {
                DoHomePage();
            }
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            pathSelect = tbx_path.Text;
            this.Hide();
        }
    }

    public enum EFileFormType : int
    {
        Files,
        Folders,
    }
}
