
namespace HashLang{

    class Program{

        static Dictionary<string, object> Variables = new Dictionary<string, object>();
        static void Main(string[] args){

            Console.WriteLine("Welcome to HashLang ! Type 'exit' to quit");

            while(true){

                Console.Write("HashLang>>>");
                var input = Console.ReadLine();
                
                if(string.IsNullOrWhiteSpace(input)){
                    continue;
                }

                if(input.ToLower() == "exit"){
                    break;
                }

                try{

                    var tokens = SimpleLexer(input);
                    var parse = Parser(tokens);

                    Evaluate(parse);

                }
                catch(Exception ex){
                    Console.WriteLine($"Something went wrong {ex.Message}");

                }

            }
        }

        static List<string> SimpleLexer(string input){

            var tokens = new List<string>();

            var currentToken = string.Empty;

            foreach(var ch in input){

                if(char.IsWhiteSpace(ch)){

                    if(!string.IsNullOrEmpty(currentToken)){
                        tokens.Add(currentToken);
                        currentToken = string.Empty;
                    }
                }

                else if(ch == '=' || ch == '+' || ch=='-' || ch=='*' || ch=='/'){

                    if(!string.IsNullOrEmpty(currentToken)){
                        tokens.Add(currentToken);
                        currentToken = string.Empty;
                    }
                    tokens.Add(ch.ToString());
                }
                else{
                    currentToken += ch;
                }


            }

            if(!string.IsNullOrEmpty(currentToken)){
                tokens.Add(currentToken);
            }

            return tokens;
        }

        // Parser

        static (string command, List<string> args) Parser(List<string> tokens){

            if(tokens.Count == 0){
                throw new Exception("Please , provide input");
            }

            string command = tokens[0];
            var args = tokens.GetRange(1, tokens.Count - 1);

            return (command, args);
        }

        // Evaluate the parsed command

        static void Evaluate((string command, List<string> args) parsedInput){

            var command = parsedInput.command;
            var args = parsedInput.args;


            switch(command){

                case "let": 
                
                    if(args.Count < 3 || args[1] != "="){
                        throw new Exception("Invalid Syntax for variable declarion");

                    }


                    var variableName = args[0];

                    var expression = args.GetRange(2, args.Count - 2);

                    var value = EvaluateExpression(expression);
                    Variables[variableName] = value;
                    Console.WriteLine($"Variable '{variableName} set to {value}");


                    break;
                
                case "print":
                    if(args.Count !=1){

                        throw new Exception("Invalid syntax for print");

                    }

                    var printMe = args[0];
                    
                    if(printMe.StartsWith("\"") && printMe.EndsWith("\"")){

                        Console.WriteLine(printMe.Trim('"'));

                    }
                    else if(Variables.ContainsKey(printMe)){

                        Console.WriteLine(Variables[printMe]);
                    }
                    else{
                        throw new Exception($"Undefined variable '{printMe}");
                    }
                    break;

                default:
                    throw new Exception($"Unknown command {command}");

            }
        }

        static int EvaluateExpression(List<string> expression){

            if(expression.Count == 1){

                if(int.TryParse(expression[0], out int value)){
                    return value;
                }

                if(Variables.ContainsKey(expression[0])){
                    return (int)Variables[expression[0]];
                }
            }
            // let y=x+z
            if(expression.Count == 3){

                var left = GetValue(expression[0]);
                var operatorSymbol = expression[1];

                var right = GetValue(expression[2]);

                return operatorSymbol switch{

                    "+" => left + right,
                    "-" => left - right,
                    "*" => left * right,
                    "/" => right != 0 ? left/right : throw new Exception("Zero division error"),
                };
                
            }
            throw new Exception("Invalid expression format");

        }

        static int GetValue(string token){

            if(int.TryParse(token, out int value)){
                return value;
            }

            if(Variables.ContainsKey(token)){
                return (int)Variables[token];
            }

            throw new Exception($"Undefined variable '{token}'");
        }



    }
}