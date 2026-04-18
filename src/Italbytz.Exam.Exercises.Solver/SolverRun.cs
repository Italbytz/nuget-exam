using System.Collections.Generic;

namespace Italbytz.Exam.Exercises.Solver;

public sealed class SolverRun<TFinalState, TStep>
{
    public TFinalState? FinalState { get; set; }

    public DemoTrace<TStep> Trace { get; set; } = new DemoTrace<TStep>();
}

public sealed class DemoTrace<TStep>
{
    public string TraceType { get; set; } = string.Empty;

    public IReadOnlyList<TStep> Steps { get; set; } = new List<TStep>();
}