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
    public partial class Form1 : Form
    {
        private IFormatter formatter = new BinaryFormatter();

        public Form1()
        {
            InitializeComponent();
            
            if (File.Exists("Save.bin"))
            {
                button2.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Level1 level1 = new Level1();
            this.Hide();

            if (File.Exists("Save.bin"))
            {
                File.Delete("Save.bin");
            }

            level1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists("Save.bin"))
            {
                Stream stream = new FileStream("Save.bin",
                                               FileMode.Open,
                                               FileAccess.Read,
                                               FileShare.Read);

                FormState formState  = (FormState) formatter.Deserialize(stream);
                stream.Close();

                switch(formState.level)
                {
                    case "Level1":
                        Level1 level1 = new Level1();

                        level1.InitState(formState);
                        level1.Show();
                        break;

                    case "Level2":
                        Level2 level2 = new Level2();

                        level2.InitState(formState);
                        level2.Show();
                        break;

                    case "Level3":
                        Level3 level3 = new Level3();

                        level3.InitState(formState);
                        level3.Show();
                        break;

                    case "Level4":
                        Level4 level4 = new Level4();

                        level4.InitState(formState);
                        level4.Show();
                        break;

                    case "Level5":
                        Level5 level5 = new Level5();

                        level5.InitState(formState);
                        level5.Show();
                        break;
                    default:
                        Level1 levelOne = new Level1();

                        levelOne.Show();
                        break;
                   
                }
                
                this.Hide();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Helper.popUp.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Helper.popUp.isExitCalledFromHere)
            {
                e.Cancel = true;
                Helper.popUp.exitLabel.Text = "Are you sure you want to exit BoxWorld?";
                Helper.popUp.ShowDialog();
            }
        }
    }
}
