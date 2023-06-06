using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


	/*
	Script developed by Nicholas Nitsche for Unity in Unity 2022.3.0 (LTS)
	Feel free to use this as you'd like
	

----Use: In ANY script in this scene, you can either type out all of this: GameObject.FindWithTag("Error").GetComponent<LogErrorScr>().LogError(str, errorType);
	or instead use this: LogErrorScr.LogErrorStatic(str, errorType)
	
	Where "str" is the string you want to be displayed as an error
	and "errorType" is its color: 0 = red, 1 = yellow, and 2 = gray
	
	
----Setup: 
	- If you haven't already, import Text Mesh Pro essentials from the Package Manager
	- Create a Canvas or use one already in use. If  you want it to cover your screen, set its render mode to screen space overlay or camera
	- Create a Text Mesh Pro object inside the canvas
	- Attatch this script to it
	- Create a tag called "Error" and assign it to this object
	- I suggest moving the text object into the upper left corner of the canvas and adjusting the font size as necessary for greater visibility
	*/




public class LogErrorScr : MonoBehaviour
{
	[SerializeField]
	public int maxLines = 10;
	private TextMeshProUGUI thisTMP;
    // Start is called before the first frame update
    void Start()
    {
	    thisTMP = GetComponent<TextMeshProUGUI>();
	    thisTMP.text = "";
	    if (thisTMP == null) {
	    	this.gameObject.AddComponent<TextMeshProUGUI>();
	    	thisTMP = GetComponent<TextMeshProUGUI>();
		    thisTMP.text = "";}
    }

    // Update is called once per frame
    void Update()
	{
		LogErrorScr.LogErrorStatic("error message", 1);
			//LogError("TMPAnimGuide at different index, check playervaluescr", 1);
    }
    
	/// Error is the error to be displayed
	/// Errortype: 0 is red, 1 is yellow, 2 is gray.
	public void LogError(string error, int errorType) {
		string pretext = "";
		if (errorType == 0) pretext = "<color=\"red\">";
		else if (errorType == 1) pretext = "<color=\"yellow\">";
		else if (errorType == 2) pretext = "<color=\"gray\">";
		
		string newText = "<br>" + pretext + error;
		newText = thisTMP.text + newText;
		thisTMP.text = newText;
		int extraLines = thisTMP.textInfo.lineCount-maxLines;
		if (extraLines > 0) {
			newText = deleteLINESinString(newText, extraLines);
			thisTMP.text = newText;
		}
	}
	
	
	
	//hopefully deletes lines in a string appropriately
	string deleteLINESinString (string str, int lines) {
		for (int i = 0; i < lines; i++) {
			str = deleteLineInString(str);
		}
		return str;
	}
	
	string deleteLineInString(string str) {
		int defaultDelete = 20;//deleted 20 chars if thing below doesnt work
		string newString = str;
		for (int i = 0; i < str.Length; i++) {
			if ((str[i] == '<') && (str[i+1] == 'b')) {
				newString = str.Remove(0, i+4);
				return newString;
			}
		}
		newString = str.Remove(0, Mathf.Min(str.Length, defaultDelete));
		return newString;
	}
	
	static public void LogErrorStatic (string str, int errorType) {
		GameObject.FindWithTag("Error").GetComponent<LogErrorScr>().LogError(str, errorType);
	}
}
