using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;

using LatexGrammar;

namespace MathFunc
{
    public class LatexExpressionParser
    {
        public void Parse(string latexExpression)
        {
            var charStream = new AntlrInputStream(latexExpression);
            var lexer = new LatexLexer(charStream);
            var tokenStream = new CommonTokenStream(lexer);
            var parser = new LatexParser(tokenStream);
            var tree = parser.rules();
        }
    }
}
