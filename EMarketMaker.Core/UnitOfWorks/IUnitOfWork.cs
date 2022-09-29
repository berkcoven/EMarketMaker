using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketMaker.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        //reposta yapılan değişikliklerde bir farklılık olmasın diye yapılan adım
        Task CommitAsync();
        void Commit();
    }
}
