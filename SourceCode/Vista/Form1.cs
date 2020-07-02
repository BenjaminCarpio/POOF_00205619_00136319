using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SourceCode.Controlador;

namespace SourceCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void picBtnArrow_Click(object sender, EventArgs e)
        {
            string username = txtName.Text;
            string password = txtPassword.Text;
            //codigo xd
            
                if (txtName.Text.Equals("") || txtPassword.Text.Equals(""))
                {
                    MessageBox.Show("No se permiten campos vacios" , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    try
                    {
                        string query = $"SELECT nombre, contrasenia FROM USUARIO WHERE username = '{txtName.Text}' AND password = '{txtPassword.Text}'";
                        var cmd = ConnectionDB.ExecuteQuery(query);


                        DataTableReader dr;
                        dr = cmd.CreateDataReader();
                        string user;
                        bool adminUser;
                    
                        if (dr.Read())
                        {
                            //Obtener datos para ver si puede iniciar sesion xd

                            //Poner tipo de usuario
                            MessageBox.Show("Bienvenido" + "vigilante/blablabla llenar eso XD" + $"{txtName.Text}");
                            
                            Menu m = new Menu();
                            m.Show();
                            this.Hide();
                        } else 
                            MessageBox.Show("Credenciales erroneas");
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Ha ocurrido un error");
                    }
                }
            
            
            
           
            
        }
    }
}