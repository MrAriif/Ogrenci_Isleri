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
    public partial class FrmDetail : Form
    {
        public Student student;
        StudentManager studentManager;

        public FrmDetail()
        {
            InitializeComponent();
            studentManager = StudentManager.GetInstance();
        }

        private void FrmDetail_Load(object sender, EventArgs e)
        {
            StudentInfos();
        }
        
        void StudentInfos()
        {
            TxtName.Text = student.Name;
            TxtMail.Text = student.Mail;
            MskPhone.Text = student.Phone;
            MskBrithDay.Text = student.Birthday.ToString();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(student.Name+ " Öğrencisi İçin Güncelleme İşlemi Yapılacaktır.Emin Misiniz?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                
                Student newStudent = new Student(student.Id, TxtName.Text, TxtMail.Text, MskPhone.Text, Convert.ToDateTime(MskBrithDay.Text));
                studentManager.UpdateStudent(newStudent);
            }

            
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(student.Name + " Öğrencisi İçin Silme İşlemi Yapılacaktır.Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                studentManager.DeleteStudent(student.Id);
            }
        }
    }
}
