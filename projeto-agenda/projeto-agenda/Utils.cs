using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace projeto_agenda
{
    internal class Utils
    {
        public static string lerRegex(string regex, string msgErro)
        {
            string entrada = Console.ReadLine();
            bool valido = Regex.IsMatch(entrada, regex, RegexOptions.IgnoreCase);
            while (!valido)
            {
                Console.Write(msgErro);
                entrada = Console.ReadLine();
                valido = Regex.IsMatch(entrada, regex, RegexOptions.IgnoreCase);
            }
            return entrada;
        }

        public static int lerInt(string entrada, int min, string msgErro)
        {
            bool converteu = int.TryParse(entrada, out int intValido);
            while (!converteu || intValido < min)
            {
                Console.Write(msgErro);
                converteu = int.TryParse(Console.ReadLine(), out intValido);
            }
            return intValido;
        }

        public static double lerDouble(string entrada, int min, string msgErro)
        {
            bool converteu = double.TryParse(entrada, out double doubleValido);
            while (!converteu || doubleValido < min)
            {
                Console.WriteLine(msgErro);
                converteu = double.TryParse(Console.ReadLine(), out doubleValido);
            }
            return doubleValido;
        }

        public static void Titulo(string titulo)
        {
            Console.Clear();
            Console.WriteLine(new string('=', 44));
            Console.WriteLine($" AGENDA - {titulo}");
            Console.WriteLine(new string('=', 44));
        }

        public static void MensagemErro(string texto)
        {
            Console.WriteLine();
            Console.WriteLine($" {texto}");
            Console.WriteLine(" [Pressione qualquer tecla...]");
            Console.ReadKey();
        }

        public static void MensagemSucesso(string texto)
        {
            Console.WriteLine();
            Console.WriteLine($" {texto}");
            Console.WriteLine(" [Pressione qualquer tecla...]");
            Console.ReadKey();
        }

        public static int lerMinMax(string entrada, int min, int max, string msgErro)
        {
            bool converteu = int.TryParse(entrada, out int intValido);
            while (!converteu || intValido < min || intValido > max)
            {
                Console.Write(msgErro);
                converteu = int.TryParse(Console.ReadLine(), out intValido);
            }
            return intValido;
        }

        public static string lerTipo(string entrada, string msgErro)
        {
            string opcao = "";
            int ent = Utils.lerInt(entrada, 1, msgErro);
            do
            {
                if (ent == 1)
                    opcao = "Celular";
                else if (ent == 2)
                    opcao = "Telefone fixo";
                else
                    ent = Utils.lerInt(entrada, 1, msgErro);
            } while (ent > 2);
            return opcao;
        }
    }
}