using System;
using System.Collections.Generic;

namespace Italbytz.Exam.Abstractions
{
    public interface IExamExporter
    {
        string ExportPath { get; set; }

        void Export(IExam exams);
    }
}
