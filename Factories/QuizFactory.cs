using System.Collections.Generic;
using SimpleEchoBot.Models;

namespace SimpleEchoBot.Factories
{
    public static class QuizFactory
    {
        public static List<QuestionModel> GeneralQuestions { get; } = new List<QuestionModel>()
        {
            new QuestionModel()
            {
                Text = "Qual das afirmações NÃO é verdadeira?\n" +
                "I - Intolerância religiosa é um crime de ódio.\n" +
                "II - A intolerância religiosa não é crime no Brasil.\n" +
                "III - Intolerância religiosa é cometer atos de vandalismo contra os templos de outras religiões.",
                Answers = new List<string>()
                {
                    "I",
                    "II",
                    "III"
                },
                CorrectAnswer = "II"
            },
            new QuestionModel()
            {
                Text = "Quais o país que possui a maior população carcerária do mundo?",
                Answers = new List<string>()
                {
                    "Brasil",
                    "China",
                    "Estados Unidos",
                },
                CorrectAnswer = "Estados Unidos"
            },
            new QuestionModel()
            {
                Text =
                    "Qual foi a revolução que alavancou a independência do Brasil e em 2017 completou o segundo centenário?",
                Answers = new List<string>()
                {
                    "Revolução Pernambucana",
                    "Revolução Farroupilha",
                    "Revolução Federalista",
                },
                CorrectAnswer = "Revolução Pernambucana"
            },
            new QuestionModel()
            {
                Text = "Qual o tema central do Acordo de Paris?",
                Answers = new List<string>()
                {
                    "Restrição de imigrantes",
                    "Desenvolvimento Sustentável",
                    "Aquecimento global"
                },
                CorrectAnswer = "Aquecimento global"
            },
            new QuestionModel()
            {
                Text = "Qual o acontecimento completou 100 em 2017?",
                Answers = new List<string>()
                {
                    "Revolução Russa",
                    "Revolta da Sabinada",
                    "Nascimento de Frida Khalo"
                },
                CorrectAnswer = "Revolução Russa"
            },
            new QuestionModel()
            {
                Text = "Qual a primeira mulher a ganhar um prêmio Nobel?",
                Answers = new List<string>()
                {
                    "Elizabeth Blackweel",
                    "Marie Curie",
                    "Valentina Tereshkova"
                },
                CorrectAnswer = "Marie Curie"
            },
            new QuestionModel()
            {
                Text =
                    "Chernobyl faz parte de um dos maiores acidentes nucleares da história. Em que país acorreu?",
                Answers = new List<string>()
                {
                    "Rússia",
                    "Ucrânia",
                    "Alemanha"
                },
                CorrectAnswer = "Ucrânia"
            },
            new QuestionModel()
            {
                Text = "Qual a doença sexualmente transmissível que virou surto no Brasil em 2017?",
                Answers = new List<string>()
                {
                    "Sífilis",
                    "Hepatite B",
                    "Candidíase"
                },
                CorrectAnswer = "Sífilis"
            },
            new QuestionModel()
            {
                Text =
                    "Como forma de resistir às tradições do Halloween, qual a data comemorativa foi instituída no Brasil para ser celebrada no dia 31 de outubro?",
                Answers = new List<string>()
                {
                    "Dia das bruxas",
                    "Dia do folclore",
                    "Dia do Saci"
                },
                CorrectAnswer = "Dia do Saci"
            },
            new QuestionModel()
            {
                Text = "Em que país se localizava Auschwitz, o maior campo de concentração nazi?",
                Answers = new List<string>()
                {
                    "Alemanha",
                    "Polônia",
                    "Áustria"
                },
                CorrectAnswer = "Polônia"
            },
            new QuestionModel()
            {
                Text = "Qual o nome do presidente do Brasil que ficou conhecido como Jango?",
                Answers = new List<string>()
                {
                    "João Goulart",
                    "Jânio Quadros",
                    "Getúlio Vargas"
                },
                CorrectAnswer = "João Goulart"
            },
            new QuestionModel()
            {
                Text = "Atualmente, quantos elementos químicos a tabela periódica possui?",
                Answers = new List<string>()
                {
                    "113",
                    "108",
                    "118"
                },
                CorrectAnswer = "118"
            },
            new QuestionModel()
            {
                Text = "Quanto tempo a luz do Sol demora para chegar à Terra?",
                Answers = new List<string>()
                {
                    "12 minutos",
                    "8 minutos",
                    "Segundos"
                },
                CorrectAnswer = "8 minutos"
            },
            new QuestionModel()
            {
                Text = "Que líder mundial ficou conhecida como “Dama de Ferro”?",
                Answers = new List<string>()
                {
                    "Dilma Rousseff",
                    "Angela Merkel",
                    "Margaret Thatcher"
                },
                CorrectAnswer = "Margaret Thatcher"
            },
            new QuestionModel()
            {
                Text =
                    "Jean Jacques Dessalines foi o governante de qual país?",
                Answers = new List<string>()
                {
                    "França",
                    "Haiti",
                    "Moçambique"
                },
                CorrectAnswer = "Haiti"
            },
            new QuestionModel()
            {
                Text =
                    "Durante quantos anos Fidel Castro, um dos governantes que esteve mais tempo no poder, esteve à frente de Cuba?",
                Answers = new List<string>()
                {
                    "43 anos",
                    "46 anos",
                    "49 anos"
                },
                CorrectAnswer = "49 anos"
            },
            new QuestionModel()
            {
                Text = "Qual presidente brasileiro sancionou a lei das cotas para o ensino superior?",
                Answers = new List<string>()
                {
                    "Fernando Henrique",
                    "Lula da Silva",
                    "Dilma Rousseff"
                },
                CorrectAnswer = "Dilma Rousseff"
            }
        };

        public static List<QuestionModel> NetworkingQuestions { get; } = new List<QuestionModel>()
        {
            new QuestionModel()
            {
                Text = "Qual a camada do modelo OSI em que o FTP e o HTTP operam?",
                Answers = new List<string>()
                {
                    "Aplicação",
                    "Apresentação",
                    "Transporte"
                },
                CorrectAnswer = "Aplicação"
            },
            new QuestionModel()
            {
                Text = "É correto afirmar sobre o APACHE:\n" +
                    "I - Faz a função de servidor e proxy\n" +
                    "II - Funciona em Linux, Windows e MAC OS\n" +
                    "III - Só funciona em Linux",
                Answers = new List<string>()
                {
                    "I",
                    "II",
                    "III"
                },
                CorrectAnswer = "II"
            },
            new QuestionModel()
            {
                Text = "Qual das arquiteturas abaixo é mais vulnerável ao roubo de dados com “Man in the Middle”?",
                Answers = new List<string>()
                {
                    "Cliente-Servidor",
                    "Perimetral", 
                    "Peer-to-peer"
                },
                CorrectAnswer = "Peer-to-peer"
            },
            new QuestionModel()
            {
                Text = "Para conectar sua estação de trabalho a uma rede local de computadores controlada por um servidor de domínios, o usuário dessa rede deve informar uma senha e um[a]:",
                Answers = new List<string>()
                {
                    "Porta válida",
                    "Conta cadastrada",
                    "Certificação"
                },
                CorrectAnswer = "Conta cadastrada"
            },
            new QuestionModel()
            {
                Text = "No padrão de endereçamento IPv4, que utiliza 32 bits, a quantidade de bits reservada para identificar os computadores (hosts) em uma rede Classe A é:",
                Answers = new List<string>()
                {
                    "12",
                    "20",
                    "24"
                },
                CorrectAnswer = "24"
            },
            new QuestionModel()
            {
                Text = "O padrão de endereçamento IPv4 estabelece alguns valores de endereços reservados. Dentre os IPs apresentados, assinale a alternativa que seleciona o reservado para identificar o localhost.",
                Answers = new List<string>()
                {
                    "10.10.10.10",
                    "127.0.0.1",
                    "192.168.0.1"
                },
                CorrectAnswer = "127.0.0.1"
            },
            new QuestionModel()
            {
                Text = "Um dos problemas atuais na Internet é o esgotamento do espaço de endereçamento do IPv4. Para resolver esse problema, no IPv6, os endereços passaram a ter tamanho de:",
                Answers = new List<string>()
                {
                    "32 bits",
                    "128 bits",
                    "256 bits"
                },
                CorrectAnswer = "128 bits"
            },
            new QuestionModel()
            {
                Text = "Qual das alternativas abaixo é verdadeira sobre IPv6?\n" +
                    "I - Protocolo de endereçamento IP que possui 128 bits (ou 16 bytes)\n" +
                    "II - Protocolo de endereçamento IP que inclui funções de roteamento dinâmico\n" +
                    "III - Protocolo de endereçamento IP para aplicações apenas em redes locais",
                Answers = new List<string>()
                {
                    "I",
                    "II",
                    "III"
                },
                CorrectAnswer = "I"
            },
            new QuestionModel()
            {
                Text = "Sobre a operação Ethernet full-duplex é correto afirmar que:\n" +
                    "I - No modo full-duplex pode ocorrer colisão de dados entre o PC e o switch\n" +
                    "II - Dois métodos de realizar o modo full-duplex são por auto-negociação e por configuração administrativa\n" +
                    "III - Todas as implementações de Ethernet podem tanto o half-duplex como o full-duplex",
                Answers = new List<string>()
                {
                    "I",
                    "II",
                    "III"
                },
                CorrectAnswer = "II"
            },
            new QuestionModel()
            {
                Text = "Qual das seguintes funções abaixo é verdadeira em relação ao TCP/IP?\n" +
                    "I - Realiza o encapsulamento do quadro\n" +
                    "II - Faz a definição do melhor caminho\n" +
                    "III -Faz o controle de fluxo de dados e garantia de entrega",
                Answers = new List<string>()
                {
                    "I",
                    "II",
                    "III"
                },
                CorrectAnswer = "III"
            }
        };
    }
}
