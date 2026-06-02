using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Course.Entities;
namespace Course.Entities.Servicies
{
   class RentalService
    {
        public double PricePerHour { get; private set; }
        public double PricePerDay { get; private set; }

        public BrasilTaxService _brasilTaxService;

        public RentalService(double pricePerHour, double pricePerDay, BrasilTaxService brasilTaxService)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
            _brasilTaxService = brasilTaxService;
        }

        public void ProcessInvoice(CarRental carRental)
        {
            TimeSpan duration = carRental.Finish.Subtract(carRental.Start);

            double basicPayment = 0.0;
            if(duration.TotalHours <= 12.0)
            {
                basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours);
            }
            else
            {
                basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);
            }

            double tax = _brasilTaxService.Tax(basicPayment);

            carRental.Invoice = new Invoice (basicPayment, tax);
        }
    }
}
