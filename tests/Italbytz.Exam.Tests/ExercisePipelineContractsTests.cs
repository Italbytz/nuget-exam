using Italbytz.Exam.Exercises.Abstractions;
using Italbytz.Exam.Exercises.Solver;

namespace Italbytz.Exam.Tests;

[TestClass]
public sealed class ExercisePipelineContractsTests
{
    [TestMethod]
    public void Exercise_instance_captures_shared_semantic_blocks()
    {
        var instance = new ExerciseInstance
        {
            Id = "page-replacement",
            Locale = "de",
            Title = "Seitenersetzungsstrategien",
            Intro = "Bearbeiten Sie die Aufgabe auf Basis der gegebenen Referenzfolge.",
            Sections =
            [
                new ExerciseSection
                {
                    Title = "Clock",
                    Blocks =
                    [
                        new ParagraphExerciseBlock
                        {
                            Text = "Nutzen Sie die Clock-Strategie."
                        },
                        new WorksheetExerciseBlock
                        {
                            Title = "Simulation",
                            Table = new ResponseTableSpec
                            {
                                RowHeaderLabel = "Rahmen",
                                AriaLabel = "Clock-Verlauf",
                                Columns = [new ResponseTableColumnSpec { Header = "1" }],
                                Rows =
                                [
                                    new ResponseTableRowSpec
                                    {
                                        Header = "Frame 0",
                                        Cells = [string.Empty],
                                        SolutionCells = ["7"]
                                    }
                                ]
                            },
                            ResponseArea = new ResponseAreaSpec
                            {
                                AnswerLabel = "Antwort",
                                SolutionLabel = "Lösung",
                                AnswerLineCount = 3
                            }
                        }
                    ]
                }
            ]
        };

        Assert.AreEqual("page-replacement", instance.Id);
        Assert.AreEqual("de", instance.Locale);
        Assert.HasCount(2, instance.Sections[0].Blocks);
        Assert.IsInstanceOfType<WorksheetExerciseBlock>(instance.Sections[0].Blocks[1]);
    }

    [TestMethod]
    public void Page_replacement_solver_contract_captures_final_state_and_steps()
    {
        var run = new SolverRun<PageReplacementFinalState, PageReplacementStep>
        {
            FinalState = new PageReplacementFinalState
            {
                Strategy = "Clock",
                ReferenceRequests = [7, 0, 1],
                FinalFrames =
                [
                    new PageReplacementFrameState { Slot = 0, Page = 7, ReferenceBit = true, IsPointerSlot = true }
                ],
                PageFaultCount = 3
            },
            Trace = new DemoTrace<PageReplacementStep>
            {
                TraceType = "page-replacement",
                Steps =
                [
                    new PageReplacementStep
                    {
                        StepIndex = 0,
                        RequestedPage = 7,
                        IsPageFault = true,
                        Frames = [new PageReplacementFrameState { Slot = 0, Page = 7 }],
                        Explanation = "Leerer Rahmen wird belegt."
                    }
                ]
            }
        };

        Assert.AreEqual("Clock", run.FinalState!.Strategy);
        Assert.AreEqual(3, run.FinalState.PageFaultCount);
        Assert.AreEqual("page-replacement", run.Trace.TraceType);
        Assert.AreEqual(7, run.Trace.Steps[0].RequestedPage);
    }

    [TestMethod]
    public void Shortest_path_solver_contract_captures_final_routes_and_relaxations()
    {
        var run = new SolverRun<ShortestPathFinalState, ShortestPathStep>
        {
            FinalState = new ShortestPathFinalState
            {
                StartNode = "A",
                Distances =
                [
                    new ShortestPathDistanceState { Node = "A", Distance = 0 },
                    new ShortestPathDistanceState { Node = "B", Distance = 4, PreviousNode = "A" }
                ],
                Routes =
                [
                    new ShortestPathRoute { TargetNode = "B", Path = ["A", "B"], TotalCost = 4 }
                ]
            },
            Trace = new DemoTrace<ShortestPathStep>
            {
                TraceType = "shortest-path",
                Steps =
                [
                    new ShortestPathStep
                    {
                        StepIndex = 0,
                        CurrentNode = "A",
                        Frontier = ["B", "C"],
                        Distances = [new ShortestPathDistanceState { Node = "A", Distance = 0 }],
                        Relaxations =
                        [
                            new ShortestPathRelaxation
                            {
                                FromNode = "A",
                                ToNode = "B",
                                CandidateDistance = 4,
                                Accepted = true
                            }
                        ]
                    }
                ]
            }
        };

        Assert.AreEqual("A", run.FinalState!.StartNode);
        Assert.AreEqual("B", run.FinalState.Routes[0].TargetNode);
        Assert.AreEqual("shortest-path", run.Trace.TraceType);
        Assert.IsTrue(run.Trace.Steps[0].Relaxations[0].Accepted);
    }
}