using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelNumberUpdater : MonoBehaviour {

    Text levelText;

	void Start () {
	    levelText = GetComponent<Text>();
	}
	
    public void UpdateLevelNumberText(int levelNumber) {
        levelText.text = levelNumber.ToString();
    }
}
