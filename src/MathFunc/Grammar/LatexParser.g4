parser grammar LatexParser;

options { tokenVocab=LatexLexer; }

expression	: LP expression RP 													#parenthesisExpression
			| left=expression operator=COMMUTATIVE_OPERATOR right=expression	#commutativeOperatorExpression
			| POSITIVE_NUMBER													#numberAtomExpression
			| MINUS POSITIVE_NUMBER												#negativeNumberAtomExpression
			;
