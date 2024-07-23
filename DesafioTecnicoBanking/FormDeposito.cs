using DesafioTecnicoBanking.Metodos;
using DesafioTecnicoBanking.Modelos;
using MySql.Data.MySqlClient;
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
    public partial class FormDeposito : Form
    {
        private List<Conta> contas;
        private Form1 formPrincipal;
        private Deposito depositos;
        public FormDeposito(Form1 formPrincipal)
        {
            contas = new List<Conta>();
            this.formPrincipal = formPrincipal;
            depositos = new Deposito();
            InitializeComponent();
        }
        public void SetTitulares()
        {
            var titulares = formPrincipal._repositorioConta.ObterContas();

            foreach (var titular in titulares)
            {
                comboDepositante.Items.Add(titular.NumeroConta);
                comboDestino.Items.Add(titular.NumeroConta);
                contas.Add(titular);
            }
        }

        private void botaoCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void botaoDeposito_Click(object sender, EventArgs e)
        {
            //int indiceDepositante = comboDepositante.SelectedIndex;
            //int indiceDestino = comboDestino.SelectedIndex;

            //var depositante = contas[indiceDepositante];
            //var destino = contas[indiceDestino];

            double valor = Convert.ToDouble(textoValor.Text);
            int indiceDepositante = Convert.ToInt32(comboDepositante.SelectedItem.ToString());
            var depositante = formPrincipal._repositorioConta.ObterConta(indiceDepositante);
            int indiceDestino = Convert.ToInt32(comboDestino.SelectedItem.ToString());
            var destino = formPrincipal._repositorioConta.ObterConta(indiceDestino);
            depositos.MainDeposito(destino,depositante, valor);
            //MessageBox.Show($"O deposito foi realizado com sucesso. Depositante {depositante.Titular.Nome} para {destino.Titular.Nome} Valor{valor}" );

            //depositante.Deposito(destino, valor);

        }

        private void FormDeposito_Load(object sender, EventArgs e)
        {

        }
    }
}
