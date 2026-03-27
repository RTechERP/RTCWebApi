using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCWebApi.IRepository
{
    public interface IGenericRepo<T>where T:class
    {
        IEnumerable<T> GetAll();
        T GetByID(int id);
        int Create(T item);
        int Update(T item);
        int Delete(int id);
    }
}
