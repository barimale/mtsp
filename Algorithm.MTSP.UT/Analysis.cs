using Algorithm.MTSP.Domain;
using Algorithm.MTSP.Model.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Algorithm.MTSP.UT
{
    public class Analysis
    {
        private readonly IEngine _engine;

        public Analysis(IEngine engine)
        {
            _engine = engine;

            _engine.Initialize(
                "https://dev.virtualearth.net/REST/v1/Routes",
                "At9XD7ylECHAvO9eXd2v3VU6_k7dmI--fi3cf_wijlUO9cM1UKtrFbTsDJiIToGg");
        }

        [Fact]
        public async Task GoodExample()
        {
            // given
            AlgorithmRequest input = new AlgorithmRequest()
            {
                Destinations = new List<Location>()
                {
                    new Location()
                    {
                        Name = "Central Spot",
                        isMainSpot = true,
                        Latitude = 41.1597588M,
                        Longtitude =  -8.6208183M,
                        Index = 0,
                    },
                    new Location()
                    {
                        Name = "First",
                        isMainSpot = false,
                        Latitude = 41.1633360219944M,
                        Longtitude =  -8.620945988525714M,
                        Index = 1,
                    },
                    new Location()
                    {
                        Name = "Second",
                        isMainSpot = false,
                        Latitude = 41.16074183156456M,
                        Longtitude =  -8.621021090380932M,
                        Index = 2,
                    },
                    new Location()
                    {
                        Name = "Third",
                        isMainSpot = false,
                        Latitude = 41.15525313993203M,
                        Longtitude =  -8.618818163399695M,
                        Index = 3,
                    },
                    new Location()
                    {
                        Name = "Fourth",
                        isMainSpot = false,
                        Latitude = 41.15872980771394M,
                        Longtitude =  -8.62797753524917M,
                        Index = 4,
                    },
                    new Location()
                    {
                        Name = "Fifth",
                        isMainSpot = false,
                        Latitude = 41.15043324003648M,
                        Longtitude =  -8.611124566184273M,
                        Index = 5,
                    }
                },
                Postpersons = new List<PostPerson>()
                {
                    new PostPerson()
                    {
                        FullName = "John Foo",
                        Email = "",
                        Id = 1,
                    },
                    new PostPerson()
                    {
                        FullName = "Jack Bar",
                        Email = "",
                        Id = 2,
                    }
                }
            };

            // when
            var result = await _engine.CalculateAsync(input);

            // then
            Assert.NotNull(result);
            Assert.False(result.IsError);
            Assert.Null(result.Reason);
            Assert.NotNull(result.Data);
            Assert.NotEmpty(result.Data.Checkpoints);
        }

        //[Fact]
        //public async Task BadCornerCase()
        //{
        //    // given
        //    int[,] costs = {
        //        { -1, 100, 100, 100 },
        //        { 0, -1, 0, 0 },
        //        { 100, 100, -1, 100 },
        //        { 100, 100, 100, -1 }
        //    };

        //    InputData input = new()
        //    {
        //        Costs = costs
        //    };

        //    // when
        //    var result = await _engine.CalculateAsync(input);

        //    // then
        //    Assert.NotNull(result);
        //    Assert.False(result.IsError);
        //    Assert.Null(result.Reason);
        //    Assert.NotNull(result.Data);
        //    Assert.Empty(result.Data.Pairs);
        //}
    }
}