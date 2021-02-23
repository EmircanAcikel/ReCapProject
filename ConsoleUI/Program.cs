using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            EfCarDal efCarDal = new EfCarDal();
            //CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in efCarDal.GetCarDetails())
            {
                Console.WriteLine(car.CarId + "/" + car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);


            }
          


        }
    }
}
