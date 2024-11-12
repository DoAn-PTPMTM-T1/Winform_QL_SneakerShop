using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace ModernGUI_V3
{
    public class ValidateHelper
    {
        public bool IsValidPhoneNumber(string phoneNumber)
        {
            
            string pattern = @"^(0[3|5|7|8|9])\d{8}$";
            return Regex.IsMatch(phoneNumber, pattern);
        }

       
        public bool IsValidCCCD(string cccd)
        {
            
            return Regex.IsMatch(cccd, @"^\d{9}$") || Regex.IsMatch(cccd, @"^\d{12}$");
        }

        
        public  bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
    }
}
