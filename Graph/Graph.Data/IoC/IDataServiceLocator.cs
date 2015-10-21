﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Data.IoC
{
    public interface IDataServiceLocator
    {       
        T GetPrintJobService<T>();        
    }
}
