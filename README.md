# Unity-Error-Logger-Game-Overlay
Unity script that uses Text Mesh Pro to show custom errors warnings you can put in your scripts.
They are seen in a camera overlay canvas from the main camera during the game, so you can test at full screen or see certain error messages more easily than you would in the console.

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
