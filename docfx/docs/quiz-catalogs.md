# Quiz catalogs

`nuget-exam` already includes two small, reusable question catalogs for teaching and exam-preparation scenarios.

## Available catalogs

| Package | Content | Entry point |
| --- | --- | --- |
| `Italbytz.Exam.Networking` | networking-oriented true/false questions | `YesNoQuestions.Questions` |
| `Italbytz.Exam.OperatingSystems` | operating-systems-oriented true/false questions | `YesNoQuestions.Questions` |

These catalogs are built on top of `Italbytz.Exam.Trivia.Abstractions` and expose `IYesNoQuestion` objects with a category, difficulty, answer, and optional `AlternativeQuestion`.

## Example usage

```csharp
using Italbytz.Exam.Networking;
using Italbytz.Exam.Trivia.Abstractions;

foreach (IYesNoQuestion question in YesNoQuestions.Questions)
{
    Console.WriteLine($"[{question.Category}] {question.Text}");
}
```

A similar entry point exists in `Italbytz.Exam.OperatingSystems.YesNoQuestions`.

## Current content focus

The first migrated catalogs cover topics such as:

- networking basics like frames, MAC/IP concepts, UDP vs. TCP, DHCP, ICMP, bridges, routing, and line encoding
- operating-systems topics such as paging, scheduling, journaling, semaphores, mutexes, fragmentation, and fairness

## Why this matters

The catalog packages give you a ready-made source for classroom demos, quiz generators, or lightweight revision tools without forcing you to model the question domain from scratch.