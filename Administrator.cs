using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prviProjekatDrugiPut
{
    [Serializable]
    class Administrator : Korisnik
    {
        public Administrator(string username, string password) : base(username, password)
        {
        }
    }
}
