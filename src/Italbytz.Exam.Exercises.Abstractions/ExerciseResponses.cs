using System.Collections.Generic;

namespace Italbytz.Exam.Exercises.Abstractions;

public sealed class FigureSpec
{
    public string Source { get; set; } = string.Empty;

    public string AltText { get; set; } = string.Empty;
}

public sealed class ResponseAreaSpec
{
    public string AnswerLabel { get; set; } = string.Empty;

    public string SolutionLabel { get; set; } = string.Empty;

    public int AnswerLineCount { get; set; } = 6;
}

public sealed class ResponseTableSpec
{
    public string RowHeaderLabel { get; set; } = string.Empty;

    public string AriaLabel { get; set; } = string.Empty;

    public IReadOnlyList<ResponseTableColumnSpec> Columns { get; set; } = new List<ResponseTableColumnSpec>();

    public IReadOnlyList<ResponseTableRowSpec> Rows { get; set; } = new List<ResponseTableRowSpec>();
}

public sealed class ResponseTableColumnSpec
{
    public string Header { get; set; } = string.Empty;
}

public sealed class ResponseTableRowSpec
{
    public string Header { get; set; } = string.Empty;

    public IReadOnlyList<string> Cells { get; set; } = new List<string>();

    public IReadOnlyList<string>? SolutionCells { get; set; }
}