using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_agenda
{
    internal class Contatos
    {
        private List<Contato> agenda;

        public List<Contato> Agenda { get => agenda; }

        public Contatos(List<Contato> agenda)
        {
            this.agenda = agenda;
        }

        public bool adicionar(Contato c)
        {
            return false;
        }

        public Contato pesquisar(Contato c)
        {
            return null;
        }

        public bool alterar(Contato c)
        {
            return true;
        }

        public bool remover(Contato c)
        {
            return false;
        }
    }
}
