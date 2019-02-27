using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PessoasContasLancamentos
{
    class Program
    {
        static void Main(string[] args)
        {
            Usuario funcionario = new Usuario
            {
                Contas = new List<int>(),
                Lancamentos = new List<double>()
            };

            using (StreamReader sr1 = new StreamReader("pessoa.mxm", Encoding.UTF7))
                while (!sr1.EndOfStream)
                {
                    string[] stringAux = sr1.ReadLine().Split('|');
                    funcionario.Codigo = int.Parse(stringAux[0]);
                    funcionario.Nome = stringAux[1];

                    using (StreamReader sr2 = new StreamReader("conta.mxm"))
                        while (!sr2.EndOfStream)
                        {
                            stringAux = sr2.ReadLine().Split('|');
                            int contaAux = int.Parse(stringAux[0]);
                            int codigoAux = int.Parse(stringAux[1]);

                            if (codigoAux == funcionario.Codigo)
                            {
                                funcionario.Contas.Add(contaAux);

                                using (StreamReader sr3 = new StreamReader("lancamento.mxm"))
                                    while (!sr3.EndOfStream)
                                    {
                                        stringAux = sr3.ReadLine().Split('|');
                                        int contaAuxLancamento = int.Parse(stringAux[0]);

                                        if (contaAuxLancamento == contaAux)
                                        {
                                            double valorLancamento = double.Parse(stringAux[1], CultureInfo.InvariantCulture);
                                            funcionario.Transacao(valorLancamento);
                                        }
                                    }
                            }
                        }

                    if (funcionario.Saldo < 0)
                    {
                        using (StreamWriter srDev = File.AppendText("devedores.mxm"))
                            srDev.WriteLine(funcionario.Nome + "," + funcionario.Saldo.ToString("F2", CultureInfo.InvariantCulture));
                    }
                    else if (funcionario.Media > 1000.0)
                    {
                        using (StreamWriter swBon = File.AppendText("bonus.mxm"))
                            swBon.WriteLine(funcionario.Nome + "," + (funcionario.Media).ToString("F2", CultureInfo.InvariantCulture));
                    }
                }
        }
    }
}
