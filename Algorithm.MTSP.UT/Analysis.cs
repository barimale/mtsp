using Algorithm.MTSP.Model.Requests;
using MTSP.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Algorithm.MTSP.UT
{
    public class Analysis
    {
        private readonly Engine _engine;

        public Analysis()
        {
            _engine = new Engine();
        }

        [Fact]
        public async Task GoodExample()
        {
            // given
            AlgorithmRequest input = new AlgorithmRequest()
            {
                CPSettings = new CPSettings()
                {
                    K = 20,
                    U = 1,
                },
                Destinations = new List<Destination>()
                {
                    new Destination()
                    {
                        Name = "Central Spot",
                        isMainSpot = true,
                        Latitude = 41.188587372011256M,
                        Longtitude =  -8.64965398820744M,
                    },
                    new Destination()
                    {
                        Name = "First",
                        isMainSpot = false,
                        Latitude = 41.23646377215915M,
                        Longtitude =  -8.66235961518736M,
                    },
                    new Destination()
                    {
                        Name = "Second",
                        isMainSpot = false,
                        Latitude = 41.25357142556481M,
                        Longtitude =  -8.6565884151869M,
                    },
                    new Destination()
                    {
                        Name = "Third",
                        isMainSpot = false,
                        Latitude = 41.31521502063901M,
                        Longtitude =  -8.680893486348776M,
                    }
                },
                Postpersons = new List<PostPerson>()
                {
                    new PostPerson()
                    {
                        FullName = "John Foo",
                        Email = ""
                    },
                    new PostPerson()
                    {
                        FullName = "Jack Bar",
                        Email = ""
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
            Assert.Equal(result.Data.Checkpoints.Count, result.Data.CalculatedAmountOfCheckpoints);
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