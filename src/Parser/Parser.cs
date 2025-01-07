namespace HashLang.src.Parser{

    public class Parser{

        
        // Parser

        public (string command, List<string> args) ParseTheTokens(List<string> tokens){

            if(tokens.Count == 0){
                throw new Exception("Please , provide input");
            }

            string command = tokens[0];
            var args = tokens.GetRange(1, tokens.Count - 1);

            return (command, args);
        }

    }
}