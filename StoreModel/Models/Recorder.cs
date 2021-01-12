using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StoreModel.Models
{
    public class Recorder
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Recorder Name")]
        [StringLength(50)]
        public string RecorderName { get; set; }
        [StringLength(70)]
        public string Adress { get; set; }
        public ICollection<RecordedAlbum> RecordedAlbums { get; set; }
    }
}
