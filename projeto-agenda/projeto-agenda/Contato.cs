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
        private List<Telefone> telefones = new List<Telefone>();

        public string Email { get => email; set => email = value; }
        public string Nome { get => nome; set => nome = value; }
        public Data DtNasc { get => dtNasc; set => dtNasc = value; }
        public List<Telefone> Telefones { get => telefones; set => telefones = value; }

        public Contato(string email, string nome, Data dtNasc, Telefone telefone)
        {
            Email = email;
            Nome = nome;
            DtNasc = dtNasc;
            adicionarTelefone(telefone);
        }

        public int getIdade()
        {
            return 0;
        }

        public void adicionarTelefone(Telefone t)
        {
            if (t.Principal)
            {
                Telefone principalAtual = telefones.Find(tel => tel.Principal);
                if (principalAtual != null)
                {
                    principalAtual.Principal = false;
                }
            }
            telefones.Add(t);
        }

        public string getTelefonePrincipal()
        {
            Telefone telPrincipal = telefones.Find(t => t.Principal);
            return telPrincipal != null ? telPrincipal.Numero : " Não possui telefone principal";
        }

        public override string ToString()
        {
            return "";
        }
    }
}
