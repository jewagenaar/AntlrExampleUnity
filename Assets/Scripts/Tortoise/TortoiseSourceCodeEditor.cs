using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TortoiseSourceCodeEditor : MonoBehaviour {
	
	public Text SourceCodeText;
	public RuntimeScriptable RuntimeScriptableObject;

	public void OnCompileAndRunClick()
	{
		if(RuntimeScriptableObject != null)
		{
			RuntimeScriptableObject.CompileAndRun(SourceCodeText.text);
		}
	}
}
