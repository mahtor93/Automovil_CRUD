using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Auto_Movil;

namespace InterfazAutomovil
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            int year = 2023;

            InitializeComponent();
            for (int i = 0; i <= (2023-1900); i++)
            {
                int yearList = year-i;
                cmbYear.Items.Add(yearList.ToString());
            }

            for(int i = 0; i< Auto.Tipo_Auto.Length ; i++)
            {
                cmbTipo.Items.Add(Auto.Tipo_Auto[i]);
                
            }
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Auto a1 = new Auto();
                a1.Marca = txtMarca.Text;
                a1.Modelo = txtModelo.Text;
                a1.Patente = txtPatente.Text;
                a1.Precio = int.Parse(txtPrecio.Text);
                a1.Year = int.Parse(cmbYear.Text);
                a1.Tipo = cmbTipo.Text;

                if (a1.Validar())
                {
                    if (Registro.Create(a1))
                    {
                        dgAutos.ItemsSource = Registro.ReadAll();
                        dgAutos.Items.Refresh();
                        MessageBox.Show("Automovil añadido con éxito!");
                    }
                    else
                    {
                        MessageBox.Show("La patente ya ha sido ingresada, revise el registro");
                    }
                    
                }
                else
                {
                    MessageBox.Show("La patente ya ha sido ingresada, revise el registro");
                }     

            } 
            catch(Exception ex) {
                MessageBox.Show("Error! " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (Registro.Delete(txtPatente.Text)){
                MessageBox.Show("Automovil de patente "+txtPatente.Text+" ELIMINADO");
                dgAutos.Items.Refresh();
            }
            else
            {
                MessageBox.Show("La patente "+ txtPatente.Text+ " no se encontró");
            }
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (Registro.Delete(txtPatente.Text))
            {
                try
                {
                    Auto a1 = new Auto();
                    a1.Marca = txtMarca.Text;
                    a1.Modelo = txtModelo.Text;
                    a1.Patente = txtPatente.Text;
                    a1.Precio = int.Parse(txtPrecio.Text);
                    a1.Year = int.Parse(cmbYear.Text);
                    a1.Tipo = cmbTipo.Text;

                    if (a1.Validar())
                    {
                        if (Registro.Create(a1))
                        {
                            dgAutos.ItemsSource = Registro.ReadAll();
                            dgAutos.Items.Refresh();
                            MessageBox.Show("Automovil editado con éxito!");
                        }
                        else
                        {
                            MessageBox.Show("La patente ya ha sido ingresada, revise el registro");
                        }

                    }
                    else
                    {
                        MessageBox.Show("La patente ya ha sido ingresada, revise el registro");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error! " + ex.Message);
                }
                dgAutos.Items.Refresh();

            }
            else
            {
                MessageBox.Show("La patente " + txtPatente.Text + " no se encontró");
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            Auto a1 = new Auto();
            a1 = Registro.Read(txtPatente.Text); //Retorna el objeto según patente.
            txtPatente.Text = a1.Patente;
            txtMarca.Text = a1.Marca;
            txtModelo.Text = a1.Modelo;
            txtPrecio.Text = a1.Precio.ToString();
            cmbTipo.SelectedValue = a1.Tipo;
            cmbYear.SelectedValue = a1.Year;
        }
    }
}
