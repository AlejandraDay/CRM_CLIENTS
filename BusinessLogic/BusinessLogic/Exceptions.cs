using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.BusinessLogic
{
    
        public class CodeDoesNotExist : Exception
        {
            //400 not acceptable
            public int Code { get { return 400; } }

            public CodeDoesNotExist(string message) : base(message) { }
        }

        
        public class CodeAlreadyExists : Exception
        {
            //400 internal server error
            public int Code { get { return 406; } }
            public CodeAlreadyExists(string message) : base(message) { }
        }
     
    }

