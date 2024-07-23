using DesafioTecnicoBanking.Modelos;
using DesafioTecnicoBanking.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnicoBanking.Metodos
{
    public class Transferencia
    {
        private RepositorioConta _repositorioConta;
        private VerificarPrimeiraOperacaoDoMes verificacao;
        public Transferencia()
        {
            _repositorioConta = new RepositorioConta();
            verificacao = new VerificarPrimeiraOperacaoDoMes();
        }
        public void MainTransferencia(Conta destino, Conta remetente, double valor)
        {
            //Conta destino da transferencia(sempre será no mesmo banco)
            if (destino.Agencia == remetente.Agencia)
            {
                bool verificado = verificacao.MainVerificarOperacao(remetente);
                if (verificado || !remetente.IsContaCorrente)
                {
                    remetente.Saldo -= valor;
                    destino.Saldo += valor;
                    _repositorioConta.AtualizarSaldoConta(destino);
                    _repositorioConta.AtualizarSaldoConta(remetente);
                    MessageBox.Show($"A transferência foi concluída com sucesso para {destino.NumeroConta} no valor de {valor}");
                } else
                {
                    remetente.Saldo -= valor;
                    destino.Saldo += valor;
                    _repositorioConta.AtualizarSaldoConta(destino);
                    _repositorioConta.AtualizarSaldoConta(remetente);
                    MessageBox.Show($"A transferência foi concluída com sucesso para {destino.NumeroConta} no valor de {valor}");
                    //Operação de transferencia.
                    double operacaoTransferencia = 2.25;
                    remetente.Saldo -= (valor + operacaoTransferencia);
                    _repositorioConta.AtualizarSaldoConta(remetente);
                    MessageBox.Show($"A operação de transferência foi feita e seu saldo é de {remetente.Saldo.ToString("F")}");
                }
            }
            else
            {
                MessageBox.Show("A operação não pode ser concluída pois não são do mesmo banco.");
            }
            //Qual o valor transferido

            //CONTA POUPANÇA
            //    if (destino is ContaCorrente)
            //{
            //    MessageBox.Show("Transferência de conta poupança para conta corrente não permitida.");
            //}
            //else
            //{
            //    base.Transferencia(destino, valor);
            //}

            //CONTA CORRENTE
            //    bool operacao = VerificarPrimeiraOperacaoMes();
            //double operacaoTransferencia = 2.25;
            //if (operacao)
            //{
            //    //Qual o valor sacado
            //    base.Transferencia(destino, valor);
            //    //As operações de saque não podem exceder o saldo mais o limite de cheque especial
            //}
            //else
            //{
            //    if (destino.Agencia == this.Agencia)
            //    {
            //        this.Saldo -= (valor + operacaoTransferencia);
            //    }
            //    else
            //    {
            //        MessageBox.Show("A operação não pode ser concluída pois não são do mesmo banco.");
            //    }
            //}
            //Conta destino da transferencia(sempre será no mesmo banco)
            //Qual o valor transferido
        }
    }
}
