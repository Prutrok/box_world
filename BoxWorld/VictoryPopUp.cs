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
        public VictoryPopUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Level1 level1 = new Level1();
            Level2 level2 = new Level2();
            this.Hide();
            level1.Hide();
            level2.Show();
        }
    }
}
