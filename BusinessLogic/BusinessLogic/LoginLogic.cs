using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.BusinessLogic
{
    public class LoginLogic : ILoginLogic 
    {
        public bool ValidateUser(string user)
        {
            // var = "mateo.lopez<3:Pass123"
            
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
           
            string[] words = user.Split(delimiterChars);
            
            foreach (var word in words)
            {
                System.Console.WriteLine($"<{word}>");
                /* check if Username is correct in loginDB
                if(loginDB.Contains(word))
                {
                    return true;
                else{
                        return false;
                    }
                }
                */
            }
            

            return false;
        }
    }
}
