using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreModel.Models;
using StoreModel.Data;

namespace Secheli_Stefania_Proiect.Data
{
    public class DbInitializer
    {
        public static void Initialize(StoreContext context)
        {
            context.Database.EnsureCreated();
            if (context.Albums.Any())
            {
                return; // BD a fost creata anterior
            }
            var albums = new Album[]
            {
    new Album{Name="Believe ",Artist="Andrea Bocelli",Price=Decimal.Parse("249.90")},
    new Album{Name="Love Songs‎",Artist="Whitesnake ‎",Price=Decimal.Parse("199.90")},
    new Album{Name="East Of The Sun West Of The Moon",Artist="a-ha",Price=Decimal.Parse("129.90")},
    new Album{Name=" Highway 61 Revisited",Artist="Bob Dylan",Price=Decimal.Parse("399.90")},
    new Album { Name = "Merry Christmas Baby", Artist = "Elvis Presley ‎", Price = Decimal.Parse("69.90") },
    new Album { Name = "Get Your Wings", Artist = "Aerosmith ", Price = Decimal.Parse("199.90") },
            };
            foreach (Album s in albums)
            {
                context.Albums.Add(s);
            }
            context.SaveChanges();
            var customers = new Customer[]
            {
    new Customer{CustomerID=1050,Name="Popescu Nicola",BirthDate=DateTime.Parse("1979-09-01")},
    new Customer{CustomerID=1045,Name="Mihailescu Alexandru",BirthDate=DateTime.Parse("1969-07-08")},
            };
            foreach (Customer c in customers)
            {
                context.Customers.Add(c);
            }
            context.SaveChanges();
            var orders = new Order[]
            {
            new Order{AlbumID=1,CustomerID=1050,OrderDate=DateTime.Parse("02-25-2020")},
            new Order{AlbumID=3,CustomerID=1045,OrderDate=DateTime.Parse("09-28-2020")},
            new Order{AlbumID=1,CustomerID=1045,OrderDate=DateTime.Parse("10-28-2020")},
            new Order{AlbumID=2,CustomerID=1050,OrderDate=DateTime.Parse("09-28-2020")},
            new Order{AlbumID=4,CustomerID=1050,OrderDate=DateTime.Parse("09-28-2020")},
            new Order{AlbumID=6,CustomerID=1050,OrderDate=DateTime.Parse("10-28-2020")},
            };
            foreach (Order e in orders)
            {
                context.Orders.Add(e);
            }
            context.SaveChanges();
              var recorders = new Recorder[]
            {
            new Recorder{RecorderName="All About Music",Adress="Str. Mistletoe, nr. 40, SUA"},
            new Recorder{RecorderName="Rock Records",Adress="Str. WaterFall, nr. 35, UK"},
            new Recorder{RecorderName="Music's Wings",Adress="Str. Green Trees, nr. 22, Canada"},
            };
            foreach (Recorder r in recorders)
            {
                context.Recorders.Add(r);
            }
            context.SaveChanges();
            var recordedAlbums = new RecordedAlbum[]
            {
            new RecordedAlbum {
            AlbumID = albums.Single(c => c.Name == "Believe" ).ID,
            RecorderID = recorders.Single(i => i.RecorderName == "All About Music").ID
            },
            new RecordedAlbum {
            AlbumID = albums.Single(c => c.Name == "Love Songs" ).ID,
            RecorderID = recorders.Single(i => i.RecorderName == "All About Music").ID
            },
            new RecordedAlbum {
            AlbumID = albums.Single(c => c.Name == "East Of The Sun West Of The Moon" ).ID,
            RecorderID = recorders.Single(i => i.RecorderName == "Rock Records").ID
            },
            new RecordedAlbum {
            AlbumID = albums.Single(c => c.Name == "Highway 61 Revisited" ).ID,
            RecorderID = recorders.Single(i => i.RecorderName == "Music's Wings").ID
            },
            new RecordedAlbum {
            AlbumID = albums.Single(c => c.Name == "Merry Christmas Baby" ).ID,
            RecorderID = recorders.Single(i => i.RecorderName == "Music's Wings").ID
            },
            new RecordedAlbum{
            AlbumID = albums.Single(c => c.Name == "Get Your Wings" ).ID,
            RecorderID = recorders.Single(i => i.RecorderName == "Music's Wings").ID
            },
            };
            foreach (RecordedAlbum ra in recordedAlbums)
            {
                context.RecordedAlbums.Add(ra);
            }
            context.SaveChanges();
        }
    }
}
