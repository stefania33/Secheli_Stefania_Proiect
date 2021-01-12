using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace StoreModel.Models
{
    public class Album
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        public ICollection<Order> Orders { get; set; }

        public ICollection<RecordedAlbum> RecordedAlbums { get; set; }
    }
}
