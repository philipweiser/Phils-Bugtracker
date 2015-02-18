using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTracker_The_Reckoning.Scripts
{
    public static class ExtensionMethod
    {
        public static string Truncate(this string value, int maxLength)
        {
            if (!string.IsNullOrEmpty(value) && value.Length > maxLength)
            {
                return value.Substring(0, maxLength);
            }

            return value;
        }
    }
}