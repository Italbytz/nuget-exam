using Italbytz.Exam.Trivia.Abstractions;

namespace Italbytz.Exam.OperatingSystems;

public static class YesNoQuestions
{
    public static IYesNoQuestion[] Questions { get; } =
    [
        new OperatingSystemsYesNoQuestion { Text = "Die MMU übersetzt beim Paging logische Speicheradressen mit der Seitentabelle in physische Adressen.", Answer = true },
        new OperatingSystemsYesNoQuestion { Text = "Beim Paging haben alle Seiten die gleiche Länge.", Answer = true },
        new OperatingSystemsYesNoQuestion { Text = "Ein Nachteil kurzer Seiten beim Paging ist, dass die Seitentabelle sehr groß werden kann.", Answer = true },
        new OperatingSystemsYesNoQuestion { Text = "Journaling-Dateisysteme grenzen die bei der Konsistenzprüfung zu überprüfenden Daten ein.", Answer = true },
        new OperatingSystemsYesNoQuestion { Text = "Bei Dateisystemen mit Journal sind Datenverluste garantiert ausgeschlossen.", Answer = false },
        new OperatingSystemsYesNoQuestion { Text = "Ein Journal im Dateisystem reduziert die Anzahl der Schreibzugriffe.", Answer = false },
        new OperatingSystemsYesNoQuestion { Text = "Der Zugriff auf Festplatten erfolgt blockorientiert und kann wahlfrei geschehen.", Answer = true },
        new OperatingSystemsYesNoQuestion
        {
            Text = "Round Robin kann als faires Schedulingverfahren bezeichnet werden.",
            Answer = true,
            AlternativeQuestion = new OperatingSystemsYesNoQuestion
            {
                Text = "Prioritätengesteuertes Scheduling kann als faires Schedulingverfahren bezeichnet werden.",
                Answer = false
            }
        },
        new OperatingSystemsYesNoQuestion
        {
            Text = "Mit Prioritätengesteuertem Scheduling lässt sich die geringste Gesamtlaufzeit für Aufgaben erreichen.",
            Answer = false,
            AlternativeQuestion = new OperatingSystemsYesNoQuestion
            {
                Text = "Mit Stapelbetrieb lässt sich die geringste Gesamtlaufzeit für Aufgaben erreichen.",
                Answer = true
            }
        },
        new OperatingSystemsYesNoQuestion { Text = "Shortest Job First ist ein in der Praxis eingesetztes Schedulingverfahren.", Answer = false },
        new OperatingSystemsYesNoQuestion { Text = "Shortest Job First garantiert die geringste durchschnittliche Laufzeit.", Answer = true },
        new OperatingSystemsYesNoQuestion { Text = "Monolithische Betriebssystemkerne sind leichter zu erweitern und zu warten.", Answer = false },
        new OperatingSystemsYesNoQuestion { Text = "Mikrokernel führen zu einem langsameren Betriebssystem.", Answer = true },
        new OperatingSystemsYesNoQuestion { Text = "Aktives Warten vor dem Betreten eines kritischen Abschnitts verschwendet Rechenzeit.", Answer = true },
        new OperatingSystemsYesNoQuestion { Text = "Defragmentieren ist auch bei SSDs nötig.", Answer = false },
        new OperatingSystemsYesNoQuestion { Text = "Eine Vergrößerung des Speichers kann in manchen Ersetzungsstrategien zu mehr Seitenfehlern führen.", Answer = true },
        new OperatingSystemsYesNoQuestion
        {
            Text = "Die Funktion eines Mutex lässt sich auch mit Semaphoren erreichen.",
            Answer = true,
            AlternativeQuestion = new OperatingSystemsYesNoQuestion
            {
                Text = "Die Funktion einer Semaphore lässt sich auch mit einem Mutex erreichen.",
                Answer = false
            }
        }
    ];

    private sealed class OperatingSystemsYesNoQuestion : IYesNoQuestion
    {
        public bool Answer { get; set; }

        public string Category { get; set; } = "Operating Systems";

        public QuestionType QuestionType { get; set; } = QuestionType.Single;

        public Choices ChoicesType { get; set; } = Choices.Boolean;

        public Difficulty Difficulty { get; set; } = Difficulty.Medium;

        public string Text { get; set; } = string.Empty;

        public IQuestion AlternativeQuestion { get; set; } = null!;
    }
}
