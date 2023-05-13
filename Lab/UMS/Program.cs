using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS
{
    class Students
    {
       public string name;
       public string city;
       public int Matric_Marks;
       public int Fsc_Marks;
       public int Ecat_Marks;
       public double Merit;
       public int count;
       public List<string> p = new List<string>();
       public List<Subjects> q = new List<Subjects>();
       
        public Students(string name,string city,int Matric_Marks, int Fsc_Marks, int Ecat_Marks,List<string>p, double Merit)
        {
            this.name = name;
            this.city = city;
            this.Matric_Marks = Matric_Marks;
            this.Fsc_Marks = Fsc_Marks;
            this.Ecat_Marks = Ecat_Marks;
            this.p = p;
            this.Merit = Merit;
        }
        public Students()
        {

        }
    }
    class Registered_Subjects
    {
        public List<string> Registered=new List<string>();
        public int count;
        public Registered_Subjects(List<string> Registered,int count)
        {
            this.Registered = Registered;
            this.count = count;
        }
    }

    class Subjects
    {
       public List<string> Departments = new List<string>();
       public List<string> subjects = new List<string>();
       public List<int> Credit_Hours=new List<int>();
       public int count;
        public Subjects(List<string> Departments,List<string>subjects, List<int> Credit_Hours,int count)
        {
            this.Departments = Departments;
            this.subjects = subjects;
            this.Credit_Hours = Credit_Hours;
            this.count = count;
        }
        public Subjects()
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Students> stu = new List<Students>();
            List<Subjects> subj = new List<Subjects>();
            List<Registered_Subjects> reg = new List<Registered_Subjects>();
            List<string> dep = new List<string>();
            List<string> sub = new List<string>();
            List<int> CH = new List<int>();
            List<string> preferences = new List<string>();
            string name;
            string city;
            int matric;
            int fsc;
            int ecat;
            double Highest_Merit=0;
            double merit;
            do
            {
                Console.Clear();
                int receive = Menu_Bar();
                Console.Clear();
                if (receive==1)
                {
                    Console.Clear();
                    Console.WriteLine("_________________________________________________");
                    Console.WriteLine("Enter Name!!!!");
                    name=Console.ReadLine();
                    Console.WriteLine("Enter City!!!!");
                    city=Console.ReadLine();
                    Console.WriteLine("Enter Matric Marks!!!!");
                    matric=int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Fsc Marks!!!!");
                    fsc=int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Ecat Marks!!!!");
                    ecat=int.Parse(Console.ReadLine());
                    Console.WriteLine("How many prefrences you want to enter?");
                    int pref = int.Parse(Console.ReadLine());
                    for(int i =0; i<pref;i++)
                    {
                        int add = i + 1;
                        Console.WriteLine("Enter your " + add + " prefrence!!!!");
                        string p = Console.ReadLine();
                        preferences.Add(p);
                    }
                    merit = (matric * 0.1) + (fsc * 0.6) + (ecat * 0.3);
                    Students obj = new Students(name,city,matric,fsc,ecat,preferences,merit);
                    stu.Add(obj);
                }
                if (receive == 2)
                {
                    Console.Clear();
                    Console.WriteLine("_________________________________________________");
                    int num;
                    int count=0;
                    string department;
                    Console.WriteLine("How many departments you want to enter?");
                    num = int.Parse(Console.ReadLine());
                    for (int i = 0; i < num; i++)
                    {
                        string depart;
                        Console.WriteLine("Enter departmment name!!!!");
                        depart = Console.ReadLine();
                        dep.Add(depart);
                    }
                    Console.WriteLine("How many subjects you want to enter?");
                    num = int.Parse(Console.ReadLine());
                    for(int i =0; i<num; i++)
                    {
                        string subjects;
                        int Credit_Hour;
                        Console.WriteLine("Enter subject name!!!!");
                        subjects = Console.ReadLine();
                        sub.Add(subjects);
                        Console.WriteLine("Enter subject credit hours!!!!");
                        Credit_Hour = int.Parse(Console.ReadLine());
                        CH.Add(Credit_Hour);
                        count++;
                    }
                    Subjects obj = new Subjects(dep,sub,CH,count);
                    subj.Add(obj);
                }
                if (receive == 3)
                {
                    Console.Clear();
                    Console.WriteLine("_________________________________________________");
                    Console.WriteLine(" NAME:      " + " MERIT:     ");
                    for (int i = 0; i < stu.Count; i++)
                    {
                        Console.WriteLine(stu[i].name+" " +" "+ stu[i].Merit);
                    }
                    Console.ReadKey();
                }
                if (receive == 4)
                {
                    Console.Clear();
                    Console.WriteLine("_________________________________________________");
                    Console.WriteLine("Enter your name!!!!");
                    string n = Console.ReadLine();
                    for (int i = 0; i < stu.Count; i++)
                    {
                        if (n==stu[i].name)
                        {
                            if (stu[i].Merit > Highest_Merit)
                            {
                                Console.WriteLine("Congratulations!!!!!!!! You got admission in " + stu[i].p[i]);
                                Console.ReadKey();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Sorryy!!!! You did not get the admission");
                                Console.ReadKey();
                                break;
                            }
                        }
                        
                    }
                }
                if (receive == 5)
                {
                    Console.Clear();
                    Console.WriteLine("_________________________________________________");
                    for (int i = 0; i < stu.Count; i++)
                    {
                        if (stu[i].Merit > Highest_Merit)
                        {
                            Highest_Merit = stu[i].Merit;
                        }
                    }
                    Console.WriteLine("Highest merit is :" + Highest_Merit);
                    Console.ReadKey();
                }
                if (receive == 6)
                {
                    string subject=" ";
                    List<string> s = new List<string>();
                    Console.Clear();
                    Console.WriteLine("_________________________________________________");
                    int count = 0;
                    int check=0;
                    Console.WriteLine("How many subjects you want to registered!!!!");
                    int num=int.Parse(Console.ReadLine());
                    for(int i =0; i<num; i++)
                    {
                        Console.WriteLine("Enter subject name!!!!");
                        subject = Console.ReadLine();
                        for (int j = 0; j < subj.Count; j++)
                        {
                            for (int k = 0; k < subj[j].subjects.Count; k++)
                            {
                                if (subj[j].subjects[k] == subject)
                                {
                                    check = check + subj[j].Credit_Hours[k];
                                }
                                else
                                {
                                    Console.WriteLine("Wrong Input!!!!");
                                }
                            }
                        }
                        count++;
                    }
                    if (check > 9)
                    {
                        Console.WriteLine("You cannot registered greater than 9 credit hours!!!!");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Success!!!!");
                        Console.ReadKey();
                        s.Add(subject);
                        Registered_Subjects obj = new Registered_Subjects(s, count);
                        reg.Add(obj);
                    }
                }
                if (receive == 7)
                {
                    Console.Clear();
                    break;
                }

            } while (true);
            Console.ReadKey();
        }
        static int Menu_Bar()
        {
            int option;
            Console.WriteLine("1.Add Student!!!!");
            Console.WriteLine("2.Add Subjects and departments!!!!");
            Console.WriteLine("3.View all students merit!!!!");
            Console.WriteLine("4.See your result!!!!");
            Console.WriteLine("5.View Highest Merit!!!!");
            Console.WriteLine("6.Registered subjects!!!!");
            Console.WriteLine("7.Exit!!!!");
            option = int.Parse(Console.ReadLine());
            return option;
        }
    }
}
