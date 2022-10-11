using Ingenio.Data;
using Ingenio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingenio.Business
{
    public class UsuarioBLL
    {
        private readonly UsuarioDAL _usuarioDAL;

        public UsuarioBLL()
        {
            _usuarioDAL = new UsuarioDAL();
        }

        public UsuarioBLL(UsuarioDAL usuarioDAL)
        {
            _usuarioDAL = usuarioDAL;
        }

        public async Task<bool> Loguear(Usuarios usuario)
        {
            var user = await _usuarioDAL.Loguear(usuario);

            return user;
        }

    }
}
