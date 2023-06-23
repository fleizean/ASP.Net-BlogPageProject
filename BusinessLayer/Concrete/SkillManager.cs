using System;
using System.Collections.Generic;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
	public class SkillManager : ISkillService
	{
		ISkillDal _skillDal;

        public SkillManager(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }

        public void TAdd(Skills t)
        {
            _skillDal.Insert(t);
        }

        public void TDelete(Skills t)
        {
            _skillDal.Delete(t);
        }

        public Skills TGetByID(int id)
        {
            return _skillDal.GetByID(id);
        }

        public List<Skills> TGetList()
        {
            return _skillDal.GetList();
        }

        public void TUpdate(Skills t)
        {
            _skillDal.Update(t);
        }
    }
}

