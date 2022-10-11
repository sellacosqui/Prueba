using Ingenio.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingenio.Data
{
    public class ClimaDAL
    {
        private readonly IngenioConext _IngenioConext;

        public ClimaDAL()
        {
            _IngenioConext = new IngenioConext();
        }

        public ClimaDAL(IngenioConext ingenioConext)
        {
            _IngenioConext = ingenioConext;
        }

        public async Task<IEnumerable<Clima>> GetClima()
        {
            var list = await _IngenioConext.Clima.ToListAsync();
            return list;
        }

        public async Task<int> AddClima(Clima clima)
        {
            //clima.Fecha = DateTime.Now;
            var add = _IngenioConext.Clima.Add(clima);
            await _IngenioConext.SaveChangesAsync();

            return add.Id;
        }

        public async Task<int> UpdateClima(int id, Clima clima)
        {
            if (id != clima.Id)
            {
                return 0;
            }

            _IngenioConext.Entry(clima).State = EntityState.Modified;

            await _IngenioConext.SaveChangesAsync();

            return clima.Id;
        }

        public async Task<int> DeleteClima(int id)
        {
            var delete = await _IngenioConext.Clima.FindAsync(id);

            _IngenioConext.Clima.Remove(delete);
            await _IngenioConext.SaveChangesAsync();

            return id;
        }

        public async Task<Clima> GetClima(int id)
        {
            var clima = await _IngenioConext.Clima.FirstOrDefaultAsync(c=> c.Id == id);
            return clima;
        }
  
    }
}
