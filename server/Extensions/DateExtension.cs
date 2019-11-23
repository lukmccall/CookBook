using System;

namespace CookBook.Extensions
{
    public static class DateExtension
    {
        public static TimeSpan GetTimeSpan(this DateTime dateTime)
        {
            return dateTime - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        }
    }
}