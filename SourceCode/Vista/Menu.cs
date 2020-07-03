using System;
using System.Windows.Forms;

namespace SourceCode
{
    public partial class Menu : Form
    {
        public int userType = Form1.userType;  
        public Menu()
        {
            InitializeComponent();
            switch (userType)
            {
                case 1:
                    tabMenu.TabPages.Remove(tabPage1);
                    tabMenu.TabPages.Remove(tabPage2);
                    break;
                case 2:
                    tabMenu.TabPages.Remove(tabPage1);
                    tabMenu.TabPages.Remove(tabPage3);
                    tabMenu.TabPages.Remove(tabPage4);
                    break;
                case 3:
                    tabMenu.TabPages.Remove(tabPage2);
                    tabMenu.TabPages.Remove(tabPage3);
                    tabMenu.TabPages.Remove(tabPage4);
                    break;
            }
            MessageBox.Show(userType.ToString());
        }

        public void LoadHistory()
        {
            
        }

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