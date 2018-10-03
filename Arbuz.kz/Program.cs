using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using static Classes.Function;
using System.Diagnostics;

namespace Arbuz.kz
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo key;
            int y = 1;
            int menuOperation = 1;

            Dictionary<string, string> account = new Dictionary<string, string>();            
            int isIn = 0;            
            Basket basket = new Basket();
            basket.Product = new List<Product>();

            List<Product> products = new List<Product>();
            int size = 26;
            Product[] productArray = new Product[size];
            productArray[0] = new Product("велосипед", 50000, "отдых");
            productArray[1] = new Product("дорожная сумка", 5000, "отдых");
            productArray[2] = new Product("палатка", 23000, "отдых");
            productArray[3] = new Product("мангал", 2000, "отдых");
            productArray[4] = new Product("купальник", 500, "отдых");
            productArray[5] = new Product("подводные очки", 350, "отдых");
            productArray[6] = new Product("удка", 15000, "отдых");
            productArray[7] = new Product("лодка", 60, "отдых");
            productArray[8] = new Product("коньки", 250, "отдых");
            productArray[9] = new Product("штанга", 200, "отдых");
            productArray[10] = new Product("samsung x", 50000, "техника");
            productArray[11] = new Product("iphone x", 5000, "техника");
            productArray[12] = new Product("стиральная машина ", 23000, "техника");
            productArray[13] = new Product("микроволновая печь", 2000, "техника");
            productArray[14] = new Product("ноутбук", 500, "техника");
            productArray[15] = new Product("компьютер", 350, "техника");
            productArray[16] = new Product("принтер фыв", 15000, "техника");
            productArray[17] = new Product("мышка", 60, "техника");
            productArray[18] = new Product("монитор", 250, "техника");
            productArray[19] = new Product("телик", 200, "техника");
            productArray[20] = new Product("шорты", 50000, "одежда");
            productArray[21] = new Product("фтболка", 5000, "одежда");
            productArray[22] = new Product("штаны", 23000, "одежда");
            productArray[23] = new Product("джинсы", 2000, "одежда");
            productArray[24] = new Product("костюм", 500, "одежда");
            productArray[25] = new Product("шляпа", 350, "одежда");
            foreach (Product p in productArray)
                products.Add(p);

            Browsing browsing;

            int sum = 0;
            string productName;
           

            while (true)
            {
                MenuAuth(ref y);
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.DownArrow)
                {
                    if (y < 3) y++;
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    if (y > 1) y--;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;                   
                    Console.SetCursorPosition(0, 1);


                    if (y == 1)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(0, 10);
                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.WriteLine("Введите логин: ");
                        string loginIn = Console.ReadLine();
                        Console.WriteLine("Введите пароль: ");
                        string passwordIn = Console.ReadLine();

                        foreach (KeyValuePair<string, string> keyValue in account)
                        {
                            if (keyValue.Key == loginIn)
                            {
                                if (keyValue.Value == passwordIn)
                                {
                                    isIn = 1;
                                    //status = 1;
                                }
                            }
                        }
                        if (isIn != 1) break;
                        //menuOperation-----------
                        Console.Clear();
                        Console.SetCursorPosition(0, 10);
                        Console.ForegroundColor = ConsoleColor.Green;
                        bool menuOperBool = false;
                        while (!menuOperBool)
                        {
                            MenuOperation(ref menuOperation);
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.DownArrow)
                            {
                                if (menuOperation < 5) menuOperation++;
                            }
                            else if (key.Key == ConsoleKey.UpArrow)
                            {
                                if (menuOperation > 1) menuOperation--;
                            }
                            else if (key.Key == ConsoleKey.Enter)
                            {
                                //Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.SetCursorPosition(15, 1);


                                switch (menuOperation)
                                {
                                    case 1:
                                        Console.Clear();
                                        Console.WriteLine("введите необходимую категорию: 1-отдых, " +
                                                          " 2-техника,  3-одежда");
                                        bool isTrue = false;
                                        int kategory = 0;
                                        while (isTrue == false)
                                        {
                                            try
                                            {
                                                Browsing.StringToInt(Console.ReadLine(), ref kategory);
                                                isTrue = true;
                                            }
                                            catch (Exception e)
                                            {
                                                Console.WriteLine(e.Message);
                                            }
                                        }                                        
                                        isTrue = false;

                                        switch (kategory)
                                        {
                                            case 1://prosmotr po kategoriam
                                                browsing = new Browsing("отдых", products);
                                                for (int i = 0; i < browsing.Count; i++)
                                                    Console.WriteLine(browsing.Product[i].Name + " цена: " + browsing.Product[i].Price);
                                               Console.WriteLine("count:" + browsing.Count);
                                                Console.ReadKey();
                                                break;
                                            case 2:
                                                browsing = new Browsing("техника", products);
                                                for (int i = 0; i < browsing.Count; i++)
                                                    Console.WriteLine(browsing.Product[i].Name + " цена: " + browsing.Product[i].Price);
                                                Console.ReadKey();
                                                break;
                                            case 3:
                                                browsing = new Browsing("одежда", products);
                                                for (int i = 0; i < browsing.Count; i++)
                                                    Console.WriteLine(browsing.Product[i].Name + " цена: " + browsing.Product[i].Price);
                                                Console.ReadKey();
                                                break;
                                        }
                                        Console.Clear();
                                        break;
                                    case 2://dobavit v korzinu
                                        Console.Clear();
                                        Console.WriteLine("введите название продукта");
                                        productName = Console.ReadLine();
                                        for (int i = 0; i < products.Count; i++)
                                        {
                                            if (products[i].Name == productName)
                                            {
                                                sum += products[i].Price;
                                                basket.Product.Add(products[i]);
                                            }
                                        }
                                        
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;

                                        case 3:
                                        Console.Clear();
                                        for(int i = 0; i < basket.Product.Count; i++)
                                        {
                                            Console.Write(basket.Product[i].Name + "  ");
                                        }                                        
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                        case 4:
                                        Console.Clear();
                                        Console.WriteLine("вам нужно оплатить "+sum);
                                        Process.Start("http://paypal.com");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                    case 5: Environment.Exit(0);break;
                                }
                            }
                        }
                        //menuOperation END
                    }

                    else if (y == 2)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(0, 10);
                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.WriteLine("Введите логин: ");
                        string login = Console.ReadLine();
                        Console.WriteLine("Введите пароль: ");
                        string password = Console.ReadLine();
                        try
                        {
                            account.Add(login, password);
                        }
                        catch(ArgumentException argumentException)
                        {
                            Console.WriteLine(argumentException.Message);
                            Console.WriteLine("в системе такой логин существует попробуйте снова");
                            break;
                        }
                        Console.Write("введите номер телефона  ");
                        string bufnumberPhone = Console.ReadLine();

                        // Find your Account Sid and Token at twilio.com/console
                        const string accountSid = "ACcb97c83a29ffe6aa6109a14a350e6ea7";
                        const string authToken = "0ad183c0a412d2498ac1e2b0042930cf";

                        TwilioClient.Init(accountSid, authToken);
                        Random rnd = new Random();
                        string mesage = rnd.Next(1000, 9999).ToString();
                        Console.WriteLine("Вам пришло СМС 4х код для проверки: " + mesage);
                        var message = MessageResource.Create(
                            body: mesage,
                            from: new PhoneNumber("+18507546379"),
                            to: new PhoneNumber("+77082195258")
                        );
                        //Console.WriteLine(message.Sid);
                        Console.WriteLine("введите код подтверждения:");
                        string code = Console.ReadLine();
                        if (String.Compare(mesage, code) == 0)
                        {
                            Console.WriteLine("вы зарегались");
                            //isIn = 1;
                        }
                        else
                        {
                            Console.WriteLine("ошибка регистрации номера");                           
                        }
                        Console.Clear();
                    }
                    else if (y == 3)
                    {
                        Console.SetCursorPosition(0, 10);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                    else if (y == 4)
                    {
                        Environment.Exit(0);
                    }
                }
            }
          }
          

       

    }
}
        
