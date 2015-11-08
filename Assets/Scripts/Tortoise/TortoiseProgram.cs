using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TortoiseProgram  
{
	#region Program Commands
	public interface Command
	{
		IEnumerator Execute(GameObject gameObject);
	}

	public class MoveCommand : Command
	{
		public enum Direction
		{
			FWD, BWD
		}

		private Direction _direction;
		private float _distance;

		public MoveCommand(Direction direction, float distance)
		{
			_direction = direction;
			_distance = distance;
		}

		public IEnumerator Execute(GameObject gameObject)
		{
			float d = 0f;

			switch(_direction)
			{
				case Direction.FWD: {
					d = _distance;
				} break;
				case Direction.BWD: {
					d = -_distance;
				} break;
			}

			Vector3 v = Vector3.up * d;
			gameObject.transform.Translate(v);

			#if DEBUG
			Debug.Log ("Move " + _direction + " " + _distance);
			#endif

			return null;
		}
	}


	public class RotateCommand : Command
	{
		private float _angle;

		public RotateCommand(float angle)
		{
			_angle = angle;
		}

		public IEnumerator Execute(GameObject gameObject)
		{
			gameObject.transform.Rotate(new Vector3(0, 0, _angle));

			#if DEBUG
			Debug.Log ("Rotate " + _angle);
			#endif

			return null;
		}
	}
	#endregion


	public static float EXECUTION_DELAY = 0.5f;

	private List<Command> _commands;
	private int _pc;

	public TortoiseProgram(List<Command> commands)
	{
		_commands = commands;
		_pc = 0;
	}


	public IEnumerator Run(GameObject gameObject)
	{
		while(_pc < _commands.Count)
		{
			yield return new WaitForSeconds(EXECUTION_DELAY);

			Command nextCommand = _commands[_pc++];
			yield return nextCommand.Execute(gameObject);
		}
	}


	public void Reset()
	{
		_pc = 0;
	}
}
