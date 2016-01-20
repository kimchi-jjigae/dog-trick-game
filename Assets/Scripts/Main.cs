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

    void LevelStart() {
        timer.StartTimer();
    }

    public void NextLevelStartPressed() {
        // nextLevelAnimation();
        levelText.GetComponent<Text>().text = levelNumber.ToString();
        LevelStart();
    }

    public void LevelSuccess() {
        timer.StopTimer();
        levelNumber++;
        // a bit messy, maybe have the text component as a public variable instead:
        nextLevelPanel.transform.GetChild(1).GetComponent<Text>().text = levelNumber.ToString();
        timer.SetBPM(GetSpeedFromLevelNumber());
        successPanel.SetActive(true);
        //if(lifeAmount == maxLifeAmount) { then disable the life button }
    }

    public void PointsChosen() {
        pointAmount++;
        successPanel.SetActive(false);
        // pointsAnimation();
        points.Populate(pointAmount, pointsTarget - pointAmount);
        nextLevelPanel.SetActive(true);
    }

    public void LifeChosen() {
        lifeAmount++;
        successPanel.SetActive(false);
        // lifeAnimation();
        life.Populate(lifeAmount, maxLifeAmount - lifeAmount);
        nextLevelPanel.SetActive(true);
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

    float GetSpeedFromLevelNumber() {
        // kinda arbitrary, we'll see how it goes

        int speedNumber = levelNumber % 4;

        if(speedNumber == 0) {
            speedNumber = 4;
        }
        if(levelNumber > 20) {
            int additionFactor = (levelNumber - 17) / 4;
            speedNumber += additionFactor;
        }

        return 60.0f + (20.0f * (speedNumber - 1));
    }
}
