using System.Collections.Generic;

namespace PessoasContasLancamentos
{
    public class Usuario
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public double Saldo { get; set; }
        public double Media { get; set; }
        public List<int> Contas { get; set; }
        public List<double> Lancamentos { get; set; }

        public Usuario()
        {
        }
        public double Transacao(double amount)
        {
            Lancamentos.Add(amount);
            return Saldo += amount;
        }
        public double CalcularMedia()
        {
            return Media = Saldo / Lancamentos.Count;
        }

    }
}