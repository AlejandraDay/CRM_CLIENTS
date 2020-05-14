using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Exceptions
{
    
        public class CodeDoesNotExistException : Exception
        {
            //400 not acceptable
            public int Code { get { return 400; } }

            public CodeDoesNotExistException(string message) : base(message) { }
        }

        
        public class CodeAlreadyExistsException : Exception
        {
            //400 internal server error
            public int Code { get { return 406; } }
            public CodeAlreadyExistsException(string message) : base(message) { }
        }

        public class EmptyNameException : Exception
        {
            //400 internal server error
            public int Code { get { return 401; } }
            public EmptyNameException(string message) : base(message) { }
        }

        public class EmptyCiException : Exception
        {
            //400 internal server error
            public int Code { get { return 401; } }
            public EmptyCiException(string message) : base(message) { }
        }

        public class RankingOutOfBoundException : Exception
        {
            //400 internal server error
            public int Code { get { return 401; } }
            public RankingOutOfBoundException(string message) : base(message) { }
        }
     
    }

