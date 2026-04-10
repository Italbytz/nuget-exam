using System;
namespace Italbytz.Exam.Abstractions
{
    public interface ITaskTextGenerator<T> where T : ITask
    {
        ITaskText Generate(T task);
    }
}
