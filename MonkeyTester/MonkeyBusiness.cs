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
        private Int32 _ChasmCrossingMax;
        private Int32 _MonkeyCrossingCount;
        private CHASMSIDE currentDirection;  //The direction monkeys are moving. Right means they're moving from left to right.
        private void clear()
        {
            monkeys = new List<Monkey>();
            myErrors = new List<string>();
            this._ChasmCrossingMax = 2;
            this._MonkeyCrossingCount = 0;
        }
        public MonkeyManager()
        {
            this.clear();
            this.currentDirection = CHASMSIDE.RIGHT;
        }


        /// <summary>
        /// Move the specified number of moves. If 0 or fewer moves specified, move until chasm crossings is reached.
        /// </summary>
        /// <param name="howmanymoves"></param>
        /// <returns></returns>
        public Boolean MoveMonkeys(int moves)
        {
            bool movedAMonkey = false;
            //A move contitutes moving a single monkey one space.

            //If the rope is clear, and the moving side can move at max 4 monkeys accross before the
            //other side gets to go.

            //if there are fewer than the max number move that number accross.

            //Once max number has crossed, the other side gets to go.

            //We don't need to iterate through all of the monkeys, at most 4.

            //Int32 move = 0;
            //do
            //{
            //    move += 1;
            //} while (move < moves);
            MonkeyBusiness.Monkey traversedMonkey = null;
            Int32 removeIndex = -1;
            POSITION priorPosition = POSITION.THREE;  //Keep trak of the prior position, if we're ever moving from this position, we can esc.
            POSITION nextPostion = POSITION.THREE; //CurrentDirectionQueue returns different value after we call SetNextPostion in some cases.

            Int32 i = 0;
            Console.WriteLine("----Moving MOnkeys----");
            Int32 queueCount = CurrentDirectionQueueCount();
            foreach (Monkey element in CurrentDirectionQueue())
            {

            //for (int i = 0; i < CurrentDirectionQueueCount() - _MonkeyCrossingCount; i++)
            //{
                if ((i > 4) || (i != 0 && (element.Spot == priorPosition)))
                {
                    break;
                }
                priorPosition = element.Spot;
                nextPostion = element.PeekNextPosition();
                element.SetNextPosition();
                movedAMonkey = true;
                //if the monkey has moved off of the rope, move them to the back of the line.
                if (element.Spot == POSITION.OFF)
                {
                    removeIndex = i;
                    traversedMonkey = element;
                    _MonkeyCrossingCount += 1;
                    //if ((_MonkeyCrossingCount == 4) || (i == (CurrentDirectionQueueCount() - _MonkeyCrossingCount)))
                    if (i == (queueCount - _MonkeyCrossingCount) || queueCount == 1)
                    {
                        //max number of monkeys have cross in this direction, so be fair and share.
                        _MonkeyCrossingCount = 0;  //reset to zero

                        //Switch direction.
                        if (this.currentDirection == CHASMSIDE.RIGHT )
                        {
                            this.currentDirection  = CHASMSIDE.LEFT;
                            Console.WriteLine("Switching directions from RIGHT to LEFT.");
                        } else {
                            this.currentDirection  = CHASMSIDE.RIGHT;
                            Console.WriteLine("Switching directions from LEFT to RIGHT.");
                        }
                    }
                }
                i += 1;
            }

            //if (i == (queueCount - _MonkeyCrossingCount))
            //{
            //    //max number of monkeys have cross in this direction, so be fair and share.
            //    _MonkeyCrossingCount = 0;  //reset to zero

            //    //Switch direction.
            //    if (this.currentDirection == CHASMSIDE.RIGHT)
            //    {
            //        this.currentDirection = CHASMSIDE.LEFT;
            //    }
            //    else
            //    {
            //        this.currentDirection = CHASMSIDE.RIGHT;
            //    }
            //}

            if (traversedMonkey != null)
            {

                this.monkeys.Remove(this.monkeys.First());
                this.monkeys.Add(traversedMonkey);
            }

            return movedAMonkey; 
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


        //public Monkey MovingMonkeys(POSITION here)
        //{
        //    return (from m in monkeys
        //            where m.Spot == here
        //            select m).First()<Monkey>;

        //}

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

        public Int32 CurrentDirectionQueueCount()
        {
            switch (this.currentDirection)
            {
                case CHASMSIDE.RIGHT:
                    return LeftMonkeys().Count;
                case CHASMSIDE.LEFT:
                    return RightMonkeys().Count;
            }
            return -1;
        }
        public List<Monkey> CurrentDirectionQueue()
        {
            switch (this.currentDirection)
            {
                case CHASMSIDE.RIGHT:
                    return LeftMonkeys();
                default:
                    return RightMonkeys();
            }

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
                    myErrors.Add("AddMonkey(...), Unexpected side or return path.");
                    return -1;
            }
            myErrors.Add("AddMonkey(...), Unexpected side or return path..");
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
            POSITION nextPos = this.PeekNextPosition();
            if (nextPos == POSITION.OFF)
            {
                //monkey has crossed chasm, so count it.
                CrossingCount += 1;

                //Move the monkey to the other side of the chasm.
                switch (this.Side)
                {
                    case CHASMSIDE.LEFT:
                        Console.WriteLine("Moving monkey from rope to Right side.");
                        this.Side = CHASMSIDE.RIGHT;
                        break;
                    case CHASMSIDE.RIGHT:
                        Console.WriteLine("Moving monkey from rope to Left side.");
                        this.Side = CHASMSIDE.LEFT;
                        break;
                    default:
                        Errors.Add("SetNextPosition: unexpected side of chasm.");
                        break;
                }
            }
            Console.WriteLine("Moving monkey from " + this.Spot + " to " + nextPos);
            this.Spot = nextPos;
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
                        return this.Spot - 1;
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
