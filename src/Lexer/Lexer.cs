namespace HashLang.src.Lexer{
    public class Lexer{
        public List<string> SimpleLexer(string input){

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
    }
}