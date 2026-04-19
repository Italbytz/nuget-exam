# nuget-exam

`nuget-exam` provides reusable exam and quiz packages built on the shared `Italbytz.Exam.*` and `Italbytz.Trivia.*` families.

This documentation is intended for package consumers who want to build reusable exam sheets, tasks, and quiz catalogs on shared question models.

## Packages at a glance

- `Italbytz.Exam.Abstractions`
- `Italbytz.Trivia.Abstractions`
- `Italbytz.Trivia.OpenTriviaDb`
- `Italbytz.Exam.Networking`
- `Italbytz.Exam.OperatingSystems`

These packages cover exam metadata, tasks, task text generation, shared trivia question models, Open Trivia DB integration, and the first reusable quiz catalogs.

## Guides

- `Guides > Question models` summarizes the shared abstractions for exams, tasks, and trivia questions.
- `Guides > Quiz catalogs` shows how the first domain-specific true/false question sets are exposed in code.
- `Guides > Shared exercise pipeline` gives architectural context for composing generated tasks and demonstrations.

## Use nuget-exam if you want to

- define exam and task contracts that stay independent of a single front end
- reuse trivia-style question models across teaching, demo, and quiz scenarios
- access the first networking and operating-systems question catalogs
- navigate generated API documentation for the full package family

## Local validation

```bash
dotnet restore nuget-exam.sln
dotnet test nuget-exam.sln -v minimal
dotnet pack nuget-exam.sln -c Release -v minimal
dotnet tool restore
dotnet tool run docfx docfx/docfx.json
```
