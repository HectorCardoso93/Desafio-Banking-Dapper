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
    public partial class FormTransferencia : Form
    {
        private List<Conta> contas;
        private Form1 formPrincipal;
        private Transferencia transferencias;
        public FormTransferencia(Form1 formPrincipal)
        {
            contas = new List<Conta>();
            this.formPrincipal = formPrincipal;
            transferencias = new Transferencia();
            InitializeComponent();
        }

        public void SetTitulares()
        {
            var titulares = formPrincipal._repositorioConta.ObterContas();

            foreach (Conta titular in titulares)
            {
                comboRemetente.Items.Add(titular.NumeroConta);
                comboDestino.Items.Add(titular.NumeroConta);
                contas.Add(titular);
            }
        }

        private void FormTransferencia_Load(object sender, EventArgs e)
        {

        }

        private void botaoTransferir_Click_1(object sender, EventArgs e)
        {
            double valor = Convert.ToDouble(textoValor.Text);
            int indiceRemetente = Convert.ToInt32(comboRemetente.SelectedItem.ToString());
            var remetente = formPrincipal._repositorioConta.ObterConta(indiceRemetente);
            int indiceDestino = Convert.ToInt32(comboDestino.SelectedItem.ToString());
            var destino = formPrincipal._repositorioConta.ObterConta(indiceDestino);
            transferencias.MainTransferencia(destino, remetente, valor);
        }

        private void botaoCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
