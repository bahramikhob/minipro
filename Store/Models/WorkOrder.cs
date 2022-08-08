using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
   public class WorkOrder
    {
        public int Id { get; set; }
        public string Description { get; set; }

        //Muted Fail =>  new List<Attachment>()
        public List<Attachment> Attachmentes { get; set; } = new List<Attachment>();
    }

    public class Attachment
    {
        public int Id { get; set; }
        public string FileName { get; set; }
    }
}   
