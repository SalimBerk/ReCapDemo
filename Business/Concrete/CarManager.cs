using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class CarManager : ICarService
	{
		ICarDal _carDal;

		public CarManager(ICarDal carDal)
		{
			_carDal = carDal;
		}

		public IResult Add(Car car)
		{
			_carDal.Add(car);
			return new SuccessResult(Messages.CarAdded);
			
		}

		public IResult Delete(Car car)
		{
			_carDal.Delete(car);
			return new SuccessResult(Messages.CarDeleted);
		}

		public IDataResult<List<Car>> GetAll()
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
		}

		public IDataResult<List<Car>> GetAllByBrandId(int id)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id));
		}

		public IDataResult<List<Car>> GetAllByColorId(int id)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
		}

		public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max));
		}

		public IDataResult<Car> GetById(int id)
		{
			return new SuccessDataResult<Car>(_carDal.Get(p => p.CarId == id));
		}

		public IDataResult<List<Car>> GetByModelYear(string year)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ModelYear == year));
		}

		public IDataResult<List<CarDetailDto>> GetCarDetails()
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailDto());
		}

		public IResult Update(Car car)
		{
			if (car.DailyPrice > 0)
			{
				_carDal.Update(car);
				return new SuccessResult(Messages.CarUpdated);

			}
			else
			{
				return new SuccessResult(Messages.PriceInvalid);
			}
			
		}
	}
}
