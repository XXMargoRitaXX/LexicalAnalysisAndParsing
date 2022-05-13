namespace Base
{
    class Node
    {
        private Token token;
        public Node leftBranch { get; set; } // автоматические свойства
        public Node rightBranch { get; set; }

        public Token getToken() { return token; }

        public Node(Token token) 
        {
            this.token = token;
        }

        public override string ToString() // переопределение метода
        {
            string node = token.getLexeme();

            if (leftBranch != null || rightBranch != null)
            {
                node += "(";

                if (leftBranch != null)
                {
                    node += leftBranch.ToString();
                }

                if (rightBranch != null)
                {
                    node += ", " + rightBranch.ToString();
                }

                node += ")";
            }

            return node;
        }
    }
}