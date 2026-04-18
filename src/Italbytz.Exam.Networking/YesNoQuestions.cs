using Italbytz.Trivia.Abstractions;

namespace Italbytz.Exam.Networking;

public static class YesNoQuestions
{
    public static IYesNoQuestion[] Questions { get; } =
    [
        new NetworkingYesNoQuestion { Text = "Die Mindestlänge von Rahmen dient dazu, Kollisionen erkennen zu können.", Answer = true },
        new NetworkingYesNoQuestion { Text = "Die Mindestlänge von Rahmen reicht um Kollisionen zu vermeiden.", Answer = false },
        new NetworkingYesNoQuestion
        {
            Text = "Bei bekannter IP-Adresse eines Servers können wir mit dessen Prozessen kommunizieren.",
            Answer = false,
            AlternativeQuestion = new NetworkingYesNoQuestion
            {
                Text = "Bei bekannter IP-Adresse eines Webservers können wir Webseiten anfragen.",
                Answer = true
            }
        },
        new NetworkingYesNoQuestion
        {
            Text = "UDP ist für Videotelefonie besser geeignet als TCP.",
            Answer = true,
            AlternativeQuestion = new NetworkingYesNoQuestion
            {
                Text = "TCP ist für Videotelefonie besser geeignet als UDP.",
                Answer = false
            }
        },
        new NetworkingYesNoQuestion { Text = "Alle Netzwerkgeräte im gleichen physischen Netz empfangen Rahmen mit der Zieladresse FF-FF-FF-FF-FF-FF.", Answer = true },
        new NetworkingYesNoQuestion
        {
            Text = "Die Netzwerktopologie Maschen enthält einen Single Point of Failure.",
            Answer = false,
            AlternativeQuestion = new NetworkingYesNoQuestion
            {
                Text = "Die Netzwerktopologie Bus enthält einen Single Point of Failure.",
                Answer = true
            }
        },
        new NetworkingYesNoQuestion
        {
            Text = "Router untersuchen Rahmen mit Prüfsummen auf Korrektheit.",
            Answer = false,
            AlternativeQuestion = new NetworkingYesNoQuestion
            {
                Text = "Bridges untersuchen Rahmen mit Prüfsummen auf Korrektheit.",
                Answer = true
            }
        },
        new NetworkingYesNoQuestion
        {
            Text = "Bridges vermeiden Kreise mit dem Spanning Tree Protocol.",
            Answer = true,
            AlternativeQuestion = new NetworkingYesNoQuestion
            {
                Text = "Router vermeiden Kreise mit dem Spanning Tree Protocol.",
                Answer = false
            }
        },
        new NetworkingYesNoQuestion
        {
            Text = "Der Leitungscode Non-Return-To-Zero (NRZ) verursacht Probleme bei der Taktwiederherstellung.",
            Answer = true,
            AlternativeQuestion = new NetworkingYesNoQuestion
            {
                Text = "Der Leitungscode Manchester verursacht Probleme bei der Taktwiederherstellung.",
                Answer = false
            }
        },
        new NetworkingYesNoQuestion
        {
            Text = "Gateways in der Vermittlungsschicht von Computernetzen werden häufig eingesetzt.",
            Answer = false,
            AlternativeQuestion = new NetworkingYesNoQuestion
            {
                Text = "Gateways in der Vermittlungsschicht von Computernetzen sind heutzutage selten nötig.",
                Answer = true
            }
        },
        new NetworkingYesNoQuestion
        {
            Text = "Telnet ermöglicht die verschlüsselte Fernsteuerung von Computern.",
            Answer = false,
            AlternativeQuestion = new NetworkingYesNoQuestion
            {
                Text = "Telnet ermöglicht die unverschlüsselte Fernsteuerung von Computern.",
                Answer = true
            }
        },
        new NetworkingYesNoQuestion
        {
            Text = "DHCP ermöglicht die Zuweisung der Netzwerkkonfiguration an Netzwerkgeräte.",
            Answer = true,
            AlternativeQuestion = new NetworkingYesNoQuestion
            {
                Text = "ICMP ermöglicht die Zuweisung der Netzwerkkonfiguration an Netzwerkgeräte.",
                Answer = false
            }
        },
        new NetworkingYesNoQuestion
        {
            Text = "ICMP dient dazu, Diagnose- und Fehlermeldungen auszutauschen.",
            Answer = true,
            AlternativeQuestion = new NetworkingYesNoQuestion
            {
                Text = "DHCP dient dazu, Diagnose- und Fehlermeldungen auszutauschen.",
                Answer = false
            }
        },
        new NetworkingYesNoQuestion
        {
            Text = "Im Ethernet-Rahmen stehen die MAC-Adressen von Sender und Empfänger.",
            Answer = true,
            AlternativeQuestion = new NetworkingYesNoQuestion
            {
                Text = "Im Ethernet-Rahmen stehen die IP-Adressen von Sender und Empfänger.",
                Answer = false
            }
        }
    ];

    private sealed class NetworkingYesNoQuestion : IYesNoQuestion
    {
        public bool Answer { get; set; }

        public string Category { get; set; } = "Networking";

        public QuestionType QuestionType { get; set; } = QuestionType.Single;

        public Choices ChoicesType { get; set; } = Choices.Boolean;

        public Difficulty Difficulty { get; set; } = Difficulty.Medium;

        public string Text { get; set; } = string.Empty;

        public IQuestion AlternativeQuestion { get; set; } = null!;
    }
}
