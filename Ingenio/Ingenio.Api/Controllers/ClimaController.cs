using Ingenio.Business;
using Ingenio.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Ingenio.Api.Controllers
{
    public class ClimaController : ApiController
    {
        private readonly ClimaBLL _climaBLL;

        public ClimaController(ClimaBLL climaBLL)
        {
            _climaBLL = climaBLL;
        }

        public ClimaController()
        {
            _climaBLL = new ClimaBLL();
        }

        [HttpGet]
        public async Task<IEnumerable<Clima>> GetClima()
        {
            var list = await _climaBLL.GetClima();
            return list;
        }

        [HttpPost]
        public async Task<int> AddClima(Clima clima)
        {
            var add = await _climaBLL.AddClima(clima);
            return add;
        }

        [HttpPut]
        public async Task<int> UpdateClima(int id, [FromBody] Clima clima)
        {
            var update = await _climaBLL.UpdateClima(id, clima);
            return update;
        }

        [HttpDelete]
        public async Task<int> DeleteClima(int id)
        {
            var delete = await _climaBLL.DeleteClima(id);
            return delete;
        }

        public async Task<Clima> GetClima(int id)
        {
            var clima = await _climaBLL.GetClima(id);
            return clima;
        }

    }
}
