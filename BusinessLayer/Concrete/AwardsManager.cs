using System;
using System.Collections.Generic;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
	public class AwardsManager : IAwardsService
	{
		IAwardsDal _awardsDal;

		public AwardsManager(IAwardsDal awardsDal)
		{
			_awardsDal = awardsDal;
		}

		public void TAdd(Awards t)
		{
			_awardsDal.Insert(t);
		}

		public void TDelete(Awards t)
		{
			_awardsDal.Delete(t);
		}

		public Awards TGetByID(int id)
		{
			return _awardsDal.GetByID(id);
        }

		public List<Awards> TGetList()
		{
			return _awardsDal.GetList();
        }

		public void TUpdate(Awards t)
		{
			_awardsDal.Update(t);
        }
	}
}

