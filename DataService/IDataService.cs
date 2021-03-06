﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    public interface IDataService
    {
        void GetDataFromStings(Action<IEnumerable<ObjectEstate>, Exception> callback, IEnumerable<string> data);
    }
}