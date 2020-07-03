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

        private delegate void MyDelegate();

        private static MyDelegate LoadDataGrid;

        public Menu()
        {
            InitializeComponent();
            LoadDataGrid = null;
            switch (userType)
            {
                case 1:
                    tabMenu.TabPages.Remove(tabPage1);
                    tabMenu.TabPages.Remove(tabPage2);
                    picUserType.BackgroundImage = Image.FromFile("../../Resources/Admin.jpeg");
                    picUserType.BackgroundImageLayout = ImageLayout.Stretch;
                    LoadDataGrid = LoadDataGridInReportesTab;
                    break;
                case 2:
                    tabMenu.TabPages.Remove(tabPage1);
                    tabMenu.TabPages.Remove(tabPage3);
                    tabMenu.TabPages.Remove(tabPage4);
                    picUserType.BackgroundImage = Image.FromFile("../../Resources/Guard.jpeg");
                    picUserType.BackgroundImageLayout = ImageLayout.Stretch;
                    LoadDataGrid = null;
                    break;
                case 3:
                    tabMenu.TabPages.Remove(tabPage2);
                    tabMenu.TabPages.Remove(tabPage3);
                    tabMenu.TabPages.Remove(tabPage4);
                    picUserType.BackgroundImage = Image.FromFile("../../Resources/Employee.jpeg");
                    picUserType.BackgroundImageLayout = ImageLayout.Stretch;
                    LoadDataGrid = LoadHistory;
                    break;
            }

            LoadDataGrid?.Invoke();
        }

        #region Load datagrid
        public  void  LoadHistory()
        {
            List<Registry> historyList = RegistryDAO.GeneralHistory();
            dtgUserHistory.DataSource = null;
            dtgUserHistory.DataSource = historyList;
        }

        public void LoadEmployeeDeleteRegistry()
        {
            List<User> deleteEmployee = UserDAO.getUserFullList();
            dtgUserHistory.DataSource = null;
            dtgUserHistory.DataSource = deleteEmployee;
        }
        public void LoadDataGridInReportesTab()
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
            
        }
        #endregion
        

        private void bttnRefreshUH_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void btnAddRegistry_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void picExit_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void picReload_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}