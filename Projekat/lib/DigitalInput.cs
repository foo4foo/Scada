using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib
{
    public class DigitalInput
    {
        private String tag_name;
        private String description;
        private String IO_address;
        private int scan_time;

        public DigitalInput(String name, String desc, String io, int time)
        {
            this.tag_name = name;
            this.description = desc;
            this.IO_address = io;
            this.scan_time = time;
        }


        public DigitalInput() { }

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
    }
}
