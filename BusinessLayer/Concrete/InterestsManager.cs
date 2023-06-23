using System;
using System.Collections.Generic;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
	public class InterestsManager : IInterestsService
	{
		IInterestsDal _interestsDal;

        public InterestsManager(IInterestsDal interestsDal)
        {
            _interestsDal = interestsDal;
        }

        public void TAdd(Interests t)
        {
            _interestsDal.Insert(t);
        }

        public void TDelete(Interests t)
        {
            _interestsDal.Delete(t);
        }

        public Interests TGetByID(int id)
        {
            return _interestsDal.GetByID(id);
        }

        public List<Interests> TGetList()
        {
            return _interestsDal.GetList();
        }

        public void TUpdate(Interests t)
        {
            _interestsDal.Update(t);
        }
    }
}

