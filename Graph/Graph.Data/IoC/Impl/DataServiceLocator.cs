using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.Data.DataAccess.Repository;
using Graph.Data.DataAccess.Repository.Impl;

namespace Graph.Data.IoC.Impl
{
    public class DataServiceLocator : IDataServiceLocator
    {
        private readonly IDictionary<object, object> services;

        //TODO - remake it as singleton!!
        public DataServiceLocator()
        {
            services = new Dictionary<object, object>
            {
                {typeof (IGraphRepository), new GraphXmlRepository()}   //TODO - change it to GraphDbRepository
                
            };
        }

        public T GetPrintJobService<T>()
        {
            try
            {
                return (T)services[typeof(T)];
            }
            catch (KeyNotFoundException)
            {
                throw new ApplicationException("The requested service is not registered");
            }

        }
    }
}
