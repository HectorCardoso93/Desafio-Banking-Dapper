using DesafioTecnicoBanking.Modelos;
using DesafioTecnicoBanking.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnicoBanking.Metodos
{
    public class Deposito
    {
        private RepositorioConta _repositorioConta;
        public Deposito()
        {
            _repositorioConta = new RepositorioConta();
        }
        public void MainDeposito(Conta destino, Conta depositante, double valor)
        {
            //Quem foi o Depositante

            //Qual conta destino do deposito

            //Qual o valor depositado

            destino.Saldo += valor;
            depositante.Saldo -= valor;
            _repositorioConta.AtualizarSaldoConta(destino);
            _repositorioConta.AtualizarSaldoConta(depositante);
            MessageBox.Show($"Deposito efetuado com sucesso da conta - ({depositante.NumeroConta}) para conta - ({destino.NumeroConta}) no valor de R${valor.ToString("F")}");
        }
    }
}
