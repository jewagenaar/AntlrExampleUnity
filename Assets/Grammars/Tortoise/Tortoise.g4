grammar Tortoise;

@members 
{
	public TortoiseCompiler Compiler = new TortoiseCompiler();
}

prog : cmd+ ;

cmd : (move | rotate) NEWLINE ;

move : MOV DIR VAL { Compiler.AddMoveCommand($DIR.text, $VAL.text); };

rotate : ROT VAL { Compiler.AddRotateCommand($VAL.text); }; 

MOV : 'mov' ;
ROT : 'rot' ;

DIR : 'fwd' | 'bwd' ;
VAL : INT ;

INT : '-'? ('0'..'9')+ ; 

NEWLINE:'\r'? '\n' ;

WS : [ \t\r\n]+ -> skip ;