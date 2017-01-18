using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib
{
    public class AnalogInput
    {
        private String tagName;
        private String description;
        private String IO_address;
        private int scan_time;
        private List<Alarm> alarms;
        private String units;

        public AnalogInput() { }

        public AnalogInput(String name, String desc, String address,
            int stime, List<Alarm> Alarms, String unit)
        {
            this.tagName = name;
            this.description = desc;
            this.IO_address = address;
            this.scan_time = stime;
            this.alarms = Alarms;
            this.units = unit;
        }

        public string TagName
        {
            get
            {
                return tagName;
            }

            set
            {
                tagName = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public string IO_address1
        {
            get
            {
                return IO_address;
            }

            set
            {
                IO_address = value;
            }
        }

        public int Scan_time
        {
            get
            {
                return scan_time;
            }

            set
            {
                scan_time = value;
            }
        }

        public List<Alarm> Alarms
        {
            get
            {
                return alarms;
            }

            set
            {
                alarms = value;
            }
        }

        public string Units
        {
            get
            {
                return units;
            }

            set
            {
                units = value;
            }
        }
    }
}
