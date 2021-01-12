using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreModel.Models
{
    public class RecordedAlbum
    {
        public int RecorderID { get; set; }
        public int AlbumID { get; set; }
        public Recorder Recorder { get; set; }
        public Album Album { get; set; }
    }
}
