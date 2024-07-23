using DesafioTecnicoBanking.Modelos;
using DesafioTecnicoBanking.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesafioTecnicoBanking
{
    public partial class FormNovaConta : Form
    {
        private Form1 formPrincipal;
        private RepositorioConta _repositorioPessoa;

        public FormNovaConta(Form1 formPrincipal)
        {
            this.formPrincipal = formPrincipal;
            InitializeComponent();
            _repositorioPessoa = new RepositorioConta();
        }

        public void AtualizarProximoNumeroConta()
        {
            var proximoNumeroConta = _repositorioPessoa.ObterProximoNumeroConta();
            textoConta.Text = proximoNumeroConta.ToString();
        }

        private void FormNovaConta_Load(object sender, EventArgs e)
        {
            //textoConta.Text = Convert.ToString(novaConta.ProximoNumeroConta());
            //int conta = _repositorioPessoa.ProximoNumero(novaconta);
            //textoConta.Text = Convert.ToString(novaConta.NumeroConta);
            AtualizarProximoNumeroConta();
        }

        private void botaoCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void botaoCriar_Click(object sender, EventArgs e)
        {
            //int criarAgencia = Convert.ToInt32(textoAgencia.Text);
            string criarTitular = textoTitular.Text;
            long cpfTitular = Convert.ToInt64(textoCPF.Text);
            int numeroConta = Convert.ToInt32(textoConta.Text);
            bool isContaCorrente = comboTipoDeConta.SelectedIndex == 0 ?  true : false;

            var novaConta = new Conta()
            {
                IsContaCorrente = isContaCorrente
            };
            novaConta.Titular = new Pessoa(cpfTitular, criarTitular);
            this.formPrincipal.AdicionarConta(novaConta);
            MessageBox.Show($"Nova conta criada para {novaConta.Titular.Nome} : Agência {novaConta.Agencia} - Número da Conta {numeroConta}");
            textoTitular.Text = "";
            textoCPF.Text = "";
            AtualizarProximoNumeroConta();
            //textoConta.Text = Convert.ToString(novaConta.ProximoNumeroConta());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
