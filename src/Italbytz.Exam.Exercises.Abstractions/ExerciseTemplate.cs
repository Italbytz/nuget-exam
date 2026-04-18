using System.Collections.Generic;

namespace Italbytz.Exam.Exercises.Abstractions;

public sealed class ExerciseTemplate
{
    public string Id { get; set; } = string.Empty;

    public string Locale { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string Intro { get; set; } = string.Empty;

    public IReadOnlyList<ExerciseSectionTemplate> Sections { get; set; } = new List<ExerciseSectionTemplate>();
}

public sealed class ExerciseSectionTemplate
{
    public string Title { get; set; } = string.Empty;

    public string Intro { get; set; } = string.Empty;

    public IReadOnlyList<ExerciseBlockTemplate> Blocks { get; set; } = new List<ExerciseBlockTemplate>();
}

public abstract class ExerciseBlockTemplate
{
    public string BlockType { get; set; } = string.Empty;
}