﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_VaccineVer6.Model
{
   public class DataProvider
    {
        //tao singleton tao db 1 lan trong project 
        private static DataProvider _ins;

        public static DataProvider Ins { get { if (_ins == null) _ins = new DataProvider(); return _ins; } set { _ins = value; } }
        public QL_VaccineEntities DB { get; set; }
        private DataProvider()
        {
            DB = new QL_VaccineEntities();
        }



  
    }
}
