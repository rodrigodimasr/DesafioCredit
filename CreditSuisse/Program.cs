using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace CreditSuisse
{
    public static class Program
    {
        static void Main(string[] args)
        {
            List<ITrade> portifolio = new List<ITrade>();
            portifolio.Add(new Trade1());
            portifolio.Add(new Trade2());
            portifolio.Add(new Trade3());
            portifolio.Add(new Trade4());


            var itens = new List<string>();
            foreach (var item in portifolio)
            {
                var clientSector = removerAcentos(item.ClientSector);
                //Regex.Replace(item.ClientSector, "[^0-9a-zA-Z]+", "");

                int valor = Convert.ToInt32(item.Value.ToString().Replace('.', ' ').Trim());

                switch (clientSector.ToUpper())
                {
                    case "PRIVADO":
                        if (valor > 1000000)
                            itens.Add("HIGHRISK");
                        break;
                    case "PUBLICO":
                        if (valor < 1000000)
                            itens.Add("LOWRISK");
                        else if (valor > 1000000)
                            itens.Add("MEDIUMRISK");
                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
            }

            foreach (var item in itens)
            {
                Console.WriteLine("Output: {0}  \n", item);

            }
            Console.ReadLine();

            //Para rodar meu exemplo descomente a linha de baixo.
            // MyProgram();
        }
        public static string removerAcentos(string texto)
        {
            string comAcentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
            string semAcentos = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";

            for (int i = 0; i < comAcentos.Length; i++)
            {
                texto = texto.Replace(comAcentos[i].ToString(), semAcentos[i].ToString());
            }
            return texto;
        }
        public static string RemoveAccents(this string text)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }

        public static void MyProgram()
        {
            //Estou usando um arquivo apenas, porém poder ser um diretório e ler todos os arquivos .txt
            string[] lines = File.ReadAllLines(@"C:\Dimas\teste.txt", Encoding.Default);
            List<ITrade1> itrades = new List<ITrade1>();

            foreach (var line in lines)
            {
                Trade10 trade = new Trade10();
                var clientSector = string.Empty;
                var value = string.Empty;



                if (line.ToUpper().Contains("VALUE"))
                {
                    value = line.Substring(8, 9);
                    value = value.Replace(";", " ").Trim();
                }

                if (line.ToUpper().Contains("CLIENTSECTOR"))
                {
                    if (line.ToUpper().Contains("PRIVATE"))
                    {
                        clientSector = line.Substring(34, 7);
                        clientSector = clientSector.Replace('"', ' ').Replace("=", " ").Replace("}", " ").Trim();
                    }
                    else {
                        clientSector = line.Substring(33, 7);
                        clientSector = clientSector.Replace('"', ' ').Replace("=", " ").Replace("}", " ").Trim();
                    }
                }

                
                trade.ClientSector = removerAcentos(clientSector); 
                trade.Value = Convert.ToDouble(value.Replace('.', ' ').Trim());

                itrades.Add(trade);

            }


            var itens = new List<string>();
            foreach (var item in itrades)
            {
                var clientSector = removerAcentos(item.ClientSector);
                //Regex.Replace(item.ClientSector, "[^0-9a-zA-Z]+", "");

                int valor = Convert.ToInt32(item.Value.ToString().Replace('.', ' ').Trim());

                switch (clientSector.ToUpper())
                {
                    case "PRIVATE":
                        if (valor > 1000000)
                            itens.Add("HIGHRISK");
                        break;
                    case "PUBLIC":
                        if (valor < 1000000)
                            itens.Add("LOWRISK");
                        else if (valor > 1000000)
                            itens.Add("MEDIUMRISK");
                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
            }

            foreach (var item in itens)
            {
                Console.WriteLine("Output: {0}  \n", item);

            }
            Console.ReadLine();

            //Parte da lógica.
            //Aqui não irei implementar uma connection string com o banco, porém ficaria muito melhor
            //se criar uma tabelas de regras para cada tipo, onde nessa tabela teria no monímo três colunas
            // e essas colunas seria a lógica dos nossos ifs exemplo.

            //Exemplo se criar uma tabela

            //var regras = "select * from Regras"

            // foreach (var regra in regras)
            //{
            //    switch (regra.Nome.ToUpper())
            //    {
            //        case "PRIVADO":
            //            if (regra.valor > regra.ValorBase)
            //                itens.Add("HIGHRISK");
            //            break;
            //        case "PUBLICO":
            //            if (regra.valor < regra.ValorBase)
            //                itens.Add("LOWRISK");
            //            else if (regra.valor > regra.ValorBase)
            //                itens.Add("MEDIUMRISK");
            //            break;
            //        default:
            //            Console.WriteLine("Default case");
            //            break;
            //    }
            //}





        }

    }
}
