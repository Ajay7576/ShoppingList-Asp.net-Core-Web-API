using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Models
{
    public class Listitem
    {
        public int  ListId { get; set; }
        [ForeignKey("ListId")]
        public List List { get; set; }
        public int ItemId { get; set; }
        [ForeignKey("ItemId")]
        public Item Item { get; set; }

      

    }
}
