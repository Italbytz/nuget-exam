using System.Collections.Generic;

namespace Italbytz.Exam.Exercises.Solver;

public sealed class PageReplacementFinalState
{
    public string Strategy { get; set; } = string.Empty;

    public IReadOnlyList<int> ReferenceRequests { get; set; } = new List<int>();

    public IReadOnlyList<PageReplacementFrameState> FinalFrames { get; set; } = new List<PageReplacementFrameState>();

    public int PageFaultCount { get; set; }
}

public sealed class PageReplacementRunSet
{
    public IReadOnlyList<SolverRun<PageReplacementFinalState, PageReplacementStep>> Runs { get; set; } = new List<SolverRun<PageReplacementFinalState, PageReplacementStep>>();
}

public sealed class PageReplacementFrameState
{
    public int Slot { get; set; }

    public string Page { get; set; } = string.Empty;

    public string? ReferenceBit { get; set; }

    public string? Distance { get; set; }

    public bool IsPointerSlot { get; set; }
}

public sealed class PageReplacementStep
{
    public int StepIndex { get; set; }

    public int RequestedPage { get; set; }

    public bool IsPageFault { get; set; }

    public IReadOnlyList<PageReplacementFrameState> Frames { get; set; } = new List<PageReplacementFrameState>();

    public string Explanation { get; set; } = string.Empty;
}