using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MonkeyCrossing2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private MonkeyBusiness.MonkeyManager mm;

        private void Form1_Load(object sender, EventArgs e)
        {
            mm = new MonkeyBusiness.MonkeyManager();
            for (int i=0; i < 10; i++)
            {
                mm.AddMonkey(MonkeyBusiness.CHASMSIDE.LEFT);
                mm.AddMonkey(MonkeyBusiness.CHASMSIDE.RIGHT);
            }

            UpdateLeftLabel();
            UpdateRightLabel();
        }

        private void UpdateLeftLabel()
        {
            lblLeft.Text = string.Format("Monkeys:{0}", mm.LeftMonkeys().Count());
        }
        private void UpdateRightLabel()
        {
            lblRight.Text = string.Format("Monkeys:{0}", mm.RightMonkeys().Count());
        }
    }
}
