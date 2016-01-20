using UnityEngine;
using System.Collections;

public class HackDebugger : MonoBehaviour {

    public LevelPlayer level;
    public string successButton;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(successButton)) {
            level.LevelSuccess();
        }
	}
}
