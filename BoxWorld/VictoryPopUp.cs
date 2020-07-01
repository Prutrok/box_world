using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoxWorld
{
    public partial class VictoryPopUp : Form
    {

        Form calledBy;
        Form nextLevel;

        public VictoryPopUp(Form calledBy, Form nextLevel)
        {
            InitializeComponent();

            this.calledBy = calledBy;
            this.nextLevel = nextLevel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            calledBy.Close();
            nextLevel.Show();
            this.Close();
        }
    }
}
