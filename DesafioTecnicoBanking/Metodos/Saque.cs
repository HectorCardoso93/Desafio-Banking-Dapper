using DesafioTecnicoBanking.Modelos;
using DesafioTecnicoBanking.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnicoBanking.Metodos
{
    public class Saque
    {
        private VerificarPrimeiraOperacaoDoMes verificacao;
        private RepositorioConta _repositorioConta;
        public Saque()
        {
            verificacao = new VerificarPrimeiraOperacaoDoMes();
            _repositorioConta = new RepositorioConta();
        }
        public void MainSaque(Conta conta, double valor)
        {
            //Qual o valor sacado

            if (conta.SaldoTotal > valor)
            {
                bool verificado = verificacao.MainVerificarOperacao(conta);
                if (verificado || !conta.IsContaCorrente)
                {
                    conta.Saldo -= valor;
                    _repositorioConta.AtualizarSaldoConta(conta);
                    MessageBox.Show($"Você sacou R${valor} e seu saldo foi para {conta.Saldo.ToString("F")}.");
                } else
                {
                    double operacaoSaque = 4.77;
                    conta.Saldo -= (valor + operacaoSaque);
                    _repositorioConta.AtualizarSaldoConta(conta);
                    MessageBox.Show($"Você sacou R${valor}.");
                    MessageBox.Show($"A operação de saque foi descontado {operacaoSaque} e seu saldo foi para {conta.Saldo.ToString("F")}");
                }
            }
            else
            {
                MessageBox.Show("Valor do saque é maior que o seu saldo");
            }
            //As operações de saque não podem exceder o saldo mais o limite de cheque especial

            //CONTA CORRENTE
            //     bool operacao = VerificarPrimeiraOperacaoMes();
            //double operacaoSaque = 4.77;
            //if (operacao)
            //{
            //    base.Saque(valor);
            //    //Qual o valor sacado

            //    //As operações de saque não podem exceder o saldo mais o limite de cheque especial
            //}
            //else
            //{
            //    if (this.SaldoTotal > valor)
            //    {
            //        this.Saldo -= (valor + operacaoSaque);
            //        MessageBox.Show($"Você sacou R${valor}.");
            //        MessageBox.Show($"A operação de saque foi descontado {operacaoSaque} e seu saldo foi para {this.Saldo.ToString("F")}");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Valor do saque é maior que o seu saldo");
            //    }
            //}
        }
    }
}
