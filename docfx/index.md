# nuget-exam

`nuget-exam` is the target repository for refactored `Italbytz.Exam.*` and `Italbytz.Exam.Trivia.*` packages.

## Current Phase 3 slice

- `Italbytz.Exam.Abstractions`
- `Italbytz.Exam.Trivia.Abstractions`

The first migrated abstractions cover exam metadata, tasks, task text generation, and trivia-style question models.
## Local validation

```bash
dotnet restore nuget-exam.sln
dotnet test nuget-exam.sln -v minimal
dotnet pack nuget-exam.sln -c Release -v minimal
dotnet tool restore
dotnet tool run docfx docfx/docfx.json
```
