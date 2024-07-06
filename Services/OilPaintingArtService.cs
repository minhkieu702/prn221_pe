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
        public void Create(OilPaintingArt OilPaintingArt) => repository.Create(OilPaintingArt);
        public void Delete(int id) => repository.Delete(id);
        public void Update(OilPaintingArt OilPaintingArt)=> repository.Update(OilPaintingArt);
        public OilPaintingArt GetOilPaintingArt(int id) => repository.GetOilPaintingArt(id);
    }
}
