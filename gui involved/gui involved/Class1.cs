using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui_involved
{
    public class involved
    {
        public string id;
        public string location ;
        public string image;
        public string age;
      
        public involved()
        {
        }
        public involved(string ID, string des, string Cstatus, string Cimage)
        {
            id = ID;
            location = des;
            image = Cstatus;
            age = Cimage;
        }

    }
}