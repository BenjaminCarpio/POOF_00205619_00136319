using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SourceCode.Controlador;
using SourceCode.Modelo;

namespace SourceCode
{
    public partial class Menu : Form
    {
        public int userType = Form1.userType;
        public string userID;

        private delegate void MyDelegate();

        private static MyDelegate  refreshDataDelegate = null;
        

        public Menu()
        {
            InitializeComponent();
            userID = Form1.username;
            switch (userType)
            {
                case 1:
                    tabMenu.TabPages.Remove(tabPage1);
                    tabMenu.TabPages.Remove(tabPage2);
                    picUserType.BackgroundImage = Image.FromFile("../../Resources/Admin.jpeg");
                    picJEJE.BackgroundImage = Image.FromFile("../../Resources/SoyAdmin.jpeg");
                    picUserType.BackgroundImageLayout = ImageLayout.Stretch;
                    picJEJE.BackgroundImageLayout = ImageLayout.Stretch;
                    refreshDataDelegate = LoadDataGridInReportesTab;
                    //refreshDataDelegate += LoadFamousDepartment;
                    break;
                case 2:
                    tabMenu.TabPages.Remove(tabPage1);
                    tabMenu.TabPages.Remove(tabPage3);
                    tabMenu.TabPages.Remove(tabPage4);
                    picUserType.BackgroundImage = Image.FromFile("../../Resources/Guard.jpeg");
                    picJEJE.BackgroundImage = Image.FromFile("../../Resources/NoFuiAdmin.jpeg");
                    picJEJE.BackgroundImageLayout = ImageLayout.Stretch;
                    picUserType.BackgroundImageLayout = ImageLayout.Stretch;
                    refreshDataDelegate = LoadComboBoxInGuardTab;
                    break;
                case 3:
                    tabMenu.TabPages.Remove(tabPage2);
                    tabMenu.TabPages.Remove(tabPage3);
                    tabMenu.TabPages.Remove(tabPage4);
                    picUserType.BackgroundImage = Image.FromFile("../../Resources/Employee.jpeg");
                    picJEJE.BackgroundImage = Image.FromFile("../../Resources/NoFuiAdmin.jpeg");
                    picJEJE.BackgroundImageLayout = ImageLayout.Stretch;
                    picUserType.BackgroundImageLayout = ImageLayout.Stretch;
                    refreshDataDelegate = LoadHistory;
                    break;
            }
            refreshDataDelegate?.Invoke();
        }

        #region Load data
        private void  LoadHistory()
        {
            List<Registry> historyList = RegistryDAO.getPersonalHistory(userID);
            dtgUserHistory.DataSource = null;
            dtgUserHistory.DataSource = historyList;
        }
        
        private void LoadDataGridInReportesTab()
        {
            List<Registry> generalList = RegistryDAO.GeneralHistory();
            dtgGeneralEmployee.DataSource = null;
            dtgGeneralEmployee.DataSource = generalList;
            List<Registry> activeEmployee = RegistryDAO.TodayInWork();
            dtgEmployeeInWork.DataSource = null;
            dtgEmployeeInWork.DataSource = activeEmployee;
            List<Top> tempList = TopDAO.Top5Temperatures();
            dtgTopTemps.DataSource = null;
            dtgTopTemps.DataSource = tempList;
            List<User> seniorList = UserDAO.getSeniorList();        //Cargar bien esta lista
            dtg60Plus.DataSource = null;
            dtg60Plus.DataSource = seniorList;
            List<User> employeeList = UserDAO.getUserFullList();
            dtgEmployeeR.DataSource = null;
            dtgEmployeeR.DataSource = employeeList;
        }

        private void LoadComboBoxInGuardTab()
        {
            var userList = UserDAO.getUserFullList();
            cmbRegistUser.ValueMember = "idUser";
            cmbRegistUser.DisplayMember = "idUser";
            cmbRegistUser.DataSource = userList;
        }
        private void LoadFamousDepartment()
        {
            var department = DepartmentDAO.MostPeople();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = department;

        }
        #endregion
        

        private void bttnRefreshUH_Click(object sender, EventArgs e)
        {
            refreshDataDelegate?.Invoke();
        }

        private void btnAddRegistry_Click(object sender, EventArgs e)
        {
            if (txtTemp.Equals(""))
            {
                MessageBox.Show("No se permiten campos vacios", "Error Message", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            else
            {
                string idUser = cmbRegistUser.SelectedValue.ToString();
                bool entrance;
                if (rbtnEntrance.Checked)
                {
                    entrance = true;
                }
                entrance = false;
                string date_time = dateTimePicker1.Value.ToString();
                double temperature = Convert.ToDouble(txtTemp.Text);
                RegistryDAO.AddRegistry(idUser, entrance, date_time, temperature);
            }
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            string carnet = txtCarnet.Text;
            int department = 0;
            if (rbtnAdmin.Checked){
                department = 1;
            }else if (rbtnVigilant.Checked)
            {
                department = 2;
            }else if (rbtnEmployee.Checked)
            {
                department = 3;
            }

            string name = txtName.Text;
            string lastname = txtLastName.Text;
            string dui = txtDui.Text;
            string birthdate = dateTimePicker2.Value.ToShortDateString();
            UserDAO.AddEmployee(carnet,department,name,lastname,dui,birthdate);
            MessageBox.Show("Empleado agregado con exito, clave igual al nombre.");
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            string eliminar = textBox1.Text;
            
            UserDAO.QuitEmpoloyee(eliminar);
            MessageBox.Show("Empleado eliminado con exito");
        }

        private void picExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void picReload_Click(object sender, EventArgs e)
        {
            refreshDataDelegate?.Invoke();
        }
    }
}