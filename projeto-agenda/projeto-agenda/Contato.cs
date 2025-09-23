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

        public Contato(string email, string nome, Data dtNasc)
        {
            Email = email;
            Nome = nome;
            DtNasc = dtNasc;
        }

        public Contato(string email, string nome, Data dtNasc, Telefone telefone)
        {
            Email = email;
            Nome = nome;
            DtNasc = dtNasc;
            adicionarTelefone(telefone);
        }

        public Contato(string nome) : this("", nome, null) { }

        public int getIdade()
        {
            DateTime dataAtual = DateTime.Now;
            int idade = dataAtual.Year - dtNasc.Ano;
            if (dataAtual.Month < dtNasc.Mes || (dataAtual.Month == dtNasc.Mes && dataAtual.Day < dtNasc.Dia))
            {
                idade--;
            }
            return idade;
        }

        public void adicionarTelefone(Telefone t)
        {
            if (t != null && t.Principal)
            {
                Telefone principalAtual = telefones.Find(tel => tel.Principal);
                if (principalAtual != null)
                    principalAtual.Principal = false;
            }
            if (t != null)
                telefones.Add(t);
        }

        public string getTelefonePrincipal()
        {
            Telefone telPrincipal = telefones.Find(t => t.Principal);
            return telPrincipal != null ? telPrincipal.Numero : " Não possui telefone principal";
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine($" Nome: {Nome}");
            s.AppendLine($" Email: {Email}");
            s.AppendLine($" Data de Nascimento: {DtNasc.ToString()}");
            s.AppendLine($" Idade: {getIdade()} anos");
            s.AppendLine($" Telefone Principal: {getTelefonePrincipal()}");
            if (telefones.Count > 0)
            {
                s.AppendLine(" Outros Telefones:");
                foreach (Telefone tel in telefones.Where(t => !t.Principal))
                {
                    s.AppendLine($" - {tel.Tipo}: {tel.Numero}");
                }
            }
            return s.ToString();
        }

        public override bool Equals(object obj)
        {
            bool igual = false;
            if (obj is Contato outroContato)
                if (Nome.Equals(outroContato.Nome, StringComparison.OrdinalIgnoreCase))
                    igual = true;
            return igual;
        }
    }
}
