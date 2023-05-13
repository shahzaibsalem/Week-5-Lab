using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace task3
{
    class Customer
    {
        public string name;
        public string city;
        public List<Products> Purchased_Products=new List<Products>();
        public void  addCusomerDetail(string name,string city,Products s)
        {
            this.name = name;
            this.city = city;
            Purchased_Products.Add(s);
        }
         public float Show_Customer_Tax()
        {
            
             float tax=0;
            for (int i = 0; i < Purchased_Products.Count; i++)
            {
                tax=Purchased_Products[i].price * 0.10f+tax;
            }
            return tax;
        }
       
    }
    class Products
    {
        public string name;
        public int price;
        public string code;

        public  Products(string name,int price,string code)
        {
            this.name = name;
            this.price = price;
            this.code = code;
        }
        public float Calculate_Tax(int price)
        {
            float total;
            total = price * 0.10f;
            return total;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\user\\Desktop\\products.txt";
            List<string> p = new List<string>();
            List<string> q = new List<string>();
           Customer cus = new Customer();
            p = loadData(path, p);
            do
            {
               
                int receive = Menu_Bar();
                if (receive == 1)
                {
                    Console.Clear();
                    for (int i = 0; i < p.Count; i++)
                    {
                        Console.WriteLine(p[i] + " ");

                    }
                    Console.WriteLine("______________________________________________");
                    string name;
                    Console.WriteLine("Enter your name!!!!");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter your city!!!!");
                    string city = Console.ReadLine();
                    Console.WriteLine("Enter the name of product!!!!");
                    name = Console.ReadLine();
                    Console.WriteLine("______________________________________________");
                    bool flag = false;
                    for (int i = 0; i < p.Count; i++)
                    {

                        if (p[i] == name)
                        {
                            flag = true;
                            int m = int.Parse(p[i+2]);
    
                            Products obj= new Products(name, m, p[i+1]);
                            cus.addCusomerDetail(n, city, obj);
                                 
                            break;
                        }  
                        else
                        {
                            flag = false;
                        }    
                    }
                    if(flag==false)
                    {
                        Console.WriteLine("Wrong Input!!!!");
                    }
                }
                    if (receive==2)
                    {
                    Console.Clear();

                    float tax1 = cus.Show_Customer_Tax();
                    Console.WriteLine("__________________________________________________");
                    Console.WriteLine("Your tax is!!!!!");
                    Console.WriteLine(tax1);
                    }
                    if(receive==3)
                    {
                    Console.Clear();
                    Console.WriteLine("______________________________________________________________");
                    for (int i = 0; i <cus.Purchased_Products.Count ; i++)
                    {
                        Console.WriteLine(cus.Purchased_Products[i].name);
                        Console.WriteLine(cus.Purchased_Products[i].price);
                        Console.WriteLine(cus.Purchased_Products[i].code);
                        
                        
                    }
                    
                    }
                    if(receive==4)
                    {
                    break;
                    }
            } while (true);
            Console.ReadKey();
        }
        static int Menu_Bar()
        {
            Console.WriteLine("1.Buy products!!!!!");
            Console.WriteLine("2.View tax!!!!");
            Console.WriteLine("3.See total Purchases!!!!");
            Console.WriteLine("4.Exit!!!!");
            int option = int.Parse(Console.ReadLine());
            return option;
        }
        static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }

            return item;
        }
        static List<string> loadData(string path, List<string> books)
        {
            int x = 0;
            if (File.Exists(path))
            {
                StreamReader filevariable = new StreamReader(path);
                string record;

                while ((record = filevariable.ReadLine()) != null)
                {
                    string book = parseData(record, 1);
                    books.Add(book);
                    
                    string book1 = parseData(record, 2);
                    books.Add(book1);
                    
                    string book2 = parseData(record, 3);
                    books.Add(book2);
                }
            }
            else
            {
                Console.WriteLine("Not exists!!!!");
            }
            return books;
        }
    }
}
