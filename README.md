# AntlrExampleUnity


## What?

This is an example project that shows how to get a scripting language created with Antlr running in Unity. There is also a little demo scene (Assets/Scenes/TortoiseScene) that demonstrates how this can be used in a game.

## Why?

There are a lot of cool games out there that use coding as part of the gameplay (my current favourites are **else Heart.Break()** and **Hack&Slash**). I thought it might be fun/usefull to try and get a simple Antlr grammar running in Unity that can be used to manipulate the GameObjects in runtime.

## How?

The first step will be to install Antlr (which is dependent on Java, so if you haven't got that installed that's probably the *actual* first step). 

```
$ cd /usr/local/lib
$ curl -O http://www.antlr.org/download/antlr-4.5-complete.jar
$ export CLASSPATH=".:/usr/local/lib/antlr-4.5-complete.jar:$CLASSPATH"
$ alias antlr4='java -Xmx500M -cp "/usr/local/lib/antlr-4.5-complete.jar:$CLASSPATH" org.antlr.v4.Tool'
```

Next, you need to grab the C# runtime from [here](http://www.antlr.org/download/antlr-csharp-runtime-4.5.1.zip), unzip it and drag and drop it into your Unity project.

Then, create an Antlr grammar file name "Hello.g4" in your Assets folder, and copy & paste the following in:

```
grammar Hello;
r  : 'hello' ID { UnityEngine.Debug.Log("Antlr say: Hello, " + $ID.text); } ;  // match keyword hello followed by an identifier
ID : ([A-Z] | [a-z])+ ; // match lower-case identifiers
WS : [ \t\r\n]+ -> skip ; // skip spaces, tabs, newlines
```

Save it and then generate the C# source files by running the following command in your terminal:

```
antlr4 -Dlanguage=CSharp Hello.g4
```

Lastly, create a new GameObject in your Unity scene, add a new script named "HelloAntlr" to it and copy & paste in the following:

```csharp
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
```

Clicking the Play button in Unity should now display the line "Antlr say: Hello, World" in the console.
 
## What is Tortoise?

Tortoise is a demo scene that shows how scripting langauge created with Antlr can be used in a Unity game. The language is used to move the Tortoise sprite around the screen in runtime. It is a very simple language with only two commands: move and rotate. An example script:


```
mov fwd 3
rot -20
mov fwd 2
```

Have fun!
