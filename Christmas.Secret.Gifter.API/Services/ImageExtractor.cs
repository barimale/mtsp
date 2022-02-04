﻿using MTSP.API.Services.Abstractions;
using System.Threading.Tasks;

namespace MTSP.API.Services
{
    public class ImageExtractor : IImageExtractor
    {
        public Task SaveLocallyAsync()
        {
            //Current implmentation of the shop supports usage of images by API
            //which means that extracting them to the disk is not necesarry.
            return Task.CompletedTask;
        }
    }
}
