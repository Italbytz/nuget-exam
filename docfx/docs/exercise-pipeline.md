# Shared Exercise Pipeline

This note describes the intended next package slice for generated exercises, reusable renderers, and edu-style demonstrations.

## Goal

The target architecture is a single pipeline:

`text building blocks + solver -> shared exercise instance -> LaTeX / HTML / Markdown -> PDF / HTML`

All output channels should consume the same semantic task instance instead of maintaining separate task wording or solver projections per client.

In addition to static worksheet and solution output, the same solver run must also be able to provide step traces for demonstrations in edu.

## Why the current abstractions are not enough

`Italbytz.Exam.Abstractions` currently provides stable core contracts such as `ITask` and `ITaskText`.

These types are still useful, but they are too coarse for a shared multi-channel exercise pipeline:

- `ITaskText` collapses task wording into `Problem`, `Solution`, and `Form` strings.
- there is no shared semantic block model for tables, prompt-answer variants, figures, or answer areas.
- there is no standard solver result contract for end states plus demo traces.
- there is no renderer-neutral exercise instance that LaTeX, HTML, and Markdown can all consume.

## Proposed package family

The following packages fit naturally into `nuget-exam` and extend the current abstractions without replacing them immediately.

### `Italbytz.Exam.Exercises.Abstractions`

Shared semantic contracts for generated exercises.

Suggested responsibilities:

- `ExerciseTemplate`: language-specific text building blocks and labels
- `ExerciseInstance`: fully materialized exercise ready for rendering
- `ExerciseSection`
- `ExerciseBlock`
- `FigureSpec`
- `ResponseSpec`
- `VariantSpec`
- `ExerciseLocale`

This package becomes the canonical exchange format between task generation and renderers.

### `Italbytz.Exam.Exercises.Generation`

Composition layer that combines templates, solver results, and optional assets into an `ExerciseInstance`.

Suggested responsibilities:

- task-specific composers for Binary Addition, Shortest Path, Page Replacement, Spanning Tree, and similar tasks
- mapping from existing task objects into shared exercise instances
- integration of localized text building blocks

### `Italbytz.Exam.Exercises.Solver`

Standard result contracts for generated tasks.

Suggested responsibilities:

- `ISolver<TInput, TResult, TTrace>`
- `SolverResult<TFinalState, TTrace>`
- `DemoTrace`
- `DemoStep`

The important rule is that a solver should produce both a final state and an optional trace from the same run.

### `Italbytz.Exam.Exercises.Rendering.Abstractions`

Optional shared renderer contracts if multiple renderers should follow the same conventions.

Suggested responsibilities:

- `IExerciseRenderer<TOutput>`
- shared rendering options
- print mode vs. worksheet mode vs. solution mode flags

### `Italbytz.Exam.Exercises.Rendering.Html`

HTML renderer for edu and browser-based previews.

Suggested responsibilities:

- semantic HTML rendering from `ExerciseInstance`
- print-oriented HTML for browser PDF export
- optional projection helpers for thin web-specific view models

### `Italbytz.Exam.Exercises.Rendering.LaTeX`

LaTeX renderer for the existing exam generation flow.

Suggested responsibilities:

- HSHL-compatible LaTeX output from `ExerciseInstance`
- worksheet and solution rendering from the same semantic source
- support for shared answer areas, figures, prompt/answer blocks, and response tables

### `Italbytz.Exam.Exercises.Rendering.Markdown`

Optional Markdown output for reviews, companion content, and documentation.

## Core model sketch

The central distinction should be:

- `ExerciseTemplate`: wording and labels
- `SolverResult`: final state plus optional trace
- `ExerciseInstance`: merged semantic task instance used by all renderers

Example shape:

```csharp
public sealed record ExerciseInstance(
    string Id,
    string Title,
    string Intro,
    IReadOnlyList<ExerciseSection> Sections,
    ExerciseRenderAssets Assets,
    ExerciseSolutionData Solution,
    ExerciseDemoTrace? DemoTrace);

public sealed record SolverResult<TFinalState, TTrace>(
    TFinalState FinalState,
    TTrace? Trace);
```

The renderers should not call solvers and should not invent wording. They should only render an already composed `ExerciseInstance`.

## Demonstration support for edu

edu needs more than static worksheet and solution output.

For demonstrations, the shared solver layer must expose stepwise data in a structured form:

- Page Replacement: requests, frame content per step, page faults, pointer position, reference bits, distances
- Shortest Path: chosen node per iteration, candidate frontier, distance updates, predecessor changes
- Spanning Tree: selected edge, candidate set, accumulated tree cost

This should not be implemented as edu-only logic.

Instead, the same solver run should yield:

- `FinalState` for worksheet and solution rendering
- `Trace` for demonstrations and teaching visualizations

edu can then use the shared `Trace` directly for animations or step-by-step views.

## Relationship to current code

The current codebase already contains building blocks for this direction, but they are not yet centralized:

- existing `ITask` and `ITaskText` contracts in `Italbytz.Exam.Abstractions`
- task-specific solver usage in consumer projects
- a neutral single-task document model in the current ExamGenerator consumer
- edu-specific view models for HTML rendering

The future shared pipeline should replace consumer-to-consumer projections with a single canonical exercise model.

That means the long-term target is:

- not `ExamGenerator model -> edu model`
- but `shared exercise instance -> LaTeX renderer` and `shared exercise instance -> HTML renderer`

## Migration path

The migration can be incremental.

### Phase 1

Introduce `Italbytz.Exam.Exercises.Abstractions` and `Italbytz.Exam.Exercises.Solver`.

Start with a small number of shared types for:

- exercise sections and blocks
- figures and response areas
- solver final state plus trace

### Phase 2

Move two representative tasks first:

- Page Replacement because it already benefits from explicit step traces
- Shortest Path because it needs both generated assets and stepwise state changes

These tasks are good pilots because they cover both static output and demonstrations.

### Phase 3

Implement the first shared renderers:

- LaTeX renderer for the current ExamGenerator export path
- HTML renderer for edu

During this phase, existing web JSON files can remain a publish artifact, but they should be generated from the shared exercise instance rather than treated as the primary source model.

### Phase 4

Adapt the comparison and export tooling so that it consumes the shared pipeline directly.

At that point, the comparison runner would no longer need to project from a consumer-local model into edu-specific JSON as an architectural stopgap.

## Recommended first package slice

The smallest useful first slice inside `nuget-exam` is:

- `Italbytz.Exam.Exercises.Abstractions`
- `Italbytz.Exam.Exercises.Solver`

These two packages are enough to establish a canonical exercise instance and a shared result/trace model before introducing renderer packages.

That keeps the initial change set small while still moving the architecture decisively toward one pipeline.