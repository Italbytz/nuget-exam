using Italbytz.Exam.Abstractions;
using Italbytz.Exam.Trivia.Abstractions;
using NetworkingQuiz = Italbytz.Exam.Networking.YesNoQuestions;
using OperatingSystemsQuiz = Italbytz.Exam.OperatingSystems.YesNoQuestions;

namespace Italbytz.Exam.Tests;

[TestClass]
public sealed class ExamContractsTests
{
    [TestMethod]
    public void Exam_contracts_capture_metadata_and_tasks()
    {
        var exam = new DummyExam
        {
            Lecture = "Computing Systems",
            Sheet = "Sheet 3",
            Student = "Ada",
            Tasks =
            [
                new DummyTask
                {
                    Score = 10,
                    Topic = "Binary arithmetic",
                    Text = new DummyTaskText { Problem = "Add 1 + 1", Solution = "10", Form = "short" }
                }
            ]
        };

        Assert.AreEqual("Computing Systems", exam.Lecture);
        Assert.AreEqual(10, exam.Tasks[0].Score);
        Assert.AreEqual("10", exam.Tasks[0].Text.Solution);
    }

    [TestMethod]
    public void Trivia_contracts_capture_question_shape()
    {
        IMultipleChoiceQuestion question = new DummyMultipleChoiceQuestion
        {
            Category = "Networking",
            QuestionType = QuestionType.Single,
            ChoicesType = Choices.Multiple,
            Difficulty = Difficulty.Medium,
            Text = "Which protocol resolves MAC addresses?",
            PossibleAnswers = ["ARP", "DNS", "TCP"],
            CorrectAnswerIndex = 0,
            AlternativeQuestion = null!
        };

        Assert.AreEqual(Choices.Multiple, question.ChoicesType);
        Assert.AreEqual(Difficulty.Medium, question.Difficulty);
        Assert.AreEqual(0, question.CorrectAnswerIndex);
    }

    [TestMethod]
    public void Networking_quiz_exposes_expected_yes_no_questions()
    {
        var questions = NetworkingQuiz.Questions;

        Assert.HasCount(14, questions);
        Assert.AreEqual("Networking", questions[0].Category);
        Assert.AreEqual(Choices.Boolean, questions[0].ChoicesType);
        Assert.AreEqual(Difficulty.Medium, questions[0].Difficulty);
        Assert.AreEqual("Die Mindestlänge von Rahmen dient dazu, Kollisionen erkennen zu können.", questions[0].Text);
        Assert.IsTrue(((IYesNoQuestion)questions[0]).Answer);
        Assert.IsNotNull(questions[2].AlternativeQuestion);
    }

    [TestMethod]
    public void Operating_systems_quiz_exposes_expected_yes_no_questions()
    {
        var questions = OperatingSystemsQuiz.Questions;

        Assert.HasCount(17, questions);
        Assert.AreEqual("Operating Systems", questions[0].Category);
        Assert.AreEqual(Choices.Boolean, questions[0].ChoicesType);
        Assert.AreEqual(Difficulty.Medium, questions[0].Difficulty);
        Assert.AreEqual("Die MMU übersetzt beim Paging logische Speicheradressen mit der Seitentabelle in physische Adressen.", questions[0].Text);
        Assert.IsTrue(((IYesNoQuestion)questions[0]).Answer);
        Assert.IsNotNull(questions[7].AlternativeQuestion);
    }

    private sealed class DummyExam : IExam
    {
        public bool Scored { get; set; }
        public string Lecture { get; set; } = string.Empty;
        public string Sheet { get; set; } = string.Empty;
        public string Student { get; set; } = string.Empty;
        public List<ITask> Tasks { get; set; } = [];
        public string FileName { get; set; } = string.Empty;
        public string WorkingDirectory { get; set; } = string.Empty;
        public string DateString { get; set; } = string.Empty;
        public int TotalScore { get; set; }
    }

    private sealed class DummyTask : ITask
    {
        public int Score { get; set; }
        public string Topic { get; set; } = string.Empty;
        public ITaskText Text { get; set; } = new DummyTaskText();
    }

    private sealed class DummyTaskText : ITaskText
    {
        public string Solution { get; set; } = string.Empty;
        public string Problem { get; set; } = string.Empty;
        public string Form { get; set; } = string.Empty;
    }

    private sealed class DummyMultipleChoiceQuestion : IMultipleChoiceQuestion
    {
        public string Category { get; set; } = string.Empty;
        public QuestionType QuestionType { get; set; }
        public Choices ChoicesType { get; set; }
        public Difficulty Difficulty { get; set; }
        public string Text { get; set; } = string.Empty;
        public IQuestion AlternativeQuestion { get; set; } = null!;
        public List<string> PossibleAnswers { get; set; } = [];
        public int CorrectAnswerIndex { get; set; }
    }
}
