using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
    
    public Timer timer;
    public LevelNumberUpdater levelText;
    public PointsPopulator points;
    public LifePopulator life;

    public int pointsStart;
    public int lifeStart;
    int pointAmount;
    int pointsTarget;
    int lifeAmount;
    int lifeTarget;

    int levelNumber;

	void Start () {
	    pointAmount = pointsStart;
        lifeAmount = lifeStart;
        pointsTarget = 10;
        lifeTarget = 0;

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

    public void LevelEnd() {
        timer.TogglePause();
        levelNumber++;
    }

    public void LevelStart() {
        levelText.UpdateLevelNumberText(levelNumber);
    }
}
