grammar Hello;
r  : 'hello' ID { UnityEngine.Debug.Log("Antlr say: Hello, " + $ID.text); } ;         // match keyword hello followed by an identifier
ID : ([A-Z] | [a-z])+ ;             // match lower-case identifiers
WS : [ \t\r\n]+ -> skip ; // skip spaces, tabs, newlines