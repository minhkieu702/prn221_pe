using Repository.Models;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OilPaintingArtService
    {
        OilPaintingArtRepository repository = new();
        public List<OilPaintingArt> GetBySearching(string opaStyle, string artist) => repository.GetBySearching(opaStyle, artist);
        public List<OilPaintingArt> GetAll() => repository.GetAll();
        public int Create(OilPaintingArt OilPaintingArt) => repository.Create(OilPaintingArt);
        public int Delete(int id) => repository.Delete(id);
        public int Update(OilPaintingArt OilPaintingArt)=> repository.Update(OilPaintingArt);
        public OilPaintingArt GetOilPaintingArt(int id) => repository.GetOilPaintingArt(id);
    }
}
