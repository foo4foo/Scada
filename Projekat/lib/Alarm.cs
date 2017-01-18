using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib
{
    public class Alarm
    {
        private String id;
        private String tag;
        private String message;
        private String time;
        private bool above; //below if false, above if true
        private int limit_value;

        public Alarm(String idd, String tagg, String mess,
            String timm, bool ab, int limit)
        {
            this.id = idd;
            this.tag = tagg;
            this.message = mess;
            this.time = timm;
            this.above = ab;
            this.limit_value = limit;
        }

        public Alarm()
        {
            this.time = DateTime.Now.ToString("yyyy - MM - dd hh: mm:ss");
        }

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Tag
        {
            get
            {
                return tag;
            }

            set
            {
                tag = value;
            }
        }

        public string Message
        {
            get
            {
                return message;
            }

            set
            {
                message = value;
            }
        }

        public int Limit_value
        {
            get
            {
                return limit_value;
            }

            set
            {
                limit_value = value;
            }
        }

        public bool Above
        {
            get
            {
                return above;
            }

            set
            {
                above = value;
            }
        }

        public void setTime(String date)
        {
            this.time = date;
        }

        public String getTime()
        {
            return time;
        }
    }
}
