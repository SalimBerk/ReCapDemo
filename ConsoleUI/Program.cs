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
			CarManager carManager = new CarManager(new EfCarDal());
			BrandManager brandManager = new BrandManager(new EfBrandDal());
			ColorManager colorManager = new ColorManager(new EfColorDal());
			Console.WriteLine("Renk Listesi");
			foreach (var color in colorManager.GetAll().Data)
			{
				Console.WriteLine(color.ColorId + " - " + color.ColorName);
			}
			
			Console.WriteLine("Marka Listesi");
			foreach (var brand in brandManager.GetAll().Data)
			{
				Console.WriteLine(brand.BrandId + " - " + brand.BrandName);

			}


			Console.WriteLine("----------");
			Console.WriteLine("Araç Listesi");
			foreach (var car in carManager.GetAll().Data)
			{
				Console.WriteLine(car.CarId + " - " + car.Description + " - " + car.ModelYear);

			}

		}
	}
}
