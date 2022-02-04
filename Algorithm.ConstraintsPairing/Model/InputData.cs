﻿namespace Algorithm.MTSP.Model
{
    public class InputData
    {
        private int[,] costs;

        public int[,] Costs
        {
            get
            {
                return costs;
            }
            set
            {
                costs = value;
            }
        }

        public int GifterAmount => costs.GetLength(0);
    }
}