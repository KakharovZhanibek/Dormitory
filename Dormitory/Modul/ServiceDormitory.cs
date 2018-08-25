using GeneratorName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dormitory.Modul
{

    public class ServiceDormitory
    {
        private static int Min_salary = 24500;
        public List<Student> students;
        public List<Student> temp;

        public ServiceDormitory()
        {
            students = new List<Student>();
            temp = new List<Student>();
        }
        public void Create()
        {
            Random rnd = new Random();
            Generator gen = new Generator();
            for (int i = 0; i < rnd.Next(15, 30); i++)
            {
                Student student = new Student();
                int x = rnd.Next(2);
                string gender = gen.GenerateDefault((Gender)x);
                student.FIO = gender
                            .Replace("<center><b><font size=7>", "")
                            .Replace("</font></b></center>", "")
                            .Replace("\n", "")
                            .Substring(1);
                student.Group = "Group_" + rnd.Next(30).ToString() + (char)rnd.Next(65, 91);
                student.Average_score = (double)rnd.Next(0, 100);
                for (int j = 0; j < 2; j++)
                {
                    student.Income_per_family_member[j] = rnd.Next(25000, 100000);
                }
                student.Gender = x;
                student.StudyForm = (StudyForm)rnd.Next(2);
                temp.Add(student);
            }
        }
        public void Queue()
        {
            for (int i = 0; i < temp.Count; i++)
            {
                if (temp[i].Income_per_family_member[0] < (2 * Min_salary) && temp[i].Income_per_family_member[1] < (2 * Min_salary))
                {
                    students.Add(temp[i]);
                    temp.RemoveAt(i);
                }
            }
            for (int i = 0; i < temp.Count; i++)
            {
                if (temp[i].Income_per_family_member[0] < (2 * Min_salary) && temp[i].Income_per_family_member[1] > (2 * Min_salary) || temp[i].Income_per_family_member[0] > (2 * Min_salary) && temp[i].Income_per_family_member[1] < (2 * Min_salary))
                {
                    students.Add(temp[i]);
                    temp.RemoveAt(i);
                }
            }
            temp.OrderByDescending(u => u.Average_score);//незнаю почему но OrderBy и OrderByDescending вообще не работают
            for (int i = 0; i < temp.Count; i++)
            {
                //if (temp[i].Income_per_family_member[0] > (2 * Min_salary) && temp[i].Income_per_family_member[1] > (2 * Min_salary))
                //{
                    students.Add(temp[i]);
                    temp.RemoveAt(i);
                //}a
            }
        }
        public void Print()
        {
            foreach (Student item in students)
            {
                Console.WriteLine("\n-----------------------");
                item.Print();
                Console.WriteLine("-----------------------");
            }
        }
    }
}
