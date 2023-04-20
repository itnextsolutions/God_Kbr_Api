using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godrej_Korber_Shared.Models
{
    
    public class Client
    {
        public int CLIENT_ID { get; set; }
        public string CLIENT_NAME { get; set; }
    }


    public class Page
    {
        public int PAGE_ID { get; set; }
        public string PAGE_NAME { get; set; }
    }


    public class Table
    {
        public int TABLE_ID { get; set; }
        public string TABLE_NAME { get; set; }
    }


    public class Column
    {
        public int COLUMN_ID { get; set;}
        public string COLUMN_NAME { get; set;}
        public int CLIENT_ID { get; set;}
        public int PAGE_ID { get; set; }
        public int TABLE_ID { get; set; }
    }


    public class DisplayType
    {
        public int DISPLAY_ID { get; set; }
        public string DISPLAY_TYPE_NAME { get; set;}
        public string DISPLAY_TYPE { get; set; }
    }


    public class ConfigurationMaster
    {
        //public int CONFIGURE_ID { get; set; }
        public int CLIENT_ID { get; set; }
        public int PAGE_ID { get; set; }
        public int TABLE_ID { get; set; }
        public int COLUMN_ID { get; set; }
        public int DISPLAY_TYPE_ID { get; set; }
        public string DISPLAY_TEXT { get; set; }
        public char IS_REQUIRED { get; set; }
        public char IS_READONLY { get; set; }
        public string CREATED_BY { get; set; }
        //public DateTime CREATED_DATE { get; set; }
        public string UPDATED_BY { get; set; }
        //public DateTime UPDATED_DATE { get; set; }
    
    }

}
