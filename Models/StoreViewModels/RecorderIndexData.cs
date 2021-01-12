using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreModel.Models;

namespace Secheli_Stefania_Proiect.Models.StoreViewModels
{
    public class RecorderIndexData
    {
        public IEnumerable<Recorder> Recorders { get; set; }
        public IEnumerable<Album> Albums { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
