using Google.OrTools.Sat;
using System.Collections.Generic;

namespace Algorithm.MTSP.Utilities
{
    public static class Extensions
    {
        public static Constraint AddSequence(this CpModel model_, IEnumerable<IntervalVar> intervals)
        {
            // WIP change to AddSequence
            Constraint constraint = new Constraint(model_.Model);
            NoOverlapConstraintProto noOverlapConstraintProto = new NoOverlapConstraintProto();
            foreach (IntervalVar interval in intervals)
            {
                noOverlapConstraintProto.Intervals.Add(interval.GetIndex());
            }

            constraint.Proto.NoOverlap = noOverlapConstraintProto;
            return constraint;
        }

    }
}
