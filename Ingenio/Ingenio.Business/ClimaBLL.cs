using Ingenio.Data;
using Ingenio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingenio.Business
{
    public class ClimaBLL
    {
        private readonly ClimaDAL _climaDal;

        public ClimaBLL()
        {
            _climaDal = new ClimaDAL();
        }

        public ClimaBLL(ClimaDAL climaDal)
        {
            _climaDal = climaDal;
        }

        public async Task<IEnumerable<Clima>> GetClima()
        {
            var list = await _climaDal.GetClima();
            return list;
        }

        public async Task<int> AddClima(Clima clima)
        {
            var add = await _climaDal.AddClima(clima);
            return add;
        }

        public async Task<int> UpdateClima(int id, Clima clima)
        {
            var update = await _climaDal.UpdateClima(id, clima);
            return update;
        }

        public async Task<int> DeleteClima(int id)
        {
            var delete = await _climaDal.DeleteClima(id);
            return delete;
        }

        public async Task<Clima> GetClima(int id)
        {
            var clima = await _climaDal.GetClima(id);
            return clima;
        }

    }
}
