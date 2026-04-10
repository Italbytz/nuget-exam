# nuget-exam

`nuget-exam` is the target repository for refactored `Italbytz.Exam.*` and `Italbytz.Exam.Trivia.*` packages.

## Current Phase 3 slice

- `Italbytz.Exam.Abstractions`
- `Italbytz.Exam.Trivia.Abstractions`
- `Italbytz.Exam.Networking`
- `Italbytz.Exam.OperatingSystems`

The migrated abstractions cover exam metadata, tasks, task text generation, and trivia-style question models, while the first catalog packages add reusable true/false question sets for networking and operating systems.

## Guides

- `Guides > Question models` summarizes the shared abstractions for exams, tasks, and trivia questions.
- `Guides > Quiz catalogs` shows how the first domain-specific true/false question sets are exposed in code.

## Local validation

```bash
dotnet restore nuget-exam.sln
dotnet test nuget-exam.sln -v minimal
dotnet pack nuget-exam.sln -c Release -v minimal
dotnet tool restore
dotnet tool run docfx docfx/docfx.json
```
