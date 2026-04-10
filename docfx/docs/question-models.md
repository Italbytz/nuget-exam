# Question models and exam abstractions

This guide summarizes the shared abstractions in `nuget-exam` and shows how they fit together.

## Core exam contracts

Use `Italbytz.Exam.Abstractions` when you need the reusable building blocks for exam generation or export workflows.

Important types include:

- `IExam` for exam-level metadata such as lecture, sheet, student, tasks, file name, working directory, date string, and total score
- `ITask` and `ITaskText` for task-level structure and text
- `ITaskTextGenerator` for generating task wording
- `IExamExporter` for exporting an `IExam`
- `IStepwiseSolution` for tasks that expose intermediate reasoning or solution steps

## Trivia question contracts

Use `Italbytz.Exam.Trivia.Abstractions` when you need a reusable question model.

Important types include:

- `IQuestion` for the common shape of a question
- `IYesNoQuestion` and `IMultipleChoiceQuestion` for specialized forms
- `QuestionType`, `Choices`, and `Difficulty` enums for describing the expected interaction and difficulty level

A question can also reference an `AlternativeQuestion`, which is useful for paired true/false or reformulated prompts.

## When to use which package

| Need | Package |
| --- | --- |
| exam sheets, tasks, exporters, and generated task text | `Italbytz.Exam.Abstractions` |
| generic trivia question models | `Italbytz.Exam.Trivia.Abstractions` |
| ready-to-use networking question catalog | `Italbytz.Exam.Networking` |
| ready-to-use operating-systems question catalog | `Italbytz.Exam.OperatingSystems` |

## Historical mapping

The consolidated packages replace the older structure as follows:

- `Italbytz.Ports.Exam` → `Italbytz.Exam.Abstractions`
- `Italbytz.Ports.Trivia` → `Italbytz.Exam.Trivia.Abstractions`
- domain-specific quiz adapters now live in `Italbytz.Exam.Networking` and `Italbytz.Exam.OperatingSystems`

This keeps the original teaching use cases, but presents them under clearer and more reusable package names.