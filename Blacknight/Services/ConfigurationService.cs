using System;
using System.Collections.Generic;
using System.IO;

namespace Blacknight.Services
{
    class ConfigurationService
    {
        public static string GetClientToken()
        {
            return File.ReadAllText(@"C:\Users\aditc\Desktop\Programms\Blacknight\Blacknight\token.txt");;
        }
    }
}
