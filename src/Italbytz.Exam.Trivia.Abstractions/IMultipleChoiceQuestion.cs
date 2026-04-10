using System;
using System.Collections.Generic;

namespace Italbytz.Exam.Trivia.Abstractions
{
    public interface IMultipleChoiceQuestion : IQuestion
    {
        List<string> PossibleAnswers { get; set; }
        int CorrectAnswerIndex { get; set; }
    }
}
