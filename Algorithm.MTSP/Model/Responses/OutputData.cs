using Algorithm.MTSP.Domain;
using Algorithm.MTSP.Model.Requests;
using Google.OrTools.ConstraintSolver;
using Google.OrTools.Sat;
using System;
using System.Collections.Generic;
using System.Linq;
using TypeGen.Core.TypeAnnotations;

namespace Algorithm.MTSP.Model.Responses
{
    [ExportTsInterface]
    public class OutputData
    {
        public CpSolverStatus Status;
        public InputData Input { get; set; }
        public List<Checkpoint> Checkpoints { get; set; } = new List<Checkpoint>();
        public List<PostpersonalizedWaypoint> Waypoints { get; set; } = new List<PostpersonalizedWaypoint>();

        public static OutputData From(
            in InputData inputData,
            in RoutingModel model,
            in RoutingIndexManager manager,
            in Assignment solution)
        {
            try
            {
                Console.WriteLine($"Objective {solution.ObjectiveValue()}:");
                var checkpoints = new List<Checkpoint>();

                // Inspect solution.
                long maxRouteDistance = 0;
                for (int i = 0; i < inputData.NumOfPostmans; ++i)
                {
                    Console.WriteLine("Route for Postperson {0}:", inputData.Postpersons[i].FullName);
                    long routeDistance = 0;
                    var index = model.Start(i);
                    var orderIndex = 0;
                    while (model.IsEnd(index) == false)
                    {
                        var nodeIndex = manager.IndexToNode((int)index);
                        Console.Write("{0} -> ", nodeIndex);
                        var previousIndex = index;
                        index = solution.Value(model.NextVar(index));
                        routeDistance += model.GetArcCostForVehicle(previousIndex, index, i);
                        checkpoints.Add(new Checkpoint()
                        {
                            PostPersonId = inputData.Postpersons[i].Id,
                            Order = orderIndex,
                            DestinationDetails = inputData
                                .Destinations
                                .FirstOrDefault(p => p.Index == nodeIndex) // or index itself
                        });
                        orderIndex = orderIndex + 1;
                    }
                    Console.WriteLine("{0}", manager.IndexToNode((int)index));
                    Console.WriteLine("Distance of the route: {0}m", routeDistance);
                    maxRouteDistance = Math.Max(routeDistance, maxRouteDistance);
                }
                Console.WriteLine("Maximum distance of the routes: {0}m", maxRouteDistance);

                return new OutputData()
                {
                    Input = inputData,
                    Checkpoints = checkpoints,
                    Status = CpSolverStatus.Feasible,
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}