using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioTecnicoBanking.Modelos;
using DesafioTecnicoBanking.Repositories;

namespace DesafioTecnicoBanking.Metodos
{
    public class ConsultarSaldo
    {
        private RepositorioConta _repositorioConta;
        private VerificarPrimeiraOperacaoDoMes verificacao;
        public ConsultarSaldo()
        {
            _repositorioConta = new RepositorioConta();
            verificacao = new VerificarPrimeiraOperacaoDoMes();
        }
        public void MainConsultaSaldo(Conta conta)
        {
            bool verificado = verificacao.MainVerificarOperacao(conta);
            if (!conta.IsContaCorrente)
            {
                MessageBox.Show($"Seu saldo é de {conta.Saldo.ToString("F")}");
                return;
            }
            if (verificado)
            {
                MessageBox.Show("Primeira operação do mês é gratuito.");
                MessageBox.Show($"Seu saldo é de {conta.Saldo.ToString("F")}");
            } else
            {
                double operacaoConsultaSaldo = 1.37;
                conta.Saldo -= operacaoConsultaSaldo;
                _repositorioConta.AtualizarSaldoConta(conta);
                MessageBox.Show($"A operação de saque foi feita e seu saldo é de {conta.Saldo.ToString("F")}");
            }

        }
    }
}
