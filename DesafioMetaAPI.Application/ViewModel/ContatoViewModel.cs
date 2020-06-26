using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace DesafioMetaAPI.Application.ViewModel
{
    public class ContatoViewModel
    {
        [Description("Identificador único")]
        public int Id { get; set; }
        [Description("Nome que descreva o contato")]
        public string Nome { get; set; }
        [Description("Tipo de canal de contato, podendo ser email, celular ou fixo")]
        public string Canal { get; set; }
        [Description("Valor para o canal de contato")]
        public string Valor { get; set; }
        [Description("Qualquer observação que seja pertinente")]
        public string Obs { get; set; }
    }
}
