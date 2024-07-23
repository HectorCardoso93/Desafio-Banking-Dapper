using DesafioTecnicoBanking.Metodos;
using DesafioTecnicoBanking.Modelos;
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
    public partial class FormSaque : Form
    {
        List<Conta> contas;
        private Form1 formPrincipal;
        private Saque saques;
        public FormSaque(Form1 formPrincipal)
        {
            contas = new List<Conta>();
            saques = new Saque();
            InitializeComponent();
            this.formPrincipal = formPrincipal;
        }

        internal void SetTitulares()
        {
            var titulares = formPrincipal._repositorioConta.ObterContas();

            foreach (var titular in titulares)
            {
                comboTitulares.Items.Add(titular.NumeroConta);
                contas.Add(titular);
            }
        }

        private void botaoCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void botaoSacar_Click(object sender, EventArgs e)
        {
            //int indice = comboTitulares.SelectedIndex;
            //Conta selecionada = contas[indice];

            //double valor = Convert.ToDouble(textoValor.Text);

            //selecionada.Saque(valor);

            double valor = Convert.ToDouble(textoValor.Text);
            int indiceTitular = Convert.ToInt32(comboTitulares.SelectedItem.ToString());
            var titular = formPrincipal._repositorioConta.ObterConta(indiceTitular);
            saques.MainSaque(titular,valor);

            //double valor = Convert.ToDouble(textoValor.Text);
            //int indiceDepositante = Convert.ToInt32(comboDepositante.SelectedItem.ToString());
            //var depositante = formPrincipal._repositorioPessoa.ObterConta(indiceDepositante);
            //int indiceDestino = Convert.ToInt32(comboDestino.SelectedItem.ToString());
            //var destino = formPrincipal._repositorioPessoa.ObterConta(indiceDestino);
            //depositante.Deposito(destino, valor);
        }
    }
}
