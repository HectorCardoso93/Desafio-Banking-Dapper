using DesafioTecnicoBanking.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DesafioTecnicoBanking.Modelos
{
    [Table("Conta")]
    public class Conta
    {
        private static int numeroConta;
        internal RepositorioConta _repositorioPessoa;
        public Conta()
        {
            _repositorioPessoa = new RepositorioConta();
            //var conta = _repositorioPessoa.ObterContas();
            //var proximoNumero = conta.Max(NumeroConta);
            //this.NumeroConta = Conta.numeroConta;
        }
        //public int ProximoNumeroConta()
        //{
        //    var contas =
        //    return numeroConta;
        //}
        //public override String ToString()
        //{
        //    //return "Titular: " + this.Titular.Nome;
        //}
        [Key]
        public int NumeroConta { get; internal set; }
        public int Agencia { get => 100; }
        public Pessoa Titular { get; set; }
        public double Saldo { get; internal set; }
        public double ChequeEspecial { get => 300.00; }
        public bool IsContaCorrente { get; set; }
        public DateTime DataUltimaOperacao { get; set; }
        public double SaldoTotal { get => this.Saldo + this.ChequeEspecial; }
        
    }
}
