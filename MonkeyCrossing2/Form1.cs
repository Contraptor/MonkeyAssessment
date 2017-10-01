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

        private void btnAddLeft_Click(object sender, EventArgs e)
        {
            mm.AddMonkey(MonkeyBusiness.CHASMSIDE.LEFT);
            UpdateLeftLabel();
        }

        private void btnAddRight_Click(object sender, EventArgs e)
        {
            mm.AddMonkey(MonkeyBusiness.CHASMSIDE.RIGHT);
            UpdateRightLabel();
        }

        private void btnMoveMonkeys_Click(object sender, EventArgs e)
        {
            mm.MoveMonkeys(1);
            txt1.Text = "";
            txt2.Text = "";
            txt3.Text = "";
            for (int i=0; i< 4; i++)
            {
                switch (mm.CurrentDirectionQueue()[i].Spot)
                {
                    case MonkeyBusiness.POSITION.ONE:
                        txt1.Text = "☺";
                            break;
                    case MonkeyBusiness.POSITION.TWO:
                            txt2.Text = "☺";
                            break;
                    case MonkeyBusiness.POSITION.THREE:
                            txt3.Text = "☺";
                            break;
                    //default:
                        //do nothing.
                           // break;
                }
                UpdateLeftLabel();
                UpdateRightLabel();
            }
        }
    }
}
