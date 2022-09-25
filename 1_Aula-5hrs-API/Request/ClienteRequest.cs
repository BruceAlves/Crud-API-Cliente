using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_Aula_5hrs_API.Request
{
    public class ClienteRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
