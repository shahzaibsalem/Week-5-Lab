using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Student_Info
    {
        public string name;
        public int Roll_Number;
        public int Matric_Marks;
        public float Fsc_Marks;
        public float Ecat_Marks;
        public string Is_Hostellite;
        public int Semester_Fee;
        public float gpa;
        public bool is_Eligible;
        public Student_Info(string name, int Roll_Number, int Matric_Marks, float Fsc_Marks, float Ecat_Marks,string Is_Hostellite, int Semester_Fee, float gpa,bool is_Eligible)
        {
            this.name = name;
            this.Roll_Number = Roll_Number;
            this.Matric_Marks = Matric_Marks;
            this.Fsc_Marks = Fsc_Marks;
            this.Ecat_Marks = Ecat_Marks;
            this.Is_Hostellite = Is_Hostellite;
            this.Semester_Fee = Semester_Fee;
            this.gpa = gpa;
            this.is_Eligible = is_Eligible;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Name!!!!!");
            string n = Console.ReadLine();
            Console.WriteLine("Enter Roll Number!!!!!");
            int r = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Matric Marks!!!!!");
            int matric = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Fsc Marks!!!!!");
            float Fsc = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Ecat Marks!!!!!");
            float ecat = float.Parse(Console.ReadLine());
            Console.WriteLine("Hostellit!!!!!");
            string hostelide =Console.ReadLine();
            Console.WriteLine("Semester Fee!!!!!");
            int fee = int.Parse(Console.ReadLine());
            Console.WriteLine("Your GPA!!!!!");
            float gp = float.Parse(Console.ReadLine());
            bool receive=Calculate_Merit(Fsc,ecat);
            Student_Info s1 = new Student_Info(n, r, matric, Fsc, ecat, hostelide, fee,gp,receive);
            Console.Clear();
            Console.WriteLine("Here are results that you are eligible for scholarship or not!!!!");
            Console.Write("Loading");
            for(int x = 0; x<8; x++)
            {
                Console.Write(".");
            }
            Console.Clear();
            if(receive==true)
            {
                Console.WriteLine("Yes you can get!!!!!");
            }
            else
            {
                Console.WriteLine("No you cannot get!!!!!");
            }

            Console.ReadKey();
        }
        static bool Calculate_Merit(float fsc,float ecat)
        {

            bool flag=false;
            float merit;
            merit = (fsc * 0.60f) + (ecat * 0.40f);
            if (merit >= 80)
            {
                flag = true;
            }

            return flag;
        }
        
    }
}
