parser grammar LatexParser;

options { tokenVocab=LatexLexer; }

expression	: LP expression RP 													#parenthesisExpression
			| left=expression operator=COMMUTATIVE_OPERATOR right=expression	#commutativeOperatorExpression
			| REAL_NUMBER 														#numberAtomExpression
			;
