using UnityEngine;
using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using System.Collections.Generic;

#region Aliases
using MoveCommand = TortoiseProgram.MoveCommand;
using MoveDirection = TortoiseProgram.MoveCommand.Direction;
using RotateCommand = TortoiseProgram.RotateCommand;
#endregion

/**
 * Just an implementation of the plain old builder design pattern. 
 */
public class TortoiseCompiler
{
	private List<TortoiseProgram.Command> _commands;
	private List<TortoiseProgram.Command> Commands
	{
		get
		{
			return _commands;
		}
	}


	public TortoiseCompiler()
	{
		_commands = new List<TortoiseProgram.Command>();
	}


	public static TortoiseProgram Compile(string source)
	{
		AntlrInputStream antlerStream = new AntlrInputStream(source);
		TortoiseLexer lexer = new TortoiseLexer(antlerStream);
		CommonTokenStream tokenStream = new CommonTokenStream(lexer);
		TortoiseParser parser = new TortoiseParser(tokenStream);	

		parser.prog();

		TortoiseCompiler compiler = parser.Compiler;

		TortoiseProgram program = new TortoiseProgram(compiler.Commands);

		return program;
	}


	public TortoiseCompiler AddMoveCommand(string direction, string distance)
	{
		MoveDirection dir = MoveDirection.BWD;
		string fwdString = Enum.GetName(typeof(MoveDirection), MoveDirection.FWD);

		if(direction.ToUpper().Equals(fwdString))
		{
			dir = MoveDirection.FWD;
		}

		float dist = float.Parse(distance);

		MoveCommand moveCommand = new MoveCommand(dir, dist);
		_commands.Add(moveCommand);

		return this;
	}


	public TortoiseCompiler AddRotateCommand(string angle)
	{
		float a = float.Parse(angle);
		RotateCommand rotateCommand = new RotateCommand(a);

		_commands.Add(rotateCommand);

		return this;
	}
}
