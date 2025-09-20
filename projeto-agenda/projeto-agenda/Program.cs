/*
| Instituto Federal de São Paulo - Campus Cubatão
| Nome: Guilherme Mendes de Sousa - CB3030857
| Nome: Stiven Richardy Silva Rodrigues - CB3030202
| Turma: ADS 471
| 
| Opções no seletor:
| 0. Sair
| 1. Adicionar contato
| 2. Pesquisar contato
| 3. Alterar contato
| 4. Remover contato
| 5. Listar contatos
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_agenda
{
    internal class Program
    {
        public static Contatos agenda = new Contatos();
        public static string regexEmail = @"^[\w\.-]+@([\w-]+\.)+[\w-]{2,4}$";
        public static string regexTelefone = @"^\(?(?:[14689][1-9]|2[12478]|3[1-8]|5[1345]|7[19]|8[1-8])\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$";

        static void Main(string[] args)
        {
            int seletor = -1;
            while (seletor != 0)
            {
                Console.Clear();
                Utils.Titulo("PAINEL PRINCIPAL");
                Console.WriteLine(" 0 - Sair");
                Console.WriteLine(" 1 - Adicionar contato");
                Console.WriteLine(" 2 - Pesquisar contato");
                Console.WriteLine(" 3 - Alterar contato");
                Console.WriteLine(" 4 - Remover contato");
                Console.WriteLine(" 5 - Listar contatos");
                Console.WriteLine(new string('-', 44));
                Console.Write(" Escolha uma opção: ");
                seletor = Utils.lerInt(Console.ReadLine(), 0, " Entrada inválida!\n Informe outro número: ");

                switch (seletor)
                {
                    case 0:
                        Console.WriteLine(" Programa finalizado!");
                        break;
                    case 1:
                        adicionarContato();
                        break;
                    case 2:
                        pesquisarContato();
                        break;
                    case 3:
                        alterarContato();
                        break;
                    case 4:
                        // removerContato();
                        break;
                    case 5:
                        // listarContatos();
                        break;
                    default:
                        Utils.MensagemErro("Digite um número de 0-5!");
                        break;
                }
            }
        }

        static void adicionarContato()
        {
            Utils.Titulo("ADICIONAR CONTATO 1/3");
            Console.WriteLine(" DADOS PESSOAIS");
            Console.Write(" Informe o nome: ");
            string nome = Console.ReadLine();
            Console.Write(" Informe o e-mail: ");
            string email = Utils.lerRegex(regexEmail, " E-mail inválido!\n Tente novamente: ");

            Utils.Titulo("ADICIONAR CONTATO 2/3");
            Console.WriteLine(" DATA DE NASCIMENTO");
            Console.Write(" Informe o ano: ");
            int ano = Utils.lerMinMax(Console.ReadLine(), 1900, DateTime.Now.Year, " Ano inválido!\n Tente novamente: ");
            Console.Write(" Informe o mês: ");
            int mes = Utils.lerMinMax(Console.ReadLine(), 1, 12, " Mês inválido!\n Tente novamente: ");
            int diasNoMes = DateTime.DaysInMonth(ano, mes);
            Console.Write(" Informe o dia: ");
            int dia = Utils.lerMinMax(Console.ReadLine(), 1, diasNoMes, " Dia inválido!\n Tente novamente: ");
            Data dataNasc = new Data(dia, mes, ano);

            Utils.Titulo("ADICIONAR CONTATO 3/3");
            Console.WriteLine(" TELEFONE");
            Console.Write(" Lista de Tipos:\n 1. Celular\n 2. Telefone Fixo\n Informe o tipo: ");
            string tipo = Utils.lerTipo(Console.ReadLine(), " Tipo inválido!\n Tente novamente: ");
            Console.Write(" Informe o número: ");
            string numero = Utils.lerRegex(regexTelefone, " Número inválido!\n Tente novamente: ");
            Console.Write(" Esse é o telefone principal?\n 1. Sim\n 0. Não\n Informe uma das opções: ");
            int verificadorPrincipal = Utils.lerMinMax(Console.ReadLine(), 0, 1, " Opção inválida!\n Tente novamente: ");
            bool principal = (verificadorPrincipal == 1);

            Telefone telefone = new Telefone(tipo, numero, principal);
            Contato contato = new Contato(email, nome, dataNasc, telefone);

            if (agenda.adicionar(contato))
                Utils.MensagemSucesso("Contato adicionado com sucesso.");
            else
                Utils.MensagemErro("Não foi possível adicionar o contato. O nome ou o telefone já existe.");
        }

        static void pesquisarContato()
        {
            Utils.Titulo("PESQUISAR CONTATO");
            Console.Write(" Informe o nome do contato: ");
            string nome = Console.ReadLine();

            Contato contatoPesquisado = new Contato(nome);
            Contato encontrou = agenda.pesquisar(contatoPesquisado);

            if (encontrou != null)
            {
                Utils.Titulo("PESQUISAR CONTATO");
                Console.WriteLine(encontrou.ToString());
                Utils.MensagemSucesso("Contato encontrado.");
            }
            else
            {
                Utils.MensagemErro("Contato não encontrado.");
            }
        }

        static void alterarContato()
        {
            Utils.Titulo("ALTERAR CONTATO");
            Console.Write(" Informe o nome do contato: ");
            string nome = Console.ReadLine();

            Contato contatoPesquisado = new Contato(nome);
            Contato encontrou = agenda.pesquisar(contatoPesquisado);

            if (encontrou != null)
            {
                Utils.Titulo("ALTERAR CONTATO 1/3");
                Console.WriteLine(" NOVOS DADOS PESSOAIS");
                Console.Write($" Nome (atual: {encontrou.Nome}): ");
                string novoNome = Console.ReadLine();
                Console.Write($" E-mail (atual: {encontrou.Email}): ");
                string novoEmail = Utils.lerRegex(regexEmail, " E-mail inválido!\n Tente novamente: ");

                Utils.Titulo("ALTERAR CONTATO 2/3");
                Console.WriteLine(" NOVA DATA DE NASCIMENTO");
                Console.Write($" Ano (atual: {encontrou.DtNasc.Ano}): ");
                int novoAno = Utils.lerMinMax(Console.ReadLine(), 1900, DateTime.Now.Year, " Ano inválido!\n Tente novamente: ");
                Console.Write($" Mês (atual: {encontrou.DtNasc.Mes}): ");
                int novoMes = Utils.lerMinMax(Console.ReadLine(), 1, 12, " Mês inválido!\n Tente novamente: ");
                int diasNoMes = DateTime.DaysInMonth(novoAno, novoMes);
                Console.Write($" Dia (atual: {encontrou.DtNasc.Dia}): ");
                int novoDia = Utils.lerMinMax(Console.ReadLine(), 1, diasNoMes, " dia inválido!\n Tente novamente: ");
                Data novaDataNasc = new Data(novoDia, novoMes, novoAno);

                Utils.Titulo("ALTERAR CONTATO 3/3");
                Console.WriteLine(" NOVO TELEFONE");
                Console.Write($" Lista de Tipos:\n 1. Celular\n 2. Telefone Fixo\n Informe o tipo: ");
                string novoTipo = Utils.lerTipo(Console.ReadLine(), " Tipo inválido!\n Tente novamente: ");
                Console.Write(" Número: ");
                string novoNumero = Utils.lerRegex(regexTelefone, " Número inválido!\n Tente novamente: ");
                Console.Write(" Esse é o novo telefone principal?\n 1. Sim\n 0. Não\n Informe uma das opções: ");
                int verificadorPrincipal = Utils.lerMinMax(Console.ReadLine(), 0, 1, " Opção inválida!\n Tente novamente: ");
                bool novoPrincipal = (verificadorPrincipal == 1);
                Telefone novoTelefone = new Telefone(novoTipo, novoNumero, novoPrincipal);

                encontrou.Nome = novoNome;
                encontrou.Email = novoEmail;
                encontrou.DtNasc = novaDataNasc;
                encontrou.adicionarTelefone(novoTelefone);
                if (agenda.alterar(encontrou))
                    Utils.MensagemSucesso("Contato alterado com sucesso.");
                else
                    Utils.MensagemErro("Não foi possível alterar o contato.");
            }
            else
                Utils.MensagemErro("Contato não encontrado.");
        }
    }
}