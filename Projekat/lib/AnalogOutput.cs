using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib
{
    public class AnalogOutput
    {
        private String tagName;
        private String description;
        private String IO_address;
        private int initial_value;
        private String units;

        public AnalogOutput(String name, String desc, String io,
            int init, String unit)
        {
            this.tagName = name;
            this.description = desc;
            this.IO_address = io;
            this.initial_value = init;
            this.units = unit;
        }

        public AnalogOutput() { }

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

        public int Initial_value
        {
            get
            {
                return initial_value;
            }

            set
            {
                initial_value = value;
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
