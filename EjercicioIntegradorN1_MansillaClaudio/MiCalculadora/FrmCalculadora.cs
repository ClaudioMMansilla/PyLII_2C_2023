using Entidades;
using System.Diagnostics;

namespace MiCalculadora
{
    public partial class FrmCalculadora : Form
    {
        private Operacion calculadora;
        private Numeracion primerOperando;
        private Numeracion segundoOperando;
        private Numeracion? resultado;
        private ESistema sistema;

        public FrmCalculadora()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtPrimerOperador.ResetText();
            this.txtSegundoOperador.ResetText();
            this.lblResultado.Text = "RESULTADO: ";
            this.resultado = null;

        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            this.SetResultado();
        }

        private void rdbDecimal_CheckedChanged(object sender, EventArgs e)
        {
            if ((int)this.sistema == (int)ESistema.Binario)
            {
                this.sistema = ESistema.Decimal;
            }

            if (this.txtPrimerOperador.Text != String.Empty && this.txtSegundoOperador.Text != String.Empty)
            {
                this.SetResultado();
            }
        }

        private void rdbBinario_CheckedChanged(object sender, EventArgs e)
        {
            if ((int)this.sistema == (int)ESistema.Decimal)
            {
                this.sistema = ESistema.Binario;
            }

            if (this.txtPrimerOperador.Text != String.Empty && this.txtSegundoOperador.Text != String.Empty)
            {
                this.SetResultado();
            }
        }

        private void txtPrimerOperador_TextChanged(object sender, EventArgs e)
        {
            this.primerOperando = new Numeracion(this.txtPrimerOperador.Text, this.sistema);
        }

        private void txtSegundoOperador_TextChanged(object sender, EventArgs e)
        {
            this.segundoOperando = new Numeracion(this.txtSegundoOperador.Text, this.sistema);
        }

        private void FrmCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea cerrar la calculadora?", "Cierre", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (resultado == DialogResult.OK)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }

        }

        private void FrmCalculadora_Load(object sender, EventArgs e)
        {

        }

        private void SetResultado()
        {
            this.calculadora = new Operacion(this.primerOperando, this.segundoOperando);

            if (this.cmbOperacion.Text.Length > 0)
            {
                this.resultado = calculadora.Operar(char.Parse(this.cmbOperacion.Text));
                this.lblResultado.Text = $"RESULTADO: {this.resultado.ConvertirA(this.sistema)}";
            }
        }
    }
}