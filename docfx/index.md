# nuget-exam

`nuget-exam` is the target repository for refactored `Italbytz.Exam.*` packages that build on the reusable `Italbytz.Trivia.*` family.

## Current Phase 3 slice

- `Italbytz.Exam.Abstractions`
- `Italbytz.Trivia.Abstractions`
- `Italbytz.Trivia.OpenTriviaDb`
- `Italbytz.Exam.Networking`
- `Italbytz.Exam.OperatingSystems`

The migrated abstractions cover exam metadata, tasks, and task text generation, while the shared trivia family provides reusable question models and Open Trivia DB access. The first catalog packages add reusable true/false question sets for networking and operating systems.

## Guides

- `Guides > Shared exercise pipeline` outlines the next package slice for a renderer-neutral exercise model, shared solver traces, and multi-channel output.
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
