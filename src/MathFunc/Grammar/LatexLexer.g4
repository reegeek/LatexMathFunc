lexer grammar LatexLexer;

fragment A: [Aa];
fragment B: [Bb];
fragment C: [Cc];
fragment D: [Dd];
fragment E: [Ee];
fragment F: [Ff];
fragment G: [Gg];
fragment H: [Hh];
fragment I: [Ii];
fragment J: [Jj];
fragment K: [Kk];
fragment L: [Ll];
fragment M: [Mm];
fragment N: [Nn];
fragment O: [Oo];
fragment P: [Pp];
fragment Q: [Qq];
fragment R: [Rr];
fragment S: [Ss];
fragment T: [Tt];
fragment U: [Uu];
fragment V: [Vv];
fragment W: [Ww];
fragment X: [Xx];
fragment Y: [Yy];
fragment Z: [Zz];

fragment LOWERCASE : [a-z] ;
fragment UPPERCASE : [A-Z] ;
fragment DIGIT : [0-9] ;

REAL_NUMBER: (MINUS?) (DIGIT+) (([.]DIGIT*)?);
WHITESPACE: (' ' | '\t') -> channel(HIDDEN);
NEWLINE: ('\r'?'\n' | 'r')+;

fragment ASTERISK: '*';
fragment SLASH: '/';
fragment PLUS: '+';
fragment MINUS: '-';

COMMUTATIVE_OPERATOR: ASTERISK | SLASH | PLUS | MINUS;

LP: '(';
RP: ')';
