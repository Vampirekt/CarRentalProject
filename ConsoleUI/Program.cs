using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CarManager carManager = new CarManager(new EfCarDal());

                
                foreach (var item in carManager.GetCarDetails().Data)
                {
                    Console.WriteLine(item.BrandName + "/" + item.ColorName);
                }

                Car car1 = new Car()
                {
                    BrandId = 1,
                    ColorId = 1,
                    DailyPrice = 11,
                    Description = "S",
                    ModelYear = 2002
                };
                carManager.Add(car1);

                Console.WriteLine("asdasd"); // sollte jetzt sichtbar sein
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler: " + ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            Console.ReadLine();
        }
    }
}


