using UnityEngine;
using System.Collections.Generic;

/**
 * Just an implementation of the plain old builder design pattern. 
 */
public class TortoiseCompiler
{
	private List<TortoiseProgram.Command> _commands;

	public TortoiseCompiler()
	{
		_commands = new List<TortoiseProgram.Command>();
	}


	public TortoiseCompiler AddMoveCommand(string direction, string distance)
	{
		TortoiseProgram.MoveCommand.Direction dir = TortoiseProgram.MoveCommand.Direction.BWD;
		if(direction.Equals(TortoiseProgram.MoveCommand.Direction.FWD.ToString()))
		{
			dir = TortoiseProgram.MoveCommand.Direction.FWD;
		}

		float dist = float.Parse(distance);

		TortoiseProgram.MoveCommand moveCommand = new TortoiseProgram.MoveCommand(dir, dist);
		_commands.Add(moveCommand);

		return this;
	}


	public TortoiseCompiler AddRotateCommand(string angle)
	{
		float a = float.Parse(angle);
		TortoiseProgram.RotateCommand rotateCommand = new TortoiseProgram.RotateCommand(a);

		_commands.Add(rotateCommand);

		return this;
	}
}
