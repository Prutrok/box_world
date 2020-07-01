using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BoxWorld
{
    [Serializable]
    public class FormState
    {
        public string level = "";

        public PictureBoxLocation wizardLocation = new PictureBoxLocation();
        public PictureBoxLocation[] boxes = new PictureBoxLocation[0];

        public string[] scoredRedOrbNames = new string[0];

        public FormState()
        {
            
        }
    }
}