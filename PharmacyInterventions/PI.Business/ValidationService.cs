using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI.Business
{
    public class ValidationService
    {
public bool ValidateNhi(string nhi)
{
    bool valid = false;
    const string validNhiChars = "ABCDEFGHJKLMNPQRSTUVWXYZ";
                
    nhi = nhi.ToUpper();
    // must be seven chars long
    if (nhi.Length == 7)
    {
        // must not contain I or O
        if (!nhi.Contains("I") && !nhi.Contains("O"))
        {
            // last four must be integer
            int parsed;
            if (int.TryParse(nhi.Substring(3), out parsed))
            {
                // multiple each character by 8 minus its index and sum
                // e.g. first char * 7 + second char * 6 + third char * 5 etc
                int result = 0;
                int counter = 7;
                foreach (var character in nhi.Substring(0, 6)) // exclude last character
                {
                    int parsedCharacter = counter > 4 ? validNhiChars.IndexOf(character) + 1 : (int)Char.GetNumericValue(character);
                    result = result + (counter * parsedCharacter);
                    counter--;
                }
                // create a checksum by mod 11
                int checksum = result % 11;
                int checkDidgit = 11 - checksum;
                if (checkDidgit == 10)
                    checkDidgit = 0;

                // last value in nhi number must equal check digit
                valid = (int)Char.GetNumericValue(nhi.Last()) == checkDidgit;
            }
        }
    }

    return valid;
}
    }
}
