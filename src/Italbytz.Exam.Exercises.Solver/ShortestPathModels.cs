using System.Collections.Generic;

namespace Italbytz.Exam.Exercises.Solver;

public sealed class ShortestPathFinalState
{
    public string StartNode { get; set; } = string.Empty;

    public IReadOnlyList<ShortestPathDistanceState> Distances { get; set; } = new List<ShortestPathDistanceState>();

    public IReadOnlyList<ShortestPathRoute> Routes { get; set; } = new List<ShortestPathRoute>();
}

public sealed class ShortestPathStep
{
    public int StepIndex { get; set; }

    public string CurrentNode { get; set; } = string.Empty;

    public IReadOnlyList<string> Frontier { get; set; } = new List<string>();

    public IReadOnlyList<ShortestPathDistanceState> Distances { get; set; } = new List<ShortestPathDistanceState>();

    public IReadOnlyList<ShortestPathRelaxation> Relaxations { get; set; } = new List<ShortestPathRelaxation>();
}

public sealed class ShortestPathDistanceState
{
    public string Node { get; set; } = string.Empty;

    public int? Distance { get; set; }

    public string? PreviousNode { get; set; }
}

public sealed class ShortestPathRelaxation
{
    public string FromNode { get; set; } = string.Empty;

    public string ToNode { get; set; } = string.Empty;

    public int CandidateDistance { get; set; }

    public bool Accepted { get; set; }
}

public sealed class ShortestPathRoute
{
    public string TargetNode { get; set; } = string.Empty;

    public IReadOnlyList<string> Path { get; set; } = new List<string>();

    public int TotalCost { get; set; }
}