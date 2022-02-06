using Algorithm.MTSP.Model.Requests;
using MTSP.Domain;
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
                "https://dev.virtualearth.net/REST/v1/Routes/DistanceMatrix",
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
                        Latitude = 41.188587372011256M,
                        Longtitude =  -8.64965398820744M,
                        Index = 0,
                    },
                    new Location()
                    {
                        Name = "First",
                        isMainSpot = false,
                        Latitude = 41.23646377215915M,
                        Longtitude =  -8.66235961518736M,
                        Index = 1,
                    },
                    new Location()
                    {
                        Name = "Second",
                        isMainSpot = false,
                        Latitude = 41.25357142556481M,
                        Longtitude =  -8.6565884151869M,
                        Index = 2,
                    },
                    new Location()
                    {
                        Name = "Third",
                        isMainSpot = false,
                        Latitude = 41.31521502063901M,
                        Longtitude =  -8.680893486348776M,
                        Index = 3,
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