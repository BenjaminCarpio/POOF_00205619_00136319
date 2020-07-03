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
        public static int userType;
        public static string username;
        public Form1()
        {
            InitializeComponent();
        }

        private void picBtnArrow_Click(object sender, EventArgs e)
        {
            username = txtId.Text;
            string password = txtPassword.Text;
            
            //codigo xd
            
                if (txtId.Text.Equals("") || txtPassword.Text.Equals(""))
                {
                    MessageBox.Show("No se permiten campos vacios" , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    try
                    {
                        string query = $"SELECT nombre, contrasenia, idDepartamento FROM USUARIO WHERE idUsuario = '{txtId.Text}' AND contrasenia = '{txtPassword.Text}'";
                        var cmd = ConnectionDB.ExecuteQuery(query);


                        DataTableReader dr;
                        dr = cmd.CreateDataReader();
                        string user, type ="";
                        bool adminUser = false, vigilant = false, employee = false;


                        if (dr.Read())
                        {
                            user = dr.GetString(0);
                            userType = dr.GetInt32(2);
                            switch (userType)
                            {
                                case 1:
                                    adminUser = true;
                                    type = "Admin";
                                    break;
                                case 2:
                                    vigilant = true;
                                    type = "Vigilante";
                                    break;
                                case 3:
                                    employee = true;
                                    type = "Empleado";
                                    break;
                            }
                            //Poner tipo de usuario
                            MessageBox.Show("Bienvenido " + type + $" {user}");
                            this.Hide();
                            Menu m = new Menu();
                            m.Show();
                        } else 
                            MessageBox.Show("Credenciales erroneas");
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Ha ocurrido un error");
                    }
                }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        { 
            if(e.KeyCode == Keys.Enter)
                picBtnArrow_Click((object)sender, (EventArgs)e);
        }
    }
}