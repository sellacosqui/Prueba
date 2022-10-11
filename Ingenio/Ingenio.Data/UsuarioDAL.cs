using Ingenio.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingenio.Data
{
    public class UsuarioDAL
    {
        private readonly IngenioConext _ingenioConext;

        public UsuarioDAL()
        {
            _ingenioConext = new IngenioConext();
        }

        public UsuarioDAL(IngenioConext ingenioConext)
        {
            _ingenioConext = ingenioConext;
        }

        public async Task<bool> Loguear(Usuarios usuario)
        {
            var user = await (from u in _ingenioConext.Usuario
                       where u.Email == usuario.Email &&
                             u.Contraseña == usuario.Contraseña
                       select u).ToListAsync();

            if (user.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
