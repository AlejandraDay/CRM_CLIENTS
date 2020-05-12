using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.BusinessLogic
{
    
        public class NameInvalid : Exception
        {
            //406 not acceptable
            public int Code { get { return 406; } }

            public NameInvalid(string message) : base(message) { }
        }

        
        public class NameAlreadyExists : Exception
        {
            //500 internal server error
            public int Code { get { return 500; } }
            public NameAlreadyExists(string message) : base(message) { }
        }
     
    }

