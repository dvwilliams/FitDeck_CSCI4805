using System;
using System.Collections.Generic;

namespace FitDeck_CSCI4805
{
    public class RestDays
    {
        public List<RestDay> restdays;

        public RestDays()
        {
            restdays = new List<RestDay>();
        }
        public void addRestDay(RestDay restDay)
        {
            restdays.Add(restDay);
        }
        public void deleteRestDay(RestDay restDay)
        {
            foreach(RestDay rd in restdays)
            {
                if(rd.Day== restDay.Day)
                {
                    restdays.Remove(rd);
                }
            }
        }
    }
}
