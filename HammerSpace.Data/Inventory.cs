using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerSpace.Data
{
    public class Inventory
    {
        public int InventoryId { get; set; }

        [Required]
        public int OwnerId { get; set; }

        //[Required]
        [ForeignKey]
        //public 
    }
}
