using System.ComponentModel.DataAnnotations;
using System;

namespace Project_TTCM.Models
{
    public class CategoryModel
    {
        public string Name { get; set; }
        
        public string Notes { get; set; }
        
        public string ICON { get; set; }
        
        public string SLUG { get; set; }
       
        public string META_TITLE { get; set; }
        
        public string META_DESCRIPTION { get; set; }

        public string META_KEYWORD { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public int CREATED_BY { get; set; }
        public byte ISDELETE { get; set; } = 0;
        public byte ISACTIVE { get; set; } = 1;
    }
}
