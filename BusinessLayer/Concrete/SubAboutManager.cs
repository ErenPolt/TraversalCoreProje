﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SubAboutManager : ISubAboutService
    {
        private readonly ISubAboutDal _subAboutDal;

        public SubAboutManager(ISubAboutDal subAboutDal)
        {
            _subAboutDal = subAboutDal;
        }

        public void TAdd(SubAbout entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(SubAbout entity)
        {
            throw new NotImplementedException();
        }

        public SubAbout TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<SubAbout> TGetList()//listeleme işlemi
        {
            return _subAboutDal.GetList();
        }

        public void TUpdate(SubAbout entity)
        {
            throw new NotImplementedException();
        }
    }
}
