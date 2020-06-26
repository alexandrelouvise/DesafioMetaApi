using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMetaAPI.Domain.Entities
{
    public class Contato : Base
    {
        public string Nome { get; set; }
        public string Canal { get; set; }
        public string Valor { get; set; }
        public string Obs { get; set; }
    }
}
