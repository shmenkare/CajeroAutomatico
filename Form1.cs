using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CajeroAutomatico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        double resultado, importe;

        Cliente CliActual = new Cliente();

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if((txtDNI.Text == CliActual.DNI) && (txtClave.Text == CliActual.clave))
            {
                panel1.Visible = true;
                string CajaAhorros = Cliente.ca;

                iblCliente.Text = CliActual.apellido + "," + CliActual.nombres + ", CA: " + CajaAhorros;

                iblSaldo.Text = "$ " + Convert.ToString(Cliente.saldo);
                txtImpOpe.Focus();
            }
            else
            {
                MessageBox.Show("Error en ingreso de clave o DNI");
                txtDNI.Text = "";
                txtClave.Text = "";
                txtDNI.Focus();
            
            }
        }
        private void RealizoOperacion(int tOpe)
        {
            switch (tOpe)
            {
                case 1:
                    {
                        if (txtImpOpe.Text != "")
                        {
                            importe = Convert.ToDouble(txtImpOpe.Text);
                            resultado = (Cliente.saldo) + (importe);

                            Cliente.saldo = resultado;

                            iblSaldo.Text = "$ " + Convert.ToString(Cliente.saldo);
                            txtImpOpe.Text = "";
                        }
                        break;
                    }
                case 2:
                    {
                        if (txtImpOpe.Text != "")
                        {
                            importe = Convert.ToDouble(txtImpOpe.Text);
                            resultado = (Cliente.saldo) - (importe);

                            if (resultado >= 0)
                            {
                                Cliente.saldo = resultado;
                                iblSaldo.Text = "$ " + Convert.ToString(Cliente.saldo);
                                txtImpOpe.Text = "";
                            }
                            else
                            {
                                MessageBox.Show("No hay saldo suficiente para realizar esta operacion");
                            }
                        }
                        else 
                        {
                            MessageBox.Show("Error en el ingreso del importe. Verifiquelo!");
                            txtImpOpe.Focus();
                        }
                        
                    }
                    break;

                case 3:
                    {
                        DialogResult result;
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        string mensaje = "Desea salir de las operaciones?";
                        string TituloMB = CliActual.apellido + " " + CliActual.nombres;
                        result = MessageBox.Show(this, mensaje, TituloMB, buttons);

                        if(result == DialogResult.Yes)
                        {
                            {
                                Cliente.saldo = 0;
                                resultado = 0;
                                txtImpOpe.Text = "";
                                iblSaldo.Text = "";
                                panel1.Visible = false;
                                txtDNI.Text = "";
                                txtClave.Text = "";
                                txtDNI.Focus();
                                MessageBox.Show("Gracias por utilizar nuestos servicios, " + CliActual.nombres+" "+ CliActual.apellido+ "!");

                            }
                        }
 
                    }
                    break;
            
            }
        
        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            RealizoOperacion(1); 
        }
        private void btnRetirar_Click(object sender, EventArgs e)
        {
            RealizoOperacion(2);
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            RealizoOperacion(3);
        }

       

        

        
    }
}