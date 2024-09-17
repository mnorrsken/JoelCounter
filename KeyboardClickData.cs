using System;
using System.Collections.Generic;

namespace JoelCounter
{
    static class KeyboardClickData
    {
        public static int TotalClicks = 0;
        public static Dictionary<DateTime, int> ClicksPerDay = new Dictionary<DateTime, int>();

        public static int GetClicksToday()
        {
            if (ClicksPerDay.ContainsKey(DateTime.Now.Date))
            {
                return ClicksPerDay[DateTime.Now.Date];
            }
            return 0;
        }
    }
}
