using Exec12.Entities;
using Exec12.Entities.Enums;
using System;
using System.Globalization;

namespace Exec12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter cliente data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthdate = DateTime.Parse(Console.ReadLine());
            Console.Write("Status: ");
            
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            Client client = new Client(name, email, birthdate);
            Order order = new Order(DateTime.Now, status, client);

            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("Enter #" + i + " item data:");
                Console.Write("Product name: ");
                string pname = Console.ReadLine();
                Console.Write("Product price: ");
                double pprice = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

                Product product = new Product(pname, pprice);

                Console.Write("Quantity: ");
                int pquantity = int.Parse(Console.ReadLine());

                OrderItem orderitem = new OrderItem(pquantity, pprice, product);

                order.AddItem(orderitem);
            }

            Console.WriteLine();
            Console.WriteLine(order);
        }
    }
}
