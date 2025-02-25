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
    public class GuideManager : IGuideService
    {
        private readonly IGuideDal _guideDal;

        public GuideManager(IGuideDal guideDal)
        {
            _guideDal = guideDal;
        }

        public void TAdd(Guide entity)//Ekleme işlemi
        {
           _guideDal.Insert(entity);
        }

        public void TChangeToFalseByGuide(int id)//Pasif Yap
        {
            _guideDal.ChangeToFalseByGuide(id);
        }

        public void TChangeToTrueByGuide(int id)//Aktif Yap
        {
            _guideDal.ChangeToTrueByGuide(id);
        }

        public void TDelete(Guide entity)
        {
            _guideDal.Delete(entity);
        }

        public Guide TGetById(int id)//Id'ye göre işlem
        {
           return _guideDal.GetById(id);
        }

        public List<Guide> TGetList()//Listeleme işlemi;
        {
            return _guideDal.GetList();
        }

        public void TUpdate(Guide entity)//Güncelleme işlemi
        {
            _guideDal.Update(entity);
        }
    }
}
