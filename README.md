# nuget-exam

`nuget-exam` bundles the refactored `Italbytz.Exam.*` and `Italbytz.Exam.Trivia.*` package families.

It is intended for developers who need reusable contracts for exam sheets, tasks, task text generation, and trivia-style question models.

## Current migration status

The current Phase 3 waves now include:

- `Italbytz.Exam.Abstractions`
- `Italbytz.Exam.Trivia.Abstractions`
- `Italbytz.Exam.Networking`
- `Italbytz.Exam.OperatingSystems`

This means the repo now provides both the shared exam/trivia contracts and the first reusable domain-specific quiz catalogs for networking and operating systems.

## Which package should I use?

- Use `Italbytz.Exam.Abstractions` for core contracts such as `IExam`, `ITask`, `ITaskText`, `ITaskTextGenerator`, `IExamExporter`, and `IStepwiseSolution`.
- Use `Italbytz.Exam.Trivia.Abstractions` for question-model contracts such as `IQuestion`, `IMultipleChoiceQuestion`, `IYesNoQuestion`, `Difficulty`, `Choices`, and `QuestionType`.
- Use `Italbytz.Exam.Networking` for reusable networking-oriented true/false quiz catalogs.
- Use `Italbytz.Exam.OperatingSystems` for reusable operating-systems-oriented true/false quiz catalogs.

## Migration notice

Older repositories and articles may still refer to names such as:

- `Italbytz.Ports.Exam`
- `Italbytz.Ports.Trivia`
- `Italbytz.Adapters.Exam.Networks`
- `Italbytz.Adapters.Exam.OperatingSystems`
- `nuget-ports-exam`
- `nuget-ports-trivia`
- `nuget-adapters-exam-networks`
- `nuget-adapters-exam-operating-systems`

For all new development, please use the new `Italbytz.Exam.*` package names.

## Documentation

API documentation is generated with `docfx` and can be published via GitHub Pages:

- `https://italbytz.github.io/nuget-exam/`

## Quality checks

This repository includes:

- a `GitHub Actions` workflow in `.github/workflows/ci.yml`
- automated `restore`, `build`, `test`, `pack`, and docs generation
- a `docfx` setup under `docfx/`

## Release model

- the current `nuget-exam` line stays on `1.0.0-preview.*` while higher-level exam composition packages are still pending
- a pushed tag such as `v1.0.0-preview.1` triggers the release-ready pipeline in GitHub Actions
- if the repository secret `NUGET_API_KEY` is configured, the workflow also publishes `.nupkg` and `.snupkg` files to NuGet

## Local validation

```bash
dotnet restore nuget-exam.sln
dotnet test nuget-exam.sln -v minimal
dotnet pack nuget-exam.sln -c Release -v minimal
dotnet tool restore
dotnet tool run docfx docfx/docfx.json
```