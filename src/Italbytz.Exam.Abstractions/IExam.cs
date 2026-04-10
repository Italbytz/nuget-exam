using System;
using System.Collections.Generic;

namespace Italbytz.Exam.Abstractions
{
    public interface IExam
    {
        bool Scored { get; set; }
        string Lecture { get; set; }
        string Sheet { get; set; }
        string Student { get; set; }
        List<ITask> Tasks { get; set; }
        string FileName { get; set; }
        
        string WorkingDirectory { get; set; }
        
        string DateString { get; set; }
        
        int TotalScore { get; set; }
    }
}
