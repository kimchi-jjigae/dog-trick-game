using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Main : MonoBehaviour {
    
    public Timer timer;
    public LevelPlayer level;
    public LevelNumberUpdater levelText;
    public PointsPopulator points;
    public LifePopulator life;
    public MoveVerifier moveVerifier;
    public GameObject startPanel;
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
        InitialiseValues();
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

    public void RestartGame() {
        InitialiseValues();
        timer.StopTimer();
        startPanel.SetActive(true);
    }

    public void LevelStart() {
        timer.StartTimer();
    }

    public void LevelEnd() {
        timer.StopTimer();
        levelNumber++;
        successPanel.SetActive(true);
        //if(lifeAmount == maxLifeAmount) { then disable the life button }
    }

    public void PointsChosen() {
        pointAmount++;
        successPanel.SetActive(false);
        nextLevelPanel.SetActive(true);
        // pointsAnimation();
        points.Populate(pointAmount, pointsTarget - pointAmount);
    }

    public void LifeChosen() {
        lifeAmount++;
        successPanel.SetActive(false);
        nextLevelPanel.SetActive(true);
        // lifeAnimation();
        life.Populate(lifeAmount, maxLifeAmount - lifeAmount);
    }

    public void LifeLost() {
        timer.StopTimer();
        // lifeLostAnimation();
        lifeAmount--;
        lifeLostPanel.SetActive(true);
        life.Populate(lifeAmount, maxLifeAmount - lifeAmount);
    }

    void InitialiseValues() {
	    pointAmount = pointsStart;
        lifeAmount = lifeStart;
        pointsTarget = 10;
        lifeTarget = 0;
        maxLifeAmount = 3;

        levelNumber = 1;

        points.Populate(pointAmount, pointsTarget - pointAmount);
        life.Populate(lifeAmount, maxLifeAmount - lifeAmount);
    }
}
