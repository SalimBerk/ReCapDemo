using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class UserManager : IUserService
	{
		IUserDal _userDal;

		public UserManager(IUserDal userDal)
		{
			_userDal = userDal;
		}

		public IResult Add(User user)
		{
			_userDal.Add(user);
			return new SuccessResult(Messages.UserAdded);
		}

		public IResult Delete(User user)
		{
			_userDal.Delete(user);
			return new SuccessResult(Messages.UserDeleted);
		}

		public IDataResult<List<User>> GetAll()
		{
			return new SuccessDataResult<List<User>>(_userDal.GetAll());
		}

		public IDataResult<User> GetbyId(int userId)
		{
			if (_userDal.Get(p => p.Id == userId) == null)
			{
				return new ErrorDataResult<User>(Messages.UserNotFound);
			}
		
			return new SuccessDataResult<User>(_userDal.Get(p => p.Id== userId));

			
			
		}

		public IResult Update(User user)
		{
			if (_userDal.Get(p => p.Id == user.Id) == null)
			{
				return new ErrorResult(Messages.UserNotFound);
			}
			_userDal.Update(user);
			return new SuccessResult(Messages.UserUpdated);
			
		}
	}
}
