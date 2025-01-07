
using HashLang.src.Evaluater;
using HashLang.src.Lexer;
using HashLang.src.Parser;

namespace HashLang
{
    class Program
    {
        static Dictionary<string, object> Variables = new Dictionary<string, object>();
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to HashLang ! Type 'exit' to quit");

            while (true)
            {

                Console.Write("HashLang>>>");
                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    continue;
                }

                if (input.ToLower() == "exit")
                {
                    break;
                }

                try
                {

                    var lexer = new Lexer();
                    var tokens = lexer.SimpleLexer(input);

                    var parser = new Parser();
                    var parse = parser.ParseTheTokens(tokens);

                    Evaluater.Evaluate(parse);

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Something went wrong {ex.Message}");

                }

            }
        }

    }
}