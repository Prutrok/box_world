using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoxWorld
{
    public partial class Level1 : Form
    {
        
        List<PictureBox> boxes = new List<PictureBox>();
        List<PictureBox> bricks = new List<PictureBox>();
        List<PictureBox> redOrbs = new List<PictureBox>();

        int points = 0;
        VictoryPopUp victoryPopUp = new VictoryPopUp();
        List<PictureBox> scoredRedOrbs = new List<PictureBox>();

        public Level1()
        {
            InitializeComponent();
            redOrbs.Add(redOrb1);
            redOrbs.Add(redOrb2);
            redOrbs.Add(redOrb3);
            redOrbs.Add(redOrb4);
            boxes.Add(box1);
            boxes.Add(box2);
            boxes.Add(box3);
            boxes.Add(box4);
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
        }

        private bool willHitBrick(Point point)
        {
            for(int i = 0; i < bricks.Count; i++)
            {
                PictureBox brick = bricks.ElementAt(i);
                Point brickLocation = brick.Location;

                if (point.X == brickLocation.X && point.Y == brickLocation.Y)
                {
                    return true;
                }
            }

            return false;
        }

        private PictureBox getBoxByPoint(Point point)
        {
            for (int i = 0; i < boxes.Count; i++)
            {
                PictureBox box = boxes.ElementAt(i);
                Point boxLocation = box.Location;

                if (point.X == boxLocation.X && point.Y == boxLocation.Y)
                {
                    return box;
                }
            }

            return null;
        }

        private bool willHitBox(Point point)
        {
            for (int i = 0; i < boxes.Count; i++)
            {
                PictureBox box = boxes.ElementAt(i);
                Point boxLocation = box.Location;

                if (point.X == boxLocation.X && point.Y == boxLocation.Y)
                {
                    return true;
                }
            }

            return false;
        }

        private bool willHitRedOrb(Point point)
        {
            for (int i = 0; i < redOrbs.Count; i++)
            {
                PictureBox redOrb = redOrbs.ElementAt(i);
                Point redOrbLocation = redOrb.Location;

                if (point.X == redOrbLocation.X && point.Y == redOrbLocation.Y)
                {
                    return true;
                }
            }

            return false;
        }

        private PictureBox getRedOrbByPoint(Point point)
        {
            for (int i = 0; i < redOrbs.Count; i++)
            {
                PictureBox redOrb = redOrbs.ElementAt(i);
                Point redOrbLocation = redOrb.Location;

                if (point.X == redOrbLocation.X && point.Y == redOrbLocation.Y)
                {
                    return redOrb;
                }
            }

            return null;
        }

        private void Level1_KeyPress(object sender, KeyPressEventArgs e)
        {                        
           if (e.KeyChar == 'W' || e.KeyChar == 'w')
            {
                Point shouldMoveHere = new Point(wizard.Location.X, wizard.Location.Y - 39);

                bool hitBrick = willHitBrick(shouldMoveHere);

                if (!hitBrick)
                {
                    bool hitBox = willHitBox(shouldMoveHere);

                    if(hitBox)
                    {
                        PictureBox box = getBoxByPoint(shouldMoveHere);

                        if (box != null)
                        {
                            Point boxLocation = box.Location;
                            Point shouldBoxMoveHere = new Point(boxLocation.X, boxLocation.Y - 39);

                            bool boxHitsBrick = willHitBrick(shouldBoxMoveHere);
                            bool boxHitsBox = willHitBox(shouldBoxMoveHere);
                            
                            if (!boxHitsBrick && !boxHitsBox)
                            {
                                bool hitRedOrb = willHitRedOrb(shouldBoxMoveHere);

                                if (hitRedOrb)
                                {
                                    PictureBox redOrb = getRedOrbByPoint(shouldBoxMoveHere);
                                    points++;
                                    scoredRedOrbs.Add(redOrb);

                                    Assembly myAssembly = Assembly.GetExecutingAssembly();
                                    Stream myStream = myAssembly.GetManifestResourceStream("BoxWorld.Assets.crate_green.jpg");
                                    Bitmap bmp = new Bitmap(myStream);

                                    box.Image = bmp;
                                } else
                                {
                                    bool willExitRedOrb = willHitRedOrb(boxLocation);

                                    if (willExitRedOrb)
                                    {

                                        PictureBox redOrb = getRedOrbByPoint(boxLocation);

                                        int index = -1;
                                        for(int i = 0; i < scoredRedOrbs.Count; i++)
                                        {
                                            PictureBox currentRedOrb = scoredRedOrbs.ElementAt(i);

                                            if (redOrb.Name == currentRedOrb.Name)
                                            {
                                                index = i;
                                                break;
                                            }
                                        }

                                        if (index != -1)
                                        {
                                            points--;
                                            scoredRedOrbs.RemoveAt(index);

                                            Assembly myAssembly = Assembly.GetExecutingAssembly();
                                            Stream myStream = myAssembly.GetManifestResourceStream("BoxWorld.Assets.wooden_crate2.png");
                                            Bitmap bmp = new Bitmap(myStream);

                                            box.Image = bmp;
                                        }
                                    }
                                }

                                wizard.Location = shouldMoveHere;
                                box.Location = shouldBoxMoveHere;
                            }
                        } else
                        {
                            wizard.Location = shouldMoveHere;
                        }
                    } else
                    {
                        wizard.Location = shouldMoveHere;
                    }
                }
            }
           if (e.KeyChar == 'S' || e.KeyChar == 's')
            {
                Point shouldMoveHere = new Point(wizard.Location.X, wizard.Location.Y + 39);

                bool hitBrick = willHitBrick(shouldMoveHere);

                if (!hitBrick)
                {
                    bool hitBox = willHitBox(shouldMoveHere);

                    if (hitBox)
                    {
                        PictureBox box = getBoxByPoint(shouldMoveHere);

                        if (box != null)
                        {
                            Point boxLocation = box.Location;
                            Point shouldBoxMoveHere = new Point(boxLocation.X, boxLocation.Y + 39);

                            bool boxHitsBrick = willHitBrick(shouldBoxMoveHere);
                            bool boxHitsBox = willHitBox(shouldBoxMoveHere);

                            if (!boxHitsBrick && !boxHitsBox)
                            {
                                bool hitRedOrb = willHitRedOrb(shouldBoxMoveHere);

                                if (hitRedOrb)
                                {
                                    PictureBox redOrb = getRedOrbByPoint(shouldBoxMoveHere);
                                    points++;
                                    scoredRedOrbs.Add(redOrb);

                                    Assembly myAssembly = Assembly.GetExecutingAssembly();
                                    Stream myStream = myAssembly.GetManifestResourceStream("BoxWorld.Assets.crate_green.jpg");
                                    Bitmap bmp = new Bitmap(myStream);

                                    box.Image = bmp;
                                }
                                else
                                {
                                    bool willExitRedOrb = willHitRedOrb(boxLocation);

                                    if (willExitRedOrb)
                                    {

                                        PictureBox redOrb = getRedOrbByPoint(boxLocation);

                                        int index = -1;
                                        for (int i = 0; i < scoredRedOrbs.Count; i++)
                                        {
                                            PictureBox currentRedOrb = scoredRedOrbs.ElementAt(i);

                                            if (redOrb.Name == currentRedOrb.Name)
                                            {
                                                index = i;
                                                break;
                                            }
                                        }

                                        if (index != -1)
                                        {
                                            points--;
                                            scoredRedOrbs.RemoveAt(index);

                                            Assembly myAssembly = Assembly.GetExecutingAssembly();
                                            Stream myStream = myAssembly.GetManifestResourceStream("BoxWorld.Assets.wooden_crate2.png");
                                            Bitmap bmp = new Bitmap(myStream);

                                            box.Image = bmp;
                                        }
                                    }
                                }

                                wizard.Location = shouldMoveHere;
                                box.Location = shouldBoxMoveHere;
                            }
                        }
                        else
                        {
                            wizard.Location = shouldMoveHere;
                        }
                    }
                    else
                    {
                        wizard.Location = shouldMoveHere;
                    }
                }
            }
           if (e.KeyChar == 'A' || e.KeyChar == 'a')
            {
                Point shouldMoveHere = new Point(wizard.Location.X - 36, wizard.Location.Y);

                bool hitBrick = willHitBrick(shouldMoveHere);

                if (!hitBrick)
                {
                    bool hitBox = willHitBox(shouldMoveHere);

                    if (hitBox)
                    {
                        PictureBox box = getBoxByPoint(shouldMoveHere);

                        if (box != null)
                        {
                            Point boxLocation = box.Location;
                            Point shouldBoxMoveHere = new Point(boxLocation.X - 36, boxLocation.Y);

                            bool boxHitsBrick = willHitBrick(shouldBoxMoveHere);
                            bool boxHitsBox = willHitBox(shouldBoxMoveHere);

                            if (!boxHitsBrick && !boxHitsBox)
                            {
                                bool hitRedOrb = willHitRedOrb(shouldBoxMoveHere);

                                if (hitRedOrb)
                                {
                                    PictureBox redOrb = getRedOrbByPoint(shouldBoxMoveHere);
                                    points++;
                                    scoredRedOrbs.Add(redOrb);

                                    Assembly myAssembly = Assembly.GetExecutingAssembly();
                                    Stream myStream = myAssembly.GetManifestResourceStream("BoxWorld.Assets.crate_green.jpg");
                                    Bitmap bmp = new Bitmap(myStream);

                                    box.Image = bmp;
                                }
                                else
                                {
                                    bool willExitRedOrb = willHitRedOrb(boxLocation);

                                    if (willExitRedOrb)
                                    {

                                        PictureBox redOrb = getRedOrbByPoint(boxLocation);

                                        int index = -1;
                                        for (int i = 0; i < scoredRedOrbs.Count; i++)
                                        {
                                            PictureBox currentRedOrb = scoredRedOrbs.ElementAt(i);

                                            if (redOrb.Name == currentRedOrb.Name)
                                            {
                                                index = i;
                                                break;
                                            }
                                        }

                                        if (index != -1)
                                        {
                                            points--;
                                            scoredRedOrbs.RemoveAt(index);

                                            Assembly myAssembly = Assembly.GetExecutingAssembly();
                                            Stream myStream = myAssembly.GetManifestResourceStream("BoxWorld.Assets.wooden_crate2.png");
                                            Bitmap bmp = new Bitmap(myStream);

                                            box.Image = bmp;
                                        }
                                    }
                                }

                                wizard.Location = shouldMoveHere;
                                box.Location = shouldBoxMoveHere;
                            }
                        }
                        else
                        {
                            wizard.Location = shouldMoveHere;
                        }
                    }
                    else
                    {
                        wizard.Location = shouldMoveHere;
                    }
                }
            }
           if (e.KeyChar == 'D' || e.KeyChar == 'd')
            {
                Point shouldMoveHere = new Point(wizard.Location.X + 36, wizard.Location.Y);

                bool hitBrick = willHitBrick(shouldMoveHere);

                if (!hitBrick)
                {
                    bool hitBox = willHitBox(shouldMoveHere);

                    if (hitBox)
                    {
                        PictureBox box = getBoxByPoint(shouldMoveHere);

                        if (box != null)
                        {
                            Point boxLocation = box.Location;
                            Point shouldBoxMoveHere = new Point(boxLocation.X + 36, boxLocation.Y);

                            bool boxHitsBrick = willHitBrick(shouldBoxMoveHere);
                            bool boxHitsBox = willHitBox(shouldBoxMoveHere);

                            if (!boxHitsBrick && !boxHitsBox)
                            {
                                bool hitRedOrb = willHitRedOrb(shouldBoxMoveHere);

                                if (hitRedOrb)
                                {
                                    PictureBox redOrb = getRedOrbByPoint(shouldBoxMoveHere);
                                    points++;
                                    scoredRedOrbs.Add(redOrb);

                                    Assembly myAssembly = Assembly.GetExecutingAssembly();
                                    Stream myStream = myAssembly.GetManifestResourceStream("BoxWorld.Assets.crate_green.jpg");
                                    Bitmap bmp = new Bitmap(myStream);

                                    box.Image = bmp;
                                }
                                else
                                {
                                    bool willExitRedOrb = willHitRedOrb(boxLocation);

                                    if (willExitRedOrb)
                                    {

                                        PictureBox redOrb = getRedOrbByPoint(boxLocation);

                                        int index = -1;
                                        for (int i = 0; i < scoredRedOrbs.Count; i++)
                                        {
                                            PictureBox currentRedOrb = scoredRedOrbs.ElementAt(i);

                                            if (redOrb.Name == currentRedOrb.Name)
                                            {
                                                index = i;
                                                break;
                                            }
                                        }

                                        if (index != -1)
                                        {
                                            points--;
                                            scoredRedOrbs.RemoveAt(index);

                                            Assembly myAssembly = Assembly.GetExecutingAssembly();
                                            Stream myStream = myAssembly.GetManifestResourceStream("BoxWorld.Assets.wooden_crate2.png");
                                            Bitmap bmp = new Bitmap(myStream);

                                            box.Image = bmp;
                                        }
                                    }
                                }

                                wizard.Location = shouldMoveHere;
                                box.Location = shouldBoxMoveHere;
                            }
                        }
                        else
                        {
                            wizard.Location = shouldMoveHere;
                        }
                    }
                    else
                    {
                        wizard.Location = shouldMoveHere;
                    }
                }
            }

            Level1_victoryPopUp(points);
           
        }

        private void Level1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Helper.popUp.isExitCalledFromHere)
            {
                e.Cancel = true;
                Helper.popUp.ShowDialog();
            }
        }

        private void Level1_Load(object sender, EventArgs e)
        {

        }
        
        private void Level1_victoryPopUp (int points)
        {
            if (points == 4)
            {   
                victoryPopUp.Show();
            }
        }
         
    }
}
