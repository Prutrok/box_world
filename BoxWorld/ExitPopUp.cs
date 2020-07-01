using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoxWorld
{
    public partial class ExitPopUp : Form
    {

        private IFormatter formatter = new BinaryFormatter();
        public bool isExitCalledFromHere = false;

        internal FormState FormState { get; set; } = new FormState();

        public ExitPopUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isExitCalledFromHere = true;

            if (FormState != null)
            {
                Stream stream = new FileStream("Save.bin",
                                               FileMode.Create,
                                               FileAccess.Write,
                                               FileShare.None);

                formatter.Serialize(stream, FormState);
                stream.Close();
            }

            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
