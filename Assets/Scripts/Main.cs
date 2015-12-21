using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
    
    public int pointsStart;
    public int lifeStart;
    int points;
    int pointsTarget;
    int life;
    int lifeTarget;

	void Start () {
	    points = pointsStart;
        life = lifeStart;
        pointsTarget = 10;
        lifeTarget = 0;
	}
	
	void Update () {
	    if(points == pointsTarget) {
            // game won!
        }

	    if(life == lifeTarget) {
            // game lost!
        }
	}
}
