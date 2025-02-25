﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGuideDal : IGenericDal<Guide>
    {
        void ChangeToTrueByGuide(int id);//REhberi Aktif Yap
        void ChangeToFalseByGuide(int id);//REhberi Pasif Yap
    }
}
