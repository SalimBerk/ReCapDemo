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
			Console.WriteLine(" ");
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("--------------------------ARAÇLAR LİSTESİ-----------------------------");
			Console.WriteLine("\n\n");
			Console.ResetColor();
			Console.ForegroundColor = ConsoleColor.Yellow;
			foreach (var car in carManager.GetCarDetailDtos())
			{

				Console.WriteLine($"MARKA ADLARINI LİSTELE:{car.BrandName}");

			}
			Console.ResetColor();
			Console.WriteLine("\n\n");

			Console.ForegroundColor = ConsoleColor.Magenta;
			foreach (var car in carManager.GetCarDetailDtos())
			{
				Console.WriteLine($"MARKA RENKLERİNİ LİSTELE:{car.BrandName}");


			}
			Console.ResetColor();
			Console.WriteLine("\n\n");
			Console.ForegroundColor = ConsoleColor.DarkGreen;
			foreach (var car in carManager.GetCarDetailDtos())
			{
				Console.WriteLine($"MARKA FİYATLARINI LİSTELE:{car.DailyPrice}");


			}
			Console.ResetColor();

			//BrandManager brandManager = new BrandManager(new EfBrandDal());
			//ColorManager colorManager = new ColorManager(new EfColorDal());

			//Test(carManager, brandManager, colorManager);

		}

		private static void Test(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
		{
			Console.WriteLine("Brand Id'si 1 olan arabalar: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
			foreach (var car in carManager.GetAllByBrandId(1))
			{
				Console.WriteLine($"{car.CarId}\t{colorManager.GetById(car.ColorId).ColorName}\t\t{brandManager.GetById(car.BrandId).BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
			}

			Console.WriteLine("\n\nColor Id'si 2 olan arabalar: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
			foreach (var car in carManager.GetAllByColorId(2))
			{
				Console.WriteLine($"{car.CarId}\t{colorManager.GetById(car.ColorId).ColorName}\t\t{brandManager.GetById(car.BrandId).BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
			}

			Console.WriteLine("\n\nId'si 2 olan araba: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
			Car carById = carManager.GetById(2);
			Console.WriteLine($"{carById.CarId}\t{colorManager.GetById(carById.ColorId).ColorName}\t\t{brandManager.GetById(carById.BrandId).BrandName}\t\t{carById.ModelYear}\t\t{carById.DailyPrice}\t\t{carById.Description}");


			Console.WriteLine("\n\nGünlük fiyat aralığı 100 ile 165 olan arabalar: \nId\tColor Name\tBrand Name\tModel Year\tDaily Price\tDescriptions");
			foreach (var car in carManager.GetByDailyPrice(100, 165))
			{
				Console.WriteLine($"{car.CarId}\t{colorManager.GetById(car.ColorId).ColorName}\t\t{brandManager.GetById(car.BrandId).BrandName}\t\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Description}");
			}

			Console.WriteLine("\n");

			carManager.Add(new Car { BrandId = 1, ColorId = 2, DailyPrice = -300, ModelYear = "2021", Description = "Otomatik Dizel" });
			brandManager.Add(new Brand { BrandName = "a" });
		}
	}
}
