using System;

namespace Base
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Convert.ToString(Console.ReadLine());
            line = line.Trim();
            startLexicalAnalysis(line);
            Console.WriteLine("----------------------------------");
            startParsing(line);
        }

        static private void startLexicalAnalysis(string line) // лексический анализ строки
        {
            try
            {
                LexicalAnalysis lexer = new LexicalAnalysis(line);
                Token token = lexer.getNextToken(); 

                while (token.getTokenName() != null)
                {
                    Console.WriteLine(token.tokenToString());
                    token = lexer.getNextToken();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
            }
        }

        static private void startParsing(string line) // синтаксический анализ строки
        {
            try
            {
                Parsing parser = new Parsing();
                parser.parsing(line);
                Console.WriteLine("Input: " + line + "\nTree: " + parser.getTree().ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
            }
        }
    }
}