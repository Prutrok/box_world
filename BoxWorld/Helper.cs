using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoxWorld
{
    class Helper
    {
        public static ExitPopUp popUp = new ExitPopUp();

        public static PictureBoxLocation findPictureBoxLocationByName(string name, PictureBoxLocation[] pictureBoxLocations)
        {
            for (int i = 0; i < pictureBoxLocations.Length; i++)
            {
                if (pictureBoxLocations[i].pictureBoxName == name)
                {
                    return pictureBoxLocations[i];
                }
            }

            return null;
        }

        public static void updatePictureBoxLocation(List<PictureBox> pictureBoxes, PictureBoxLocation[] pictureBoxLocations)
        {
            for (int i = 0; i < pictureBoxes.Count; i++)
            {
                PictureBox pictureBox = pictureBoxes.ElementAt(i);

                PictureBoxLocation pictureBoxLocation = findPictureBoxLocationByName(pictureBox.Name, pictureBoxLocations);

                if (pictureBoxLocation != null)
                {
                    pictureBox.Location = new Point(pictureBoxLocation.X, pictureBoxLocation.Y);
                }
            }
        }

        public static List<PictureBox> extractPictureBoxesFromNames(string[] names, List<PictureBox> pictureBoxes)
        {
            List<PictureBox> extractedPictureBoxes = new List<PictureBox>();

            for (int i = 0; i < names.Length; i++)
            {
                for (int j = 0; j < pictureBoxes.Count; j++)
                {
                    PictureBox pictureBox = pictureBoxes.ElementAt(j);

                    if (pictureBox.Name == names[i])
                    {
                        extractedPictureBoxes.Add(pictureBox);
                        break;
                    }
                }
            }

            return extractedPictureBoxes;
        }

        public static PictureBoxLocation[] mapToPictureBoxLocation(List<PictureBox> pictureBoxes)
        {
            PictureBoxLocation[] pictureBoxLocations = new PictureBoxLocation[pictureBoxes.Count];

            for (int i = 0; i < pictureBoxes.Count; i++)
            {
                PictureBox pictureBox = pictureBoxes.ElementAt(i);
                PictureBoxLocation pictureBoxLocation = new PictureBoxLocation();

                pictureBoxLocation.pictureBoxName = pictureBox.Name;
                pictureBoxLocation.X = pictureBox.Location.X;
                pictureBoxLocation.Y = pictureBox.Location.Y;

                pictureBoxLocations[i] = pictureBoxLocation;
            }

            return pictureBoxLocations;
        }

        public static string[] extractNamesFromPictureBoxes(List<PictureBox> pictureBoxes)
        {
            string[] pictureBoxNames = new string[pictureBoxes.Count];

            for (int i = 0; i < pictureBoxes.Count; i++)
            {
                pictureBoxNames[i] = pictureBoxes.ElementAt(i).Name;
            }

            return pictureBoxNames;
         }

        public static bool willHitPictureBox(List<PictureBox> pictureBoxes, Point point)
        {
            for (int i = 0; i < pictureBoxes.Count; i++)
            {
                PictureBox pictureBox = pictureBoxes.ElementAt(i);
                Point pictureBoxLocation = pictureBox.Location;

                if (point.X == pictureBoxLocation.X && point.Y == pictureBoxLocation.Y)
                {
                    return true;
                }
            }

            return false;
        }

        public static PictureBox getPictureBoxByLocation(List<PictureBox> pictureBoxes, Point point)
        {
            for (int i = 0; i < pictureBoxes.Count; i++)
            {
                PictureBox pictureBox = pictureBoxes.ElementAt(i);
                Point pictureBoxLocation = pictureBox.Location;

                if (point.X == pictureBoxLocation.X && point.Y == pictureBoxLocation.Y)
                {
                    return pictureBox;
                }
            }

            return null;
        }

        public static Bitmap getBitmapAssetByName(string assetName)
        {
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream(assetName);

            return new Bitmap(myStream);
        }

        public static void wizardMovement(Moving moving, PictureBox wizard, List<PictureBox> bricks, List<PictureBox> boxes, List<PictureBox> redOrbs, List<PictureBox> scoredRedOrbs)
        {
            switch(moving)
            {
                case Moving.UP:
                    moveWizard(0, -39, wizard, bricks, boxes, redOrbs, scoredRedOrbs);
                    break;
                case Moving.DOWN:
                    moveWizard(0, 39, wizard, bricks, boxes, redOrbs, scoredRedOrbs);
                    break;
                case Moving.RIGHT:
                    moveWizard(36, 0, wizard, bricks, boxes, redOrbs, scoredRedOrbs);
                    break;
                case Moving.LEFT:
                    moveWizard(-36, 0, wizard, bricks, boxes, redOrbs, scoredRedOrbs);
                    break;
                default:
                    throw new InvalidOperationException("Enum " + moving + " is not supprted by this method");
            }
        }

        private static void moveWizard(int moveX, int moveY, PictureBox wizard, List<PictureBox> bricks, List<PictureBox> boxes, List<PictureBox> redOrbs, List<PictureBox> scoredRedOrbs)
        {
            Point shouldMoveHere = new Point(wizard.Location.X + moveX, wizard.Location.Y + moveY);

            bool hitBrick = willHitPictureBox(bricks, shouldMoveHere);

            if (!hitBrick)
            {
                bool hitBox = willHitPictureBox(boxes, shouldMoveHere);

                if (hitBox)
                {
                    PictureBox box = Helper.getPictureBoxByLocation(boxes, shouldMoveHere);

                    if (box != null)
                    {
                        Point boxLocation = box.Location;
                        Point shouldBoxMoveHere = new Point(boxLocation.X + moveX, boxLocation.Y + moveY);

                        bool boxHitsBrick = Helper.willHitPictureBox(bricks, shouldBoxMoveHere);
                        bool boxHitsBox = Helper.willHitPictureBox(boxes, shouldBoxMoveHere);

                        if (!boxHitsBrick && !boxHitsBox)
                        {
                            bool hitRedOrb = Helper.willHitPictureBox(redOrbs, shouldBoxMoveHere);

                            if (hitRedOrb)
                            {
                                PictureBox redOrb = Helper.getPictureBoxByLocation(redOrbs, shouldBoxMoveHere);
                                scoredRedOrbs.Add(redOrb);

                                box.Image = Helper.getBitmapAssetByName("BoxWorld.Assets.crate_green.jpg");
                            }
                            
                            
                                bool willExitRedOrb = Helper.willHitPictureBox(redOrbs, boxLocation);

                                if (willExitRedOrb)
                                {

                                    PictureBox redOrb = Helper.getPictureBoxByLocation(redOrbs, boxLocation);

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
                                        scoredRedOrbs.RemoveAt(index);

                                        if (!hitRedOrb)
                                        {
                                            box.Image = Helper.getBitmapAssetByName("BoxWorld.Assets.wooden_crate2.png");
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
    }
}
