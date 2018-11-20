using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string formattedDate = "2008-09-15T09:30:41.7752486-07:00";
            DateTime roundtripDate = DateTime.Parse(formattedDate, null, DateTimeStyles.RoundtripKind);
            Console.WriteLine(roundtripDate.ToString("dd/MM/yyyy - HH:mm"));
            IList<Teste> teste = new List<Teste>();
            IList<Comparador> filtro = new List<Comparador>();
            filtro.Add(new Comparador() { Item = "b" });
            filtro.Add(new Comparador() { Item = "c" });
            teste.Add(new Teste()
            {
                Dado = "a",
                Subtotal = 1
            });
            teste.Add(new Teste()
            {
                Dado = "b",
                Subtotal = 2
            });
            teste.Add(new Teste()
            {
                Dado = "c",
                Subtotal = 3
            });
            teste.Add(new Teste()
            {
                Dado = "d",
                Subtotal = 4
            });
            teste.Add(new Teste()
            {
                Dado = "b",
                Subtotal = 5
            });
            int total = teste.Select(x => x.Subtotal).Sum();
            TimeSpan time = TimeSpan.FromSeconds(3600);
            int hora = Convert.ToInt32(time.ToString().Split(':')[0]);

            bool valor = teste.Select(x => x.Subtotal == 2).Count() > 0;
            double numeroGrande = 123444.23456789019201920192;

            DateTime data = DateTime.ParseExact("06/08/2018", "dd/MM/yyyy",
                                       System.Globalization.CultureInfo.InvariantCulture);
            Console.WriteLine(data.ToString());

            int diaNumerico = Convert.ToInt32(data.DayOfWeek.ToString("D", new CultureInfo("pt-BR")));

            Console.WriteLine(time.ToString());
            Console.WriteLine(hora);
            Console.WriteLine(total.ToString());
            Console.WriteLine(valor.ToString());
            Console.WriteLine(numeroGrande.ToString("0.000"));
            Console.WriteLine(Senha.Gerar(6));
            Console.WriteLine(diaNumerico.ToString());

            var novaLista = (from a in teste
                             join b in filtro on a.Dado equals b.Item
                             select a);
            foreach (var item in novaLista)
            {
                Console.WriteLine(item.Dado + " " + item.Subtotal);
            }
            Console.ReadLine();
        }
    }
    public class Teste
    {
        public string Dado { get; set; }
        public int Subtotal { get; set; }
    }
    public class Comparador
    {
        public string Item { get; set; }
    }
     public static class Senha
     {
         public static string Gerar(int tamanho)
         {
             var chars = "abcdefghijlkmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
             var random = new Random();
             var result = new string(
                 Enumerable.Repeat(chars, tamanho)
                           .Select(s => s[random.Next(s.Length)])
                           .ToArray());
             return result;
         }
     }
}
