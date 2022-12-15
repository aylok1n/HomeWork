using System;
using System.IO;
using System.Collections.Generic;

namespace HomeWork
{

    class Abonent
    {
        public string name;
        public string number;

        public Abonent(string _name, string _number)
        {
            name = _name;
            number = _number;
        }
    }
    class PhoneBook
    {
        public List<Abonent> abonents = new List<Abonent>();
        private static PhoneBook instance;

        private PhoneBook()
        {
            try
            {
                foreach (string elem in File.ReadAllText("./abonents.txt").Split(Environment.NewLine))
                {
                    string[] abonentData = elem.Split(":");
                    if (abonentData.Length == 2)
                    {
                        abonents.Add(new Abonent(abonentData[0], abonentData[1]));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static PhoneBook getInstance()
        {
            if (instance == null)
                instance = new PhoneBook();
            return instance;
        }

        #nullable enable
        private Abonent? Get(string arg) => abonents.Find(abonent => abonent.name == arg || abonent.number == arg);

        private void Add(string name, string number)
        {
            abonents.Add(new Abonent(name, number));
            new StreamWriter(@"./abonents.txt", true).WriteLine(name + ":" + number);
        }

        private void Delete(Abonent abonent) => abonents.Remove(abonent);

        public void GetAbonent()
        {
            Console.Write("Введите имя или номер");
            string arg = Console.ReadLine();
            Abonent? abonent = Get(arg);
            Console.WriteLine();
            if (abonent != null)
            {
                Console.WriteLine("Имя: " + abonent.name);
                Console.WriteLine("Номер: " + abonent.number);
            }
            else
            {
                Console.WriteLine("Абонент не найден");
            }
        }
        public void AddAbonent()
        {
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите номер: ");
            string number = Console.ReadLine();

            if(abonents.Exists(abonent => abonent.name == name || abonent.number == number))
            {
                Console.WriteLine("Такой абонент уже существует");
            }
            else
            {
                Add(name, number);
            }
        }

        public void DeleteAbonent()
        {
            Console.Write("Введите имя или номер");
            string arg = Console.ReadLine();
            Abonent? abonent = Get(arg);
            Console.WriteLine();
            if (abonent != null)
            {
                Delete(abonent);
            }
            else
            {
                Console.WriteLine("Абонент не найден");
            }
        }

        public static void Start()
        {
            // TODO add cli like interface
            getInstance().AddAbonent();
        }
    }
   
}
