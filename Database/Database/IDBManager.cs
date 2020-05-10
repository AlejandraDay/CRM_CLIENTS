using System;
using System.Collections.Generic;
using System.Text;

namespace CDM_CLIENTS.Database
{
    public interface IDBManager
    {
        void InitDBContext();
        void SaveChanges();
    }
}