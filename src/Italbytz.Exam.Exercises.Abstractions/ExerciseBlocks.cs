using System.Collections.Generic;

namespace Italbytz.Exam.Exercises.Abstractions;

public abstract class ExerciseBlock
{
    public string Title { get; set; } = string.Empty;

    public string Intro { get; set; } = string.Empty;
}

public sealed class ParagraphExerciseBlock : ExerciseBlock
{
    public string Text { get; set; } = string.Empty;
}

public sealed class PromptAnswerExerciseBlock : ExerciseBlock
{
    public string PromptLabel { get; set; } = string.Empty;

    public string AnswerLabel { get; set; } = string.Empty;

    public string SolutionLabel { get; set; } = string.Empty;

    public PromptAnswerPresentation Presentation { get; set; } = PromptAnswerPresentation.Default;

    public IReadOnlyList<PromptAnswerVariantSpec> Variants { get; set; } = new List<PromptAnswerVariantSpec>();
}

public sealed class BinaryAdditionExerciseBlock : ExerciseBlock
{
    public string SolutionLabel { get; set; } = string.Empty;

    public IReadOnlyList<BinaryAdditionVariantSpec> Variants { get; set; } = new List<BinaryAdditionVariantSpec>();
}

public sealed class WorksheetExerciseBlock : ExerciseBlock
{
    public FigureSpec? Figure { get; set; }

    public ResponseTableSpec? Table { get; set; }

    public ResponseAreaSpec ResponseArea { get; set; } = new ResponseAreaSpec();

    public string SolutionText { get; set; } = string.Empty;
}

public sealed class PromptAnswerVariantSpec
{
    public string Label { get; set; } = string.Empty;

    public string Prompt { get; set; } = string.Empty;

    public string Answer { get; set; } = string.Empty;
}

public sealed class BinaryAdditionVariantSpec
{
    public string Label { get; set; } = string.Empty;

    public string LeftAddend { get; set; } = string.Empty;

    public string RightAddend { get; set; } = string.Empty;

    public string Sum { get; set; } = string.Empty;
}

public enum PromptAnswerPresentation
{
    Default = 0,
    WideAnswerLine = 1,
    WorkingBox = 2,
    FigureWithAnswerArea = 3,
    TableWithAnswerArea = 4
}