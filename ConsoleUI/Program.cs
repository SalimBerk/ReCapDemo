﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{
			//Managertest();
			//Customertest();
			//Usertest();
			//Rental();
			//CarAddTest();

		}

		private static void CarAddTest()
		{
			CarManager carManager = new CarManager(new EfCarDal());
			var result = carManager.Add(new Car { BrandId = 5, Description = "Manuel", DailyPrice = 230, ColorId = 6, ModelYear = "2002" });
			foreach (var car in result.Message)
			{
				Console.WriteLine(car);

			}
		}

		private static void Rental()
		{
			RentalManager rentalManager = new RentalManager(new EfRentDal());
			var result = rentalManager.Add(new Rental { CarId = 5, RentDate = DateTime.Now, ReturnDate = DateTime.UtcNow, CustomerId = 5 });
			foreach (var rentl in result.Message)
			{
				Console.WriteLine(rentl);
			}
		}

		private static void Usertest()
		{
			UserManager userManager = new UserManager(new EfUserDal());
			var result = userManager.GetAll();
			if (result.Success)
			{
				foreach (var user in result.Data)
				{
					Console.WriteLine("UserId:" + " " + user.Id);
					Console.WriteLine("FirstName:" + " " + user.FirstName);
					Console.WriteLine("LastName:" + " " + user.LastName);
					Console.WriteLine("Password:" + " " + user.Password);
					Console.WriteLine("Email:" + " " + user.Email);
					Console.WriteLine("-------------------------------------");

				}
			}
			else
			{
				Console.WriteLine(result.Message);
			}
		}

		private static void Customertest()
		{
			CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

			var result = customerManager.GetAll();

			if (result.Success)
			{
				foreach (var customer in result.Data)
				{
					Console.WriteLine("CustomerId : " + customer.UserId);
					Console.WriteLine("CompanyName : " + customer.CompanyName);
				}
			}
			else
			{
				Console.WriteLine(result.Message);
			}
		}

		private static void Managertest()
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
