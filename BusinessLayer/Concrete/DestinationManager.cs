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
            throw new NotImplementedException();
        }

        public void TDelete(Destination entity)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
