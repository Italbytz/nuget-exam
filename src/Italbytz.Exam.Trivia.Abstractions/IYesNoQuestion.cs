using System;
namespace Italbytz.Exam.Trivia.Abstractions
{
    public interface IYesNoQuestion : IQuestion
    {
        bool Answer { get; set; }
    }
}
