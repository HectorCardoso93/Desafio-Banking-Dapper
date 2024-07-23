using DesafioTecnicoBanking.Modelos;
using DesafioTecnicoBanking.Metodos;
using MySqlX.XDevAPI.Relational;
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
    public partial class FormConsultaSaldo : Form
    {
        private List<Conta> contas;
        private Form1 formPrincipal;
        private ConsultarSaldo consultarSaldo;
        public FormConsultaSaldo(Form1 formPrincipal)
        {
            contas = new List<Conta>();
            InitializeComponent();
            this.formPrincipal = formPrincipal;
            consultarSaldo = new ConsultarSaldo();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void botaoVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetTitulares()
        {
            var titulares = formPrincipal._repositorioConta.ObterContas();

            foreach (var titular in titulares)
            {
                comboTitular.Items.Add(titular.NumeroConta);
                contas.Add(titular);
            }
        }

        private void FormConsultaSaldo_Load(object sender, EventArgs e)
        {

        }

        private void comboTitular_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int indice = comboTitular.SelectedIndex;
            //Conta selecionada = contas[indice];
            //selecionada.ConsultarSaldo();

            
            int indiceDepositante = Convert.ToInt32(comboTitular.SelectedItem.ToString());
            var titular = formPrincipal._repositorioConta.ObterConta(indiceDepositante);
            consultarSaldo.MainConsultaSaldo(titular);

            textoAgencia.Text = Convert.ToString(titular.Agencia);
            textoConta.Text = Convert.ToString(titular.NumeroConta);
            textoSaldo.Text = Convert.ToString(titular.Saldo);
        }
    }
}
