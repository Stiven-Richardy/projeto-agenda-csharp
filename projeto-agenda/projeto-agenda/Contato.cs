using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_agenda
{
    internal class Contato
    {
        private string email;
        private string nome;
        private Data dtNasc;
        private List<Telefone> telefones;

        public string Email { get => email; set => email = value; }
        public string Nome { get => nome; set => nome = value; }
        public Data DtNasc { get => dtNasc; set => dtNasc = value; }
        public List<Telefone> Telefones { get => telefones; set => telefones = value; }

        public Contato(string email, string nome, Data dtNasc, List<Telefone> telefones)
        {
            Email = email;
            Nome = nome;
            DtNasc = dtNasc;
            Telefones = telefones;
        }

        public int getIdade()
        {
            return 0;
        }

        public void adicionarTelefone(Telefone t)
        {
            
        }

        public string getTelefonePrincipal()
        {
            return "";
        }

        public override string ToString()
        {
            return "";
        }
    }
}
