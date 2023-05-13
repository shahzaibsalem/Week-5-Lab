using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_2
{
    class Books_Library
    {
       public int book_Price;
       public int book_Chapters;
       public string book_Author;
       public List<string> Chapters_Names = new List<string>();
        public Books_Library(int book_Price, int book_Chapters, string book_Author,List<string>Chapters_Names)
        {
            this.book_Price = book_Price;
            this.book_Chapters = book_Chapters;
            this.book_Author = book_Author;
            this.Chapters_Names = Chapters_Names;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {            
            string path = "C:\\OOP Week 5\\Lab\\Task 2\\Books_Info.txt";
            List<string> books = new List<string>();
            int receive = loadData(path, books);
            Books_Library s = new Books_Library(1000,receive,"Taha",books);
            do
            {
                Console.WriteLine("What you want to see!!!!");
                string n = Console.ReadLine();
                Console.Clear();
                if (n == "price")
                {
                    Console.WriteLine(s.book_Price);
                }
                if (n == "author")
                {
                    Console.WriteLine(s.book_Author);
                }
                if (n == "total chapters")
                {
                    Console.WriteLine(s.book_Chapters);
                }
                if (n == "see chapters")
                {
                    for(int i =0;i<books.Count;i++)
                    {
                        Console.WriteLine(books[i]);
                    }                   
                }
            } while (true);
            Console.ReadKey();
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
        static int loadData(string path , List<string>books)
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
                    x++;
                    string book1 = parseData(record, 2);
                    books.Add(book1);
                    x++;
                    string book2 = parseData(record, 3);
                    books.Add(book2);
                    x++;
                    string book3 = parseData(record, 4);
                    books.Add(book3);
                    x++;
                }
            }
            else
            {
                Console.WriteLine("Not exists!!!!");
            }
            return x;
        }
    }
}
