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
            if (!test1())
            {
                txtbxOutput.Text += "\r\ntest1 Failed.";

            }
            else
            {
                txtbxOutput.Text += "\r\ntest1 passed.";
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



