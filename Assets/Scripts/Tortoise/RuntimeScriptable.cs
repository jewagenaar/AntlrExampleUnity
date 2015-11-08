using UnityEngine;
using System.Collections;

public class RuntimeScriptable : MonoBehaviour 
{
	private TortoiseProgram _program;
	private Quaternion _startRotation;
	private Vector3 _startPosition;

	void Start()
	{
		_startRotation = transform.rotation;
		_startPosition = transform.position;
	}


	public void CompileAndRun(string code)
	{
		StopAllCoroutines();
		ResetTransform();
		_program = TortoiseCompiler.Compile(code);
		StartCoroutine(_program.Run(gameObject));
	}


	private void ResetTransform()
	{
		transform.rotation = _startRotation;
		transform.position = _startPosition;
	}
}
