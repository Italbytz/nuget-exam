using Italbytz.Exam.Abstractions;
using Italbytz.Trivia.Abstractions;
using Italbytz.Trivia.OpenTriviaDb;
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

        [TestMethod]
        public void Open_trivia_db_boolean_payload_maps_to_yes_no_question()
        {
                const string payload = """
                {
                    "response_code": 0,
                    "results": [
                        {
                            "category": "Entertainment: Film",
                            "type": "boolean",
                            "difficulty": "easy",
                            "question": "The movie &quot;Alien&quot; was directed by James Cameron.",
                            "correct_answer": "False",
                            "incorrect_answers": ["True"]
                        }
                    ]
                }
                """;

                var result = OpenTriviaDbClient.ParseQuestions(payload);

                Assert.AreEqual(OpenTriviaDbResponseCode.Success, result.ResponseCode);
                Assert.HasCount(1, result.Questions);
                Assert.IsInstanceOfType<IYesNoQuestion>(result.Questions[0]);
                Assert.AreEqual("The movie \"Alien\" was directed by James Cameron.", result.Questions[0].Text);
                Assert.IsFalse(((IYesNoQuestion)result.Questions[0]).Answer);
        }

        [TestMethod]
        public void Open_trivia_db_multiple_choice_payload_maps_to_multiple_choice_question()
        {
                const string payload = """
                {
                    "response_code": 0,
                    "results": [
                        {
                            "category": "Science &amp; Nature",
                            "type": "multiple",
                            "difficulty": "medium",
                            "question": "What is the chemical symbol for silver?",
                            "correct_answer": "Ag",
                            "incorrect_answers": ["Au", "S", "Si"]
                        }
                    ]
                }
                """;

                var result = OpenTriviaDbClient.ParseQuestions(payload);

                Assert.AreEqual(OpenTriviaDbResponseCode.Success, result.ResponseCode);
                Assert.HasCount(1, result.Questions);
                Assert.IsInstanceOfType<IMultipleChoiceQuestion>(result.Questions[0]);

                var question = (IMultipleChoiceQuestion)result.Questions[0];
                CollectionAssert.AreEquivalent(new[] { "Ag", "Au", "S", "Si" }, question.PossibleAnswers);
                Assert.AreEqual("Ag", question.PossibleAnswers[question.CorrectAnswerIndex]);
                Assert.AreEqual("Science & Nature", question.Category);
        }

            [TestMethod]
            public void Open_trivia_db_category_constants_match_api_ids()
            {
                var categoryIds = new[]
                {
                    OpenTriviaDbCategories.EntertainmentFilm,
                    OpenTriviaDbCategories.EntertainmentVideoGames,
                    OpenTriviaDbCategories.ScienceNature
                };

                CollectionAssert.AreEqual(new[] { 11, 15, 17 }, categoryIds);
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
