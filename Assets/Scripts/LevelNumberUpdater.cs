using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelNumberUpdater : MonoBehaviour {

    Text levelText;
    public Text nextLevelText;

	void Start () {
	    levelText = GetComponent<Text>();
	}
	
    public void UpdateLevelNumberText(int levelNumber) {
        levelText.text = levelNumber.ToString();
        nextLevelText.text = levelNumber.ToString();
    }
}
