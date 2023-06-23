using System;
using System.Collections.Generic;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
	public class AdminUserManager: IAdminService
    {
        IAdminUserDal _adminUserDal;

        public AdminUserManager(IAdminUserDal adminUserDal)
        {
            _adminUserDal = adminUserDal;
        }

        public void TAdd(AdminUser t)
        {
            _adminUserDal.Insert(t);
        }

        public void TDelete(AdminUser t)
        {
            _adminUserDal.Delete(t);
        }

        public AdminUser TGetByID(int id)
        {
            return _adminUserDal.GetByID(id);
        }

        public List<AdminUser> TGetList()
        {
            return _adminUserDal.GetList();
        }

        public void TUpdate(AdminUser t)
        {
            _adminUserDal.Update(t);
        }
    }
}

