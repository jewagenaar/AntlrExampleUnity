using UnityEngine;
using System.Collections;

public class RuntimeScriptable : MonoBehaviour {

	private string _programCode = "mov fwd 3\n";

	private TortoiseProgram _program;

	void Start () 
	{
		_program = TortoiseCompiler.Compile(_programCode);
		StartCoroutine(_program.Run(gameObject));
	}
}
