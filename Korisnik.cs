using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prviProjekatDrugiPut
{
    [Serializable]
    class Korisnik
    {
        private String username;
        private String password;
       
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

        public Korisnik(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
        public Korisnik()
        {          
        }


        public static Korisnik proveri(List<Korisnik> list, string u, string p)
        {
            foreach (Korisnik k in list)
            {
                if (k.username.Equals(u) && k.password.Equals(p))
                {
                    return k;
                }
            }
            return null;
        }
        public static Korisnik proveri2(List<Korisnik> list, string u)
        {
            foreach (Korisnik k in list)
            {
                if (k.username.Equals(u))
                {
                    return k;
                }
            }
            return null;
        }

       
    }
}
