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
                Text = "Qual das afirmações NÃO é verdadeira?",
                Answers = new List<string>()
                {
                    "Intolerância religiosa é um crime de ódio.",
                    "A intolerância religiosa não é crime no Brasil.",
                    "Intolerância religiosa é cometer atos de vandalismo contra os templos de outras religiões."
                },
                CorrectAnswer = "A intolerância religiosa não é crime no Brasil."
            },
            new QuestionModel()
            {
                Text = "Quais os quatros países que têm a maior população carcerária do mundo?",
                Answers = new List<string>()
                {
                    "Brasil, Estados Unidos, México e Índia",
                    "China, Estados Unidos, Índia e Indonésia",
                    "Estados Unidos, China, Rússia e Brasil",
                },
                CorrectAnswer = "Estados Unidos, China, Rússia e Brasil"
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
                Text = "O que é Brexit?",
                Answers = new List<string>()
                {
                    "Saída do Reino Unido da Zona Euro",
                    "Saída do Reino Unido da União Europeia",
                    "Mudança do sistema de governo no Reino Unido"
                },
                CorrectAnswer = "Saída do Reino Unido da União Europeia"
            },
            new QuestionModel()
            {
                Text = "O que é o Acordo de Paris?",
                Answers = new List<string>()
                {
                    "Acordo internacional que trata da restrição de imigrantes em Paris",
                    "Acordo internacional que trata do Desenvolvimento Sustentável",
                    "Acordo internacional que trata do aquecimento global"
                },
                CorrectAnswer = "Acordo internacional que trata do aquecimento global"
            },
            new QuestionModel()
            {
                Text = "Quais os acontecimentos completaram 100 e 500 anos respectivamente em 2017?",
                Answers = new List<string>()
                {
                    "Revolução Russa e Reforma Protestante",
                    "Revolução Pernambucana e Revolta da Sabinada",
                    "Centenário do nascimento de Frida Khalo e Início do Classicismo"
                },
                CorrectAnswer = "Revolução Russa e Reforma Protestante"
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
                    "Chernobyl e Césio-137 fazem parte dos maiores acidentes nucleares da história. Em que países aconteceram?",
                Answers = new List<string>()
                {
                    "Rússia e Espanha",
                    "Ucrânia e Brasil",
                    "Taiwan e Alemanha"
                },
                CorrectAnswer = "Ucrânia e Brasil"
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
                Text = "Qual a função da ONU?",
                Answers = new List<string>()
                {
                    "Zelar pela cultura em todas as nações",
                    "Unir as nações com o objetivo de manter a paz e a segurança mundial",
                    "Gerenciar acordos de comércio entre os países"
                },
                CorrectAnswer = "Unir as nações com o objetivo de manter a paz e a segurança mundial"
            },
            new QuestionModel()
            {
                Text =
                    "Mao Tsé-tung, Jean Jacques Dessalines e Nelson Mandela foram respectivamente os governantes de quais países?",
                Answers = new List<string>()
                {
                    "Japão, França e Angola",
                    "China, Haiti e África do Sul",
                    "Taiwan, Bélgica, Moçambique"
                },
                CorrectAnswer = "China, Haiti e África do Sul"
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
                Text = "Em que governo brasileiro foi sancionada a lei das cotas para o ensino superior?",
                Answers = new List<string>()
                {
                    "Governo de Fernando Henrique",
                    "Governo de Luís Inácio Lula da Silva",
                    "Governo de Dilma Rousseff"
                },
                CorrectAnswer = "Governo de Dilma Rousseff"
            },
            new QuestionModel()
            {
                Text = "Quais as consequências para o Brasil decorrentes da crise na Venezuela?",
                Answers = new List<string>()
                {
                    "Sobrecarregamento no sistema público de saúde em Roraima",
                    "Aumento de mão de obra",
                    "Melhoria nos serviços sociais a fim de atender os imigrantes venezuelanos"
                },
                CorrectAnswer = "Sobrecarregamento no sistema público de saúde em Roraima"
            },
            new QuestionModel()
            {
                Text = "Quais as respectivas cores da reciclagem do papel, do vidro, do metal e do plástico?",
                Answers = new List<string>()
                {
                    "azul, verde, amarelo e vermelho",
                    "verde, azul, vermelho e amarelo",
                    "vermelho, amarelo, verde e azul",
                },
                CorrectAnswer = "azul, verde, amarelo e vermelho"
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
                Text = "É correto afirmar sobre o APACHE:",
                Answers = new List<string>()
                {
                    "Faz a função de servidor e proxy",
                    "Funciona em Linux, Windows e MAC OS",
                    "Só funciona em Linux"
                },
                CorrectAnswer = "Funciona em Linux, Windows e MAC OS"
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
                    "Porta válida para a intranet desse domínio",
                    "Conta cadastrada e autorizada nesse domínio",
                    "certificação de navegação segura registrada na intranet"
                },
                CorrectAnswer = "Conta cadastrada e autorizada nesse domínio"
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
                Text = "Qual das alternativas abaixo é verdadeira sobre IPv6?",
                Answers = new List<string>()
                {
                    "Protocolo de endereçamento IP que possui 128 bits (ou 16 bytes)",
                    "Protocolo de endereçamento IP que inclui funções de roteamento dinâmico",
                    "Protocolo de endereçamento IP para aplicações apenas em redes locais"
                },
                CorrectAnswer = "Protocolo de endereçamento IP que possui 128 bits (ou 16 bytes)"
            },
            new QuestionModel()
            {
                Text = "Sobre a operação Ethernet full-duplex é correto afirmar que:",
                Answers = new List<string>()
                {
                    "No modo full-duplex pode ocorrer colisão de dados entre o PC e o switch",
                    "Dois métodos de realizar o modo full-duplex são por auto-negociação e por configuração administrativa",
                    "Todas as implementações de Ethernet podem tanto o half-duplex como o full-duplex"
                },
                CorrectAnswer = "Dois métodos de realizar o modo full-duplex são por auto-negociação e por configuração administrativa"
            },
            new QuestionModel()
            {
                Text = "Qual das seguintes funções abaixo é verdadeira em relação ao TCP/IP?",
                Answers = new List<string>()
                {
                    "Realiza o encapsulamento do quadro",
                    "Faz a definição do melhor caminho",
                    "Faz o controle de fluxo de dados e garantia de entrega"
                },
                CorrectAnswer = "Faz o controle de fluxo de dados e garantia de entrega"
            }
        };
    }
}
