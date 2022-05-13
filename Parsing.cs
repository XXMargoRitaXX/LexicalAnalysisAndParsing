using System;

namespace Base
{
    class Parsing
    {
        private Token token;
        private LexicalAnalysis lexer;
        private Node tree = null;

        public Node getTree()
        {
            return tree;
        }

        public void parsing(string line) {

            line = line.Trim();

            if (line != "")
            {
                lexer = new LexicalAnalysis(line);
                token = lexer.getNextToken();
                tree = E();
            }
            else
            {
                throw new Exception("Арифметическое выражение отсутствует");
            }
        }

        private Node nextToken(string checkLexem)
        {
            string tokenLexem = token.getLexeme();

            if (tokenLexem != null && compStr(tokenLexem, checkLexem))
            {
                Node node = new Node(token);
                token = lexer.getNextToken();
                return node;
            }
            else
            {
                throw new Exception("Неверное арифметическое выражение");
            }
        }

        private bool compStr(string str1, string str2)
        {
            if (string.Compare(str1, str2) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Node E()
        {
            Node node1 = T();
            Node node2 = E1();

            if (node2 != null && compStr(node2.getToken().getTokenName(),"Operator"))
            {
                node2.leftBranch = node1;
                node1 = node2;
            }

            return node1;
        }

        private Node E1()
        {
            Node node = null;
            string tokenLexem = token.getLexeme();
            string tokenName = token.getTokenName();

            if (compStr(tokenName, "Operator") && compStr(tokenLexem, "+") || compStr(tokenLexem, "-"))
            {
                node = nextToken(tokenLexem);
                node.rightBranch = E();
            }

            return node;
        }

        private Node T()
        {
            Node node1 = F();
            Node node2 = T1();

            if (node2 != null && compStr(node2.getToken().getTokenName(), "Operator"))
            {
                node2.leftBranch = node1;
                node1 = node2;
            }

            return node1;
        }

        private Node T1()
        {
            Node node = null;
            string tokenLexem = token.getLexeme();
            string tokenName = token.getTokenName();

            if (compStr(tokenName, "Operator") && compStr(tokenLexem, "*")
                || compStr(tokenLexem, "/"))
            {
                node = nextToken(tokenLexem);
                node.rightBranch = T();
            }

            return node;
        }

        private Node F()
        {
            Node node1 = V();
            Node node2 = F1();

            if (node2 != null && compStr(node2.getToken().getTokenName(), "Operator"))
            {
                node2.leftBranch = node1;
                node1 = node2;
            }

            return node1;
        }

        private Node F1()
        {
            Node node = null;
            string tokenLexem = token.getLexeme();
            string tokenName = token.getTokenName();

            if (compStr(tokenName, "Operator") && compStr(tokenLexem, "^"))
            {
                node = nextToken(tokenLexem);
                node.rightBranch = F();
            }

            return node;
        }

        private Node V()
        {
            Node node = null;
            string tokenLexem = token.getLexeme();
            string tokenName = token.getTokenName();

            if (compStr(tokenName, "LParen"))
            {
                nextToken(tokenLexem);
                node = E();
                nextToken(")");
            }
            else if (compStr(tokenName, "Identifier") || compStr(tokenName, "Number"))
            {
                node = nextToken(tokenLexem);
            }
            else if (compStr(tokenName, "Operator") && compStr(tokenLexem, "-"))
            {
                node = nextToken(tokenLexem);
                node.leftBranch = V();
            }
            else
            {
                throw new Exception("Неверное арифметическое выражение");
            }

            return node;
        }
    }
}