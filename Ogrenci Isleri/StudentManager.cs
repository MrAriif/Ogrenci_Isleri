using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Ogrenci_Isleri
{
    class StudentManager
    {
        static StudentManager studentManager;

        List<Student> students = new List<Student>()
        {
            new Student(1,"Serdar Yılmaz","serdar@gmail.com","(555) 555-5555",new DateTime(1999,11,01)),
            new Student(2,"Doğa Yıldız","dogayidiz@gmail.com","(507) 094-5165",new DateTime(2000,11,07)),
            new Student(3,"Ayşegül Çiftci","aysegul@hotmail.com","(552) 143-2375",new DateTime(2001,11,11)),
            new Student(4,"Enes Ayan","ensayn@gmail.com","(505) 525-5654",new DateTime(1998,10,22)),
            new Student(5,"Fatmanur Bağcı","ftmnrbagci@outlook.com","(532) 532-5050",new DateTime(1965,7,1))
        };

        public List<Student> GetList()
        {
            try
            {
                return students;
            }
            catch (Exception)
            {
                return new List<Student>()
                {
                    new Student(1,"Serdar Yılmaz","serdar@gmail.com","(555) 555-5555",new DateTime(1999,11,01)),
                    new Student(2,"Doğa Yıldız","dogayidiz@gmail.com","(507) 094-5165",new DateTime(2000,11,07)),
                    new Student(3,"Ayşegül Çiftci","aysegul@hotmail.com","(552) 143-2375",new DateTime(2001,11,11)),
                    new Student(4,"Enes Ayan","ensayn@gmail.com","(505) 525-5654",new DateTime(1998,10,22)),
                    new Student(5,"Fatmanur Bağcı","ftmnrbagci@outlook.com","(532) 532-5050",new DateTime(1965,7,1))
                };
            }
        }

        public string AddStudent(Student student)
        {
            try
            {
                if (!IsStudentComplete(student))
                {
                    return "Öğrenci Verileri Hatalı!";
                }
                students.Add(student);
                return student.Name + " Öğrencisi Başarıyla Eklendi.";
            }
            catch (Exception ex)
            {
                return ex.Message;
                
            }
        }

        public string UpdateStudent(Student student)
        {
            try
            {
                if (!IsStudentComplete(student))
                {
                    return "Öğrenci Verileri Hatalı!";
                }
                for (int i = 0; i < students.Count; i++)
                {
                    if (students[i].Id == student.Id)
                    {
                        students[i] = student;
                        return student.Name + " Öğrencisi Başarıyla Güncellendi.";
                    }
                }
                return "Öğrenci Bulunamadı.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DeleteStudent(Student student)
        {
            try
            {
                foreach (Student item in students)
                {
                    if (item.Id == student.Id)
                    {
                        students.Remove(item); 
                        return item.Name + " Öğrencisi Başarıyla Silindi.";
                    }
                }
                return "Öğrenci Bulunamadı.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        bool IsStudentComplete(Student student)
        {
            try
            {
                if (string.IsNullOrEmpty(student.Name) || string.IsNullOrEmpty(student.Phone) || string.IsNullOrEmpty(student.Mail) || string.IsNullOrEmpty(student.Phone))
                {
                    return false;
                }
                if (!student.Mail.Contains("@"))
                {
                    // Contains içeriyor mu diye bakmamıza yarayan metotdur.
                    return false;
                }
                if (student.Mail.Substring(student.Mail.Length-4,1) != "." && student.Mail.Substring(student.Mail.Length - 3, 1) != ".")
                {
                    return false;
                }
                MailAddress mailAddress = new MailAddress(student.Mail);
                return true;
            }
            catch
            {
                return false;
            }            
        }

        public static StudentManager GetInstance()
        {
            if (studentManager == null)
            {
                studentManager = new StudentManager();
            }
            return studentManager;
        }

        public int GetMaxId()
        {
            int maxId = students[students.Count - 1].Id;
            return maxId + 1;
        }

    }
}
