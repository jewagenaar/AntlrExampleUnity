grammar Tortoise;

prog : cmd+ ;

cmd : (move | rotate) NEWLINE ;

move : MOV DIR VAL ;

rotate : ROT VAL ; 

MOV : 'mov' ;
ROT : 'rot' ;

DIR : 'fwd' | 'bwd' ;
VAL : INT ;

INT : '-'? ('0'..'9')+ ; 

NEWLINE:'\r'? '\n' ;

WS : [ \t\r\n]+ -> skip ;