using Dapper.Contrib.Extensions;
using DesafioTecnicoBanking.Modelos;
using DesafioTecnicoBanking.Repositories;
using MySql.Data.MySqlClient;
using System.Configuration;
using Dapper;

namespace DesafioTecnicoBanking
{
    public partial class Form1 : Form
    {
        private List<Conta> Contas { get; set; } = new List<Conta>();
        internal RepositorioConta _repositorioConta;
        internal RepositorioPessoa _repositorioPessoa;
        public void AdicionarConta(Conta conta)
        {
            this.Contas.Add(conta);
            comboContas.Items.Add(conta);
            _repositorioPessoa.AdicionarPessoa(conta.Titular);
            _repositorioConta.AdicionarConta(conta);
        }
        public Form1()
        {
            InitializeComponent();
            _repositorioConta = new RepositorioConta();
            _repositorioPessoa = new RepositorioPessoa();
            SetTitulares();
        }

        public void SetTitulares()
        {
            var titulares = _repositorioConta.ObterContas();

            foreach (var titular in titulares)
            {
                comboContas.Items.Add(titular.NumeroConta);
                Contas.Add(titular);
            }
        }

        private void botaoAdicionarConta_Click(object sender, EventArgs e)
        {
            FormNovaConta formularioNovaConta = new FormNovaConta(this);
            formularioNovaConta.ShowDialog();
        }

        private void botaoDeposito_Click(object sender, EventArgs e)
        {
            FormDeposito formularioDeposito = new FormDeposito(this);
            formularioDeposito.SetTitulares();
            formularioDeposito.ShowDialog();
        }

        private void botaoSaldo_Click(object sender, EventArgs e)
        {
            FormConsultaSaldo formularioConsulta = new FormConsultaSaldo(this);
            formularioConsulta.SetTitulares();
            formularioConsulta.ShowDialog();
        }

        private void botaoExtrato_Click(object sender, EventArgs e)
        {
            FormExtrato formularioExtrato = new FormExtrato(this);
            formularioExtrato.ShowDialog();
        }

        private void botaoSaque_Click(object sender, EventArgs e)
        {
            FormSaque formularioSaque = new FormSaque(this);
            formularioSaque.SetTitulares();
            formularioSaque.ShowDialog();
        }

        private void botaoTransferir_Click(object sender, EventArgs e)
        {
            FormTransferencia formularioTransferencia = new FormTransferencia(this);
            formularioTransferencia.SetTitulares();
            formularioTransferencia.ShowDialog();
        }

        private void comboContas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = Convert.ToInt32(comboContas.SelectedItem.ToString());
            var selecionada = _repositorioConta.ObterConta(indice);
            textoAgencia.Text = Convert.ToString(selecionada.Agencia);
            textoNumeroConta.Text = Convert.ToString(selecionada.NumeroConta);
            //textoTitular.Text = selecionada.Titular.Nome;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
