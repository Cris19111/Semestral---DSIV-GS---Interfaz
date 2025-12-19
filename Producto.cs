using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semestral___DSIV_GS
{
    public partial class Producto : Form
    {
        public Producto()
        {
            InitializeComponent();
        }

        private void Volver_Click(object sender, EventArgs e)
        {
           Home ventan = new Home();    
           ventan.Show();
            this.Close();
        }
    }
}
