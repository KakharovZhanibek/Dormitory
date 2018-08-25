using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dormitory.Modul
{
    public enum StudyForm { intramular, extramular }
    public class Student
    {
        public string FIO { get; set; }
        public string Group { get; set; }
        public double Average_score { get; set; }
        public int[] Income_per_family_member;
        public int Gender { get; set; }
        public StudyForm StudyForm { get; set; }
        public Student()
        {
            Income_per_family_member = new int[2];
        }
        public Student(string FIO, string Group, double Average_score, int Min_salary)
        {
            Random rnd = new Random();
            this.FIO = FIO;
            this.Group = Group;
            this.Average_score = Average_score;
            Income_per_family_member = new int[2];
            this.StudyForm = (StudyForm)rnd.Next(2);
        }
        public void Print()
        {
            Console.WriteLine("ФИО : " + FIO);
            Console.WriteLine("Группа : " + Group);
            Console.WriteLine("Средний балл : " + Average_score);
            Console.WriteLine("Доход на члена семьи : ");
            foreach (int item in Income_per_family_member)
            {
                Console.WriteLine("\t" + item);
            }
            if (Gender == 0)
            {
                Console.WriteLine("Пол : Женщина");
            }
            else
            {
                Console.WriteLine("Пол : Мужчина");
            }
            Console.WriteLine("Форма обучения : " + StudyForm);
        }
    }
}
