namespace Base
{
    class Token
    {
        private string tokenName;
        private string lexeme;

        public Token (string tokenName, string lexeme)
        {
            this.tokenName = tokenName;
            this.lexeme = lexeme;
        }

        public string getTokenName()
        {
            return tokenName;
        }

        public string getLexeme()
        {
            return lexeme;
        }

        public string tokenToString()
        {
            return ("(" + tokenName + ", " + lexeme + ")");
        }
    }
}