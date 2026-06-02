using System.Reflection.Metadata;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Data.SqlTypes;
using System;
using Course.Entities;
using Course.Entities.Servicies;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ENTER RENTAL DATA:");
            Console.Write("Car Model: ");
            string carModel = Console.ReadLine()!;

            Console.Write("Pickuo (dd/MM/yyyy hh:mm): ");
            DateTime start = DateTime.ParseExact(Console.ReadLine()!, "dd/MM/yyyy HH:mm" , CultureInfo.InvariantCulture);

            Console.Write("Return (dd/MM/yyyy hh:mm): ");
            DateTime finish = DateTime.ParseExact(Console.ReadLine()!, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            Console.Write("Enter price per hour: ");
            double priceHour = double.Parse(Console.ReadLine()! , CultureInfo.InvariantCulture);

            Console.Write("Enter price per day: ");
            double priceDay = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);

            RentalService rentalService = new RentalService(priceHour, priceDay, new BrasilTaxService());

            CarRental carRental = new CarRental(start,finish,new Vehicle(carModel));
           
            rentalService.ProcessInvoice(carRental);

            Console.WriteLine("INVOICE: ");
            Console.WriteLine(carRental.Invoice);
        }
    }
}