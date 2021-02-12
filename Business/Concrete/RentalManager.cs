using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentDal _rentDal;
        public RentalManager(IRentDal rentDal)
        {
            _rentDal = rentDal;
        }
        public IResult Add(Rental rental)
        {
			if (rental.RentDate==rental.RentDate)
			{
               return new SuccessResult(Messages.RentalAdded);
			}
			else
			{
                return new ErrorResult(Messages.RentalNotFound);
			}

        }

        public IResult Delete(Rental rental)
        {
            if (_rentDal.Get(r => r.Id == rental.Id) == null)
            {
                return new ErrorResult(Messages.RentalNotFound);
            }
            _rentDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentDal.GetAll());
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            var rental = _rentDal.Get(r => r.Id == rentalId);
            if (rental == null)
            {
                return new ErrorDataResult<Rental>(Messages.RentalNotFound);
            }
            return new SuccessDataResult<Rental>(rental);
        }

		public IResult Update(Rental rental)
        {
            if (_rentDal.Get(r => r.Id == rental.Id) == null)
            {
                return new ErrorResult(Messages.RentalNotFound);
            }
            _rentDal.Update(rental);
            return new ErrorResult(Messages.RentUpdated);
        }
    }
}
