using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLGakuen
{
    public interface IServiceGateway<T>
    {
        T Create(T t);

        T Read(int id);

        List<T> Read();

        T Update(T t);

        bool Delete(int id);

    }
}
