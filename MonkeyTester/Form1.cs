using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MonkeyTester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (!testA())
            {
                txtbxOutput.Text += "\r\ntestA Failed.";

            }
            else
            {
                txtbxOutput.Text += "\r\ntestA passed.";
            }


            if (!test1())
            {
                txtbxOutput.Text += "\r\ntest1 Failed.";

            }
            else
            {
                txtbxOutput.Text += "\r\ntest1 passed.";
            }
        }

        /// <summary>
        /// We need to start more elementa. Move a single monkey accross the rope from left to right...
        /// </summary>
        /// <returns></returns>
        private bool testA()
        {
            var m = new MonkeyBusiness.Monkey(MonkeyBusiness.CHASMSIDE.LEFT);
            for (int i =0; i<10; i++)
            {

                txtbxOutput.Text += "\r\n[" + Convert.ToString(i) + "] Moving Monkey from " + Enum.GetName(m.Spot.GetType(), m.Spot) + " to " + Enum.GetName(m.PeekNextPosition().GetType(), m.PeekNextPosition());
                m.SetNextPosition();
            }
            if (m.Errors.Count == 0)
            {
                return true;
            }
            else
            {
                txtbxOutput.Text += string.Join("\r\n",m.Errors.ToArray());
                return false;
            }
        }

        //Add some monkeys to the left side, and move them accross.
        private bool test1()
        {
            
            var mm = new MonkeyBusiness.MonkeyManager();
            mm.AddMonkey(MonkeyBusiness.CHASMSIDE.LEFT);
            mm.AddMonkey(MonkeyBusiness.CHASMSIDE.LEFT);
            mm.AddMonkey(MonkeyBusiness.CHASMSIDE.LEFT);
            txtbxOutput.Text += "\r\n" + mm.ErrorString();
            if (mm.ErrorString() != "")
            {
                return false;
            } else {
                return true;
            }
        }
    }
}



