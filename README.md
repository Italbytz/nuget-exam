# nuget-exam

`nuget-exam` bundles the refactored `Italbytz.Exam.*` and `Italbytz.Exam.Trivia.*` package families.

It is intended for developers who need reusable contracts for exam sheets, tasks, task text generation, and trivia-style question models.

## Current migration status

The first Phase 3 wave now includes:

- `Italbytz.Exam.Abstractions`
- `Italbytz.Exam.Trivia.Abstractions`

Later waves can add higher-level composition packages once the surrounding systems domains are fully migrated.

## Which package should I use?

- Use `Italbytz.Exam.Abstractions` for core contracts such as `IExam`, `ITask`, `ITaskText`, `ITaskTextGenerator`, `IExamExporter`, and `IStepwiseSolution`.
- Use `Italbytz.Exam.Trivia.Abstractions` for question-model contracts such as `IQuestion`, `IMultipleChoiceQuestion`, `IYesNoQuestion`, `Difficulty`, `Choices`, and `QuestionType`.

## Migration notice

Older repositories and articles may still refer to names such as:

- `Italbytz.Ports.Exam`
- `Italbytz.Ports.Trivia`
- `nuget-ports-exam`
- `nuget-ports-trivia`

For all new development, please use the new `Italbytz.Exam.*` package names.

## Documentation

API documentation is generated with `docfx` and can be published via GitHub Pages:

- `https://italbytz.github.io/nuget-exam/`

## Quality checks

This repository includes:

- a `GitHub Actions` workflow in `.github/workflows/ci.yml`
- automated `restore`, `build`, `test`, `pack`, and docs generation
- a `docfx` setup under `docfx/`

## Local validation

```bash
dotnet restore nuget-exam.sln
dotnet test nuget-exam.sln -v minimal
dotnet pack nuget-exam.sln -c Release -v minimal
dotnet tool restore
dotnet tool run docfx docfx/docfx.json
```