using DataAccessObject;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.iml
{
    public class ArtRepo : IArtRepo
    {   
        private readonly IDAO<OilPaintingArt> _dao;
        public ArtRepo(IDAO<OilPaintingArt> dao)
        {
            _dao = dao;
        }

        public async Task CreatArt(OilPaintingArt oilPaintingArt)
        {
            await _dao.Add(oilPaintingArt);
        }

        public async Task DeleteArt(int id)
        {
            var art =( await _dao.GetAll()).FirstOrDefault(p=>p.OilPaintingArtId == id);
            await _dao.Remove(art);

        }

        public async Task<IEnumerable<OilPaintingArt>> GetArt()
        {
           return await _dao.GetAll();
        }

        public async Task<OilPaintingArt?> GetArtByIdAsync(int id)
        {
            return (await _dao.GetAll()).FirstOrDefault(p => p.OilPaintingArtId == id);
        }

        public async Task UpdateArt(OilPaintingArt art)
        {
            await _dao.Update(art);
        }
    }
}
