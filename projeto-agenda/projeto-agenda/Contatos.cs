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

        public Contatos()
        {
            this.agenda = new List<Contato>();
        }

        public bool adicionar(Contato c)
        {
            bool contatoExiste = agenda.Any(contatoExistente => contatoExistente.Nome.Equals(c.Nome, StringComparison.OrdinalIgnoreCase) ||
                (c.getTelefonePrincipal() != "Não possui telefone principal" && contatoExistente.getTelefonePrincipal().Equals(c.getTelefonePrincipal())));
            bool adicionou = false;
            if (!contatoExiste)
            {
                agenda.Add(c);
                adicionou = true;
            }
            return adicionou;
        }

        public Contato pesquisar(Contato c)
        {
            return agenda.Find(contato => contato.Nome.Equals(c.Nome, StringComparison.OrdinalIgnoreCase));
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
