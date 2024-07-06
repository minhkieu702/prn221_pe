using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class OilPaintingArtRepository
    {
        OilPaintingArt2024DbContext _context;
        public List<OilPaintingArt> GetAll()
        {
            _context = new();
            var oPAs = _context.OilPaintingArts.ToList();
            oPAs.ForEach(oPA =>
            {
                oPA.Supplier = _context.SupplierCompanies.FirstOrDefault(c => c.SupplierId == oPA.SupplierId);
            });
            oPAs = oPAs.OrderByDescending(oPA => oPA.CreatedDate).ToList();
            return oPAs;
        }
        public List<OilPaintingArt> GetBySearching(string opaStyle, string artist)
        {
            opaStyle = opaStyle.IsNullOrEmpty() ? string.Empty : opaStyle;
            artist = artist.IsNullOrEmpty() ? string.Empty : artist;
            _context = new();
            return GetAll().Where(o => o.Artist.ToUpper().Contains(artist.ToUpper().Trim()) && o.OilPaintingArtStyle.ToUpper().Contains(opaStyle.ToUpper().Trim())).ToList();
        }
        public OilPaintingArt GetOilPaintingArt(int id)
        {
            _context = new();
            return _context.OilPaintingArts.FirstOrDefault(p => p.OilPaintingArtId == id);
        }
        public int Create(OilPaintingArt opa)
        {
            try
            {
                var b = GetOilPaintingArt(opa.OilPaintingArtId);
                if (b == null)
                {
                    _context = new();
                    _context.Add(opa);
                    return _context.SaveChanges();
                }
                else
                {
                    throw new Exception("This OilPaintingArt is already exist.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int Delete(int id)
        {
            try
            {
                var b = GetOilPaintingArt(id);
                if (b != null)
                {
                    _context = new();
                    _context.OilPaintingArts.Remove(b);
                    return _context.SaveChanges();
                }
                else
                {
                    throw new Exception("This OilPaintingArt does not already exist.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int Update(OilPaintingArt OilPaintingArt)
        {
            try
            {
                var b = GetOilPaintingArt(OilPaintingArt.OilPaintingArtId);
                if (b != null)
                {
                    _context = new();
                    _context.OilPaintingArts.Update(OilPaintingArt);
                    return _context.SaveChanges();
                }
                else
                {
                    throw new Exception("This OilPaintingArt does not already exist.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
