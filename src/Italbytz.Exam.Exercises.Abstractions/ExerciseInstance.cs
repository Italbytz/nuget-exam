using System.Collections.Generic;

namespace Italbytz.Exam.Exercises.Abstractions;

public sealed class ExerciseInstance
{
    public string Id { get; set; } = string.Empty;

    public string Locale { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string Intro { get; set; } = string.Empty;

    public IReadOnlyList<ExerciseSection> Sections { get; set; } = new List<ExerciseSection>();
}

public sealed class ExerciseSection
{
    public string Title { get; set; } = string.Empty;

    public string Intro { get; set; } = string.Empty;

    public IReadOnlyList<ExerciseBlock> Blocks { get; set; } = new List<ExerciseBlock>();
}