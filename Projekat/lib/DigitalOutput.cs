using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib
{
    public class DigitalOutput
    {
        private String tag_name;
        private String description;
        private String IO_address;
        private int initial_value;

        public DigitalOutput(String name, String desc, String io,
            int init)
        {
            this.tag_name = name;
            this.description = desc;
            this.IO_address = io;
            this.initial_value = init;
        }

        public DigitalOutput() { }
        public string Tag_name
        {
            get
            {
                return tag_name;
            }

            set
            {
                tag_name = value;
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


    }
}
