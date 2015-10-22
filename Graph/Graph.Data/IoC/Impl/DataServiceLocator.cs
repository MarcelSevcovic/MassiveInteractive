using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph.Data.Business.Entity;
using Graph.Data.Business.Factory;
using Graph.Data.Business.Factory.Impl;
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
                {typeof (IGraphRepository), new GraphXmlRepository()},   //TODO - change it to GraphDbRepository
                {typeof (IGraphFactory), new GraphFactory(new GraphXmlRepository())}
             
                
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
