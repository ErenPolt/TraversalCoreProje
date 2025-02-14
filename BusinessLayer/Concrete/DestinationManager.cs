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
    public class DestinationManager : IDestinationService
    {
        private readonly IDestinationDal _destinationDal;

        public DestinationManager(IDestinationDal destinationDal)
        {
            _destinationDal = destinationDal;
        }

        public void TAdd(Destination entity)
        {
            _destinationDal.Insert(entity);//Ekleme işlemi
        }

        public void TDelete(Destination entity)
        {
            _destinationDal.Delete(entity);//Silme işlemi
        }

        public Destination TGetById(int id)
        {
            return _destinationDal.GetById(id);//Id!ye göre çağırma işlemi
        }

        public List<Destination> TGetList()
        {
            return _destinationDal.GetList();//listeleme işlemi
        }

        public void TUpdate(Destination entity)
        {
            _destinationDal.Update(entity);//Güncelleme işlemi;
        }
    }
}
