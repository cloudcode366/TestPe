using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IArtRepo
    {
        Task<IEnumerable<OilPaintingArt>> GetArt();
        Task<OilPaintingArt> GetArtByIdAsync(int id);
        Task UpdateArt(OilPaintingArt art);
        Task DeleteArt(int id);
        Task CreatArt(OilPaintingArt oilPaintingArt);
    }
}
