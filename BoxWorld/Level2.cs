using System.Collections.Generic;
using System.Windows.Forms;

namespace BoxWorld
{
    public partial class Level2 : Form
    {
        List<PictureBox> boxes = new List<PictureBox>();
        List<PictureBox> bricks = new List<PictureBox>();
        List<PictureBox> redOrbs = new List<PictureBox>();

        int points = 0;
        VictoryPopUp victoryPopUp;
        List<PictureBox> scoredRedOrbs = new List<PictureBox>();

        public Level2()
        {
            InitializeComponent();

            // Init redOrbs list values
            redOrbs.Add(redOrb1);
            redOrbs.Add(redOrb2);
            redOrbs.Add(redOrb3);

            // Init boxes list values
            boxes.Add(box1);
            boxes.Add(box2);
            boxes.Add(box3);

            // Init bricks list values
            bricks.Add(brick1);
            bricks.Add(brick2);
            bricks.Add(brick3);
            bricks.Add(brick4);
            bricks.Add(brick5);
            bricks.Add(brick6);
            bricks.Add(brick7);
            bricks.Add(brick8);
            bricks.Add(brick9);
            bricks.Add(brick10);
            bricks.Add(brick11);
            bricks.Add(brick12);
            bricks.Add(brick13);
            bricks.Add(brick14);
            bricks.Add(brick15);
            bricks.Add(brick16);
            bricks.Add(brick17);
            bricks.Add(brick18);
            bricks.Add(brick19);
            bricks.Add(brick20);
            bricks.Add(brick21);
            bricks.Add(brick22);
            bricks.Add(brick23);
            bricks.Add(brick24);
            bricks.Add(brick25);
            bricks.Add(brick26);
            bricks.Add(brick27);
            bricks.Add(brick28);
            bricks.Add(brick29);
            bricks.Add(brick30);
            bricks.Add(brick31);
            bricks.Add(brick32);
            bricks.Add(brick33);
            bricks.Add(brick34);
            bricks.Add(brick35);
            bricks.Add(brick36);
            bricks.Add(brick37);
            bricks.Add(brick38);
            bricks.Add(brick39);

            victoryPopUp = new VictoryPopUp(this, new Level3());
        }
        
        private void Level2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'W' || e.KeyChar == 'w')
            {
                Helper.wizardMovement(Moving.UP, wizard, bricks, boxes, redOrbs, scoredRedOrbs);
            }
            if (e.KeyChar == 'S' || e.KeyChar == 's')
            {
                Helper.wizardMovement(Moving.DOWN, wizard, bricks, boxes, redOrbs, scoredRedOrbs);
            }
            if (e.KeyChar == 'A' || e.KeyChar == 'a')
            {
                Helper.wizardMovement(Moving.LEFT, wizard, bricks, boxes, redOrbs, scoredRedOrbs);
            }
            if (e.KeyChar == 'D' || e.KeyChar == 'd')
            {
                Helper.wizardMovement(Moving.RIGHT, wizard, bricks, boxes, redOrbs, scoredRedOrbs);
            }

            points = scoredRedOrbs.Count;
        }

    }
}
