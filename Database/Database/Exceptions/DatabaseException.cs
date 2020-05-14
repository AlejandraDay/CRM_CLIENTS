using System;
using System.Collections.Generic;
using System.Text;

namespace CDM_CLIENTS.Database.Exceptions
{
    public class DatabaseException : Exception
    {
        public int Code { get { return 404; } }
        public DatabaseException(string message) : base(message){}
    }
}