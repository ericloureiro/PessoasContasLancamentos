using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace PessoasContasLancamentos
{
    class Program
    {
        static void Main(string[] args)
        {
            var funcionario = new Usuario
            {
                Contas = new List<int>(),
                Lancamentos = new List<double>()
            };

            using (var pessoaStringReader = new StreamReader("pessoa.mxm", Encoding.UTF7))
                while (!pessoaStringReader.EndOfStream)
                {
                    var linhaDeDado = pessoaStringReader.ReadLine().Split('|');
                    funcionario.Codigo = int.Parse(linhaDeDado[0]);
                    funcionario.Nome = linhaDeDado[1];

                    using (var contaStringReader = new StreamReader("conta.mxm"))
                        while (!contaStringReader.EndOfStream)
                        {
                            linhaDeDado = contaStringReader.ReadLine().Split('|');
                            var numeroConta = int.Parse(linhaDeDado[0]);
                            var numeroPessoa = int.Parse(linhaDeDado[1]);

                            if (numeroPessoa == funcionario.Codigo)
                            {
                                funcionario.Contas.Add(numeroConta);

                                using (var lancamentoStringReader = new StreamReader("lancamento.mxm"))
                                    while (!lancamentoStringReader.EndOfStream)
                                    {
                                        linhaDeDado = lancamentoStringReader.ReadLine().Split('|');
                                        var numeroLancamento = int.Parse(linhaDeDado[0]);

                                        if (numeroLancamento == numeroConta)
                                        {
                                            var valorLancamento = double.Parse(linhaDeDado[1], CultureInfo.InvariantCulture);
                                            funcionario.Transacao(valorLancamento);
                                        }
                                    }
                            }
                        }

                    if (funcionario.Saldo < 0)
                    {
                        using (var devedoresStringWriter = File.AppendText("devedores.mxm"))
                            devedoresStringWriter.WriteLine(funcionario.Nome + "," + funcionario.Saldo.ToString("F2", CultureInfo.InvariantCulture));
                    }
                    else if (funcionario.Media > 1000.0)
                    {
                        using (var bonusStringWriter = File.AppendText("bonus.mxm"))
                            bonusStringWriter.WriteLine(funcionario.Nome + "," + (funcionario.Media).ToString("F2", CultureInfo.InvariantCulture));
                    }
                }
        }
    }
}
