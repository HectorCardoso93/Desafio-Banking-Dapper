using DesafioTecnicoBanking.Modelos;
using DesafioTecnicoBanking.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnicoBanking.Metodos
{
    public class VerificarPrimeiraOperacaoDoMes
    {
        private RepositorioConta _repositorioConta;
        public VerificarPrimeiraOperacaoDoMes()
        {
            _repositorioConta = new RepositorioConta();
        }
        public bool MainVerificarOperacao(Conta conta)
        {
            DateTime dataAtual = DateTime.Now;
            DateTime dataUltimaOperacao = conta.DataUltimaOperacao;
            if (dataUltimaOperacao.Month != dataAtual.Month || dataUltimaOperacao.Year != dataAtual.Year)
            {
                conta.DataUltimaOperacao = DateTime.Now;
                _repositorioConta.AtualizarData(conta);
                return true;
            }
            else
            {
                conta.DataUltimaOperacao = DateTime.Now;
                _repositorioConta.AtualizarData(conta);
                //operacaoGratuita = false;
                //_repositorioConta.AtualizarOperacao(conta);
                return false;
            }
        }
    }
}
