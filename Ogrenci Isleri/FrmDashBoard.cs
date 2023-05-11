using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ogrenci_Isleri
{
    public partial class FrmDashBoard : Form
    {
        StudentManager studentManager;
        public FrmDashBoard()
        {
            InitializeComponent();
            studentManager = StudentManager.GetInstance();
        }

        private void FrmDashBoard_Load(object sender, EventArgs e)
        {
            List();
        }

        void List()
        {
            DtgStudentList.DataSource = null;
            DtgStudentList.DataSource = studentManager.GetList();
            DataGridProps();
        }

        void DataGridProps() /*Datagrid özelliklerini değiştirmek için kullanılır.*/
        {
            DtgStudentList.Columns["Id"].Visible = false;
            DtgStudentList.Columns["Name"].HeaderText = "Ad Soyad";
            DtgStudentList.Columns["Mail"].HeaderText = "E-Mail";
            DtgStudentList.Columns["Phone"].HeaderText = "Telefon";
            DtgStudentList.Columns["Birthday"].HeaderText = "Doğum Tarihi";
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Student student = new Student(studentManager.GetMaxId(),TxtName.Text,TxtMail.Text,MskPhone.Text,Convert.ToDateTime(MskBrithDay.Text));
            MessageBox.Show(studentManager.AddStudent(student));
            List();
            TxtName.Text = ""; // Yeni öğrenci eklenirken araçların temizlenmesini sağlar.
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List();
        }

        private void detayaGitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DtgStudentList.CurrentRow == null)
            {
                MessageBox.Show("Detaylarını Görmek İstediğiniz Öğrenciyi Seçiniz.");
                return;
            }
            int id = (int)DtgStudentList.CurrentRow.Cells["Id"].Value;
            // CurrentRow geçerli satıra ulaştırır. Cells ise geçerli satırdaki hücreye ulaştırır.
            string name = DtgStudentList.CurrentRow.Cells["Name"].Value.ToString();
            string phone = DtgStudentList.CurrentRow.Cells["Phone"].Value.ToString();
            string mail = DtgStudentList.CurrentRow.Cells["Mail"].Value.ToString();
            DateTime datetime = (DateTime) DtgStudentList.CurrentRow.Cells["Mail"].Value;

            Student student = new Student(id,name,mail,phone,datetime);

            FrmDetail frmDetail = new FrmDetail();
            frmDetail.student = student;
            frmDetail.ShowDialog();
        }
    }
}
