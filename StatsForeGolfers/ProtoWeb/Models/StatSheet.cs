using System;
using ProtoWeb.Interfaces;

namespace ProtoWeb
{
    public enum Stroke
    {
        TotalHits,
        TotalMisses,
        TotalGreenStrokes,
        GreenHit,
        GreenMissRight,
        GreenMissLeft,
        Bunker,
        Rough,
        French,
        TotalFairwayStrokes,
        FairWayHit,
        FairWayMissLeft,
        FairWayMissRight,
        TotalScrambleStrokes,
        ScrambleHit,
        ScrambleMiss,
        None
    }
    public class StatSheet
    {
        public int TotalHits { get; set; }
        public int TotalMisses { get; set; }

        public int TotalGreenStrokes { get; set; }
        public int GreenHit { get; set; }
        public int GreenMissRight { get; set; }
        public int GreenMissLeft { get; set; }
        // If green miss---> did it hit Bunker, rough or French

        public bool Bunker { get; set; }
        public bool Rough { get; set; }
        public bool French { get; set; }

        public int TotalFairwayStrokes { get; set; }
        public int FairWayHit { get; set; }
        public int FairWayMissLeft { get; set; }
        public int FairWayMissRight { get; set; }

        public int TotalScrambleStrokes { get; set; }
        public int ScrambleHit { get; set; }
        public int ScrambleMiss { get; set; }

        public double PercentageCalculator(double number,double totalNumber)
        {
            double result = 0;
            if (totalNumber != 0 && number != 0)
            {
                result = number / totalNumber;
            }

            return result;
        }

        public Stroke Increase(Stroke stroke)
        {
            switch(stroke)
            {
                case Stroke.TotalHits:
                    {
                        TotalHits++;
                        return Stroke.TotalHits;
                    }
                case Stroke.TotalMisses:
                    {
                        TotalMisses++;
                        return Stroke.TotalMisses;
                    }
                case Stroke.TotalGreenStrokes:
                    {
                        TotalGreenStrokes++;
                        return Stroke.TotalGreenStrokes;
                    }
                case Stroke.GreenHit:
                    {
                        GreenHit++;
                        return Stroke.GreenHit;
                    }
                case Stroke.GreenMissRight:
                    {
                        GreenMissRight++;
                        return Stroke.GreenMissRight;
                    }
                case Stroke.GreenMissLeft:
                    {
                        GreenMissLeft++;
                        return Stroke.GreenMissLeft;
                    }
                //case Stroke.Bunker:
                //    {
                //        break;
                //    }
                //case Stroke.Rough:
                //    {
                //        break;
                //    }
                //case Stroke.French:
                //    {
                //        break;
                //    }
                case Stroke.TotalFairwayStrokes:
                    {
                        TotalFairwayStrokes++;
                        return Stroke.TotalFairwayStrokes;
                    }
                case Stroke.FairWayHit:
                    {
                        FairWayHit++;
                        return Stroke.FairWayHit;
                    }
                case Stroke.FairWayMissLeft:
                    {
                        FairWayMissLeft++;
                        return Stroke.FairWayMissLeft;
                    }
                case Stroke.FairWayMissRight:
                    {
                        FairWayMissRight++;
                        return Stroke.FairWayMissRight;
                    }
                case Stroke.TotalScrambleStrokes:
                    {
                        TotalScrambleStrokes++;
                        return Stroke.TotalScrambleStrokes;
                    }
                case Stroke.ScrambleHit:
                    {
                        ScrambleHit++;
                        return Stroke.ScrambleHit;
                    }
                case Stroke.ScrambleMiss:
                    {
                        ScrambleMiss++;
                        return Stroke.ScrambleMiss;
                    }
                default:
                    {
                        return Stroke.None;
                    }
            }
        }
    }
}
