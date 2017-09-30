using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace MonkeyBusiness
{

    public enum CHASMSIDE {LEFT=0,RIGHT};
    public enum POSITION { OFF = 0, ONE, TWO, THREE };



    class MonkeyManager
    {
        private List<Monkey> monkeys;
        private List<string> myErrors;

        private void clear()
        {
            monkeys = new List<Monkey>();
            myErrors = new List<string>();
        }
        public MonkeyManager()
        {
            this.clear();
        }

        public List<string> Errors()
        {
            var tmpList = new List<string>();
            foreach (Monkey element in monkeys)
            {
                tmpList.AddRange(element.Errors);
            }
            return tmpList;
        }
        public String ErrorString()
        {
            var sblist = new System.Text.StringBuilder();
            foreach (string s in this.Errors())
            {
                sblist.AppendLine(s);
            }
            return sblist.ToString();
        }

        public List<Monkey> LeftMonkeys()
        {
            return (from m in monkeys
                    where m.Side == CHASMSIDE.LEFT
                    select m).ToList();

        }
        public List<Monkey> RightMonkeys()
        {

            return (from m in monkeys
                    where m.Side == CHASMSIDE.RIGHT
                    select m).ToList();
        }

        public Int32 AddMonkey(CHASMSIDE sideToAddTo)
        {
            monkeys.Add(new Monkey(sideToAddTo));
            switch (sideToAddTo)
            {
                case CHASMSIDE.LEFT:
                    return LeftMonkeys().Count();

                case CHASMSIDE.RIGHT:
                    return RightMonkeys().Count();
                default:
                    myErrors.Add("AddMonkey(...), Unexpected side or return path");
                    return -1;
            }
            myErrors.Add("AddMonkey(...), Unexpected side or return path");
            return -1;
                  
        }

    }

    class Monkey
    {
        public CHASMSIDE Side;
        public POSITION Spot;
        public int CrossingCount;
        public List<string> Errors;

        private void clear()
        {
            this.Side = CHASMSIDE.LEFT;
            this.Spot = POSITION.OFF;
            this.CrossingCount = 0;
            this.Errors = new List<string>();
        }
        public Monkey(CHASMSIDE startingSide) 
        {
            this.clear();
            this.Side = startingSide;
        }

        /// <summary>
        /// Set next postion, iterate CrossingCount if moving from on rope to off rope.
        /// </summary>
        public void SetNextPosition()
        {
            if (this.PeekNextPosition() == POSITION.OFF)
            {
                //monkey has crossed chasm, so count it.
                CrossingCount += 1;
            }
            this.Spot = this.PeekNextPosition();
        }

        /// <summary>
        /// Peek at what the next position is (dont' actually change the Spot.
        /// </summary>
        /// <returns>The monkeys next spot... valid if they're in position to move.</returns>
        public POSITION PeekNextPosition()
        {
            switch (this.Side)
            {
                case CHASMSIDE.LEFT:
                    //If we're on the left side, we can iterate by one...
                    //unless we're on spot 3 in which case we must go back to 0/off.
                    if (this.Spot == POSITION.THREE)
                    {
                        return POSITION.OFF;
                    }
                    else
                    {
                        return this.Spot + 1;
                    }
                    //break;
                case CHASMSIDE.RIGHT:

                    //if the monkey is on the right side of the chasm, they move from off to 3,
                    //from their they move from 3 to 1.
                    //if they're not yet 
                    if (this.Spot == POSITION.OFF)
                    {
                        return POSITION.THREE;
                    }
                    else
                    {
                        return this.Spot -= 1;
                    }
                    //break;
                default:
                    Errors.Add("PeekNextPostion:Unexpected side of chasm");
                    break;
            }

            Errors.Add("PeekNextPostion:Should not get here, missed a condition!");
            return POSITION.OFF;
        }

    }
}
