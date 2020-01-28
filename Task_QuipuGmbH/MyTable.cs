using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_QuipuGmbH
{
    class MyTable
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int NamberOfTags { get; set; }
        public MyTable(int id,string url, int numberOfTags)
        {
            this.Id = id;
            this.Url = url;
            this.NamberOfTags = numberOfTags;
        }
    }
}
