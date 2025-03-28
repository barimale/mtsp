﻿using Algorithm.MTSP.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Algorithm.MTSP.Providers.DistanceMatrixProviders
{
    public interface IMatrixDistanceProvider
    {
        public void Initialize(string url, string apiKey);
        public Task<long[,]> CalculateDistanceMatrix(List<Location> destinations);
    }
}
