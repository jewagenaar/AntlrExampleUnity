using UnityEngine;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using System.Collections;

public class HelloAntlr : MonoBehaviour 
{
	public string Name = "world";

	void Start () 
	{
		AntlrInputStream antlerStream = new AntlrInputStream("hello " + Name);
		HelloLexer lexer = new HelloLexer(antlerStream);
		CommonTokenStream tokenStream = new CommonTokenStream(lexer);
		HelloParser parser = new HelloParser(tokenStream);

		parser.r();
	}
}
