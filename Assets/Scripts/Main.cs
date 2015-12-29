using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Main : MonoBehaviour {
    
    public Timer timer;
    public LevelPlayer level;
    public LevelNumberUpdater levelText;
    public PointsPopulator points;
    public LifePopulator life;
    public GameObject successPanel;
    public GameObject nextLevelPanel;
    public GameObject lifeLostPanel;

    public int pointsStart;
    public int lifeStart;
    int pointAmount;
    int pointsTarget;
    int lifeAmount;
    int lifeTarget;
    int maxLifeAmount;

    int levelNumber;

	void Start () {
	    pointAmount = pointsStart;
        lifeAmount = lifeStart;
        pointsTarget = 10;
        lifeTarget = 0;
        maxLifeAmount = 3;

        levelNumber = 1;

        points.Populate(pointAmount, pointsTarget);
        life.Populate(lifeAmount, lifeTarget);
	}
	
	void Update () {
	    if(pointAmount == pointsTarget) {
            // game won!
        }

	    if(lifeAmount == lifeTarget) {
            // game lost!
        }
	}

    public void PauseGame() {
        Time.timeScale = 0.0f;
    }

    public void UnpauseGame() {
        Time.timeScale = 1.0f;
    }

    public void LevelEnd() {
        timer.TogglePause();
        levelNumber++;
        successPanel.SetActive(true);
        //if(lifeAmount == maxLifeAmount) { then disable the life button }

        /* need to fix these and clear the old points/lives first
        points.Populate(pointAmount, pointsTarget);
        life.Populate(lifeAmount, lifeTarget);
        */
    }

    public void LevelStart() {
        levelText.UpdateLevelNumberText(levelNumber);
        timer.TogglePause();
        level.TogglePause();
    }

    public void PointsChosen() {
        pointAmount++;
        successPanel.SetActive(false);
        nextLevelPanel.SetActive(true);
        // pointsAnimation();
    }

    public void LifeChosen() {
        lifeAmount++;
        successPanel.SetActive(false);
        nextLevelPanel.SetActive(true);
        // lifeAnimation();
    }

    public void LifeLost() {
        timer.TogglePause();
        lifeLostPanel.SetActive(true);
    }
}
