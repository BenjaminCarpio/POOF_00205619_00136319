using System.Windows.Forms;

namespace SourceCode
{
    public partial class Menu : Form
    {
        public int userType = Form1.userType;  
        public Menu()
        {
            InitializeComponent();
            MessageBox.Show(userType.ToString());
        }
    }
}