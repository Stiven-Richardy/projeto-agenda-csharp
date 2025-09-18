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
                Console.WriteLine("--------------------------------------------");
                Console.Write(" Escolha uma opção: ");
                seletor = Utils.lerInt(Console.ReadLine(), 0, " Entrada inválida!\n Informe outro número: ");

                switch (seletor)
                {
                    case 0:
                        Console.WriteLine(" Programa finalizado!");
                        break;
                    case 1:
                        // adicionarContato();
                        break;
                    case 2:
                        // pesquisarContato();
                        break;
                    case 3:
                        // alterarContato();
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
    }
}