using UnityEngine;
using System.Collections;

public class MoveVerifier : MonoBehaviour {

    public Timer timer;
    public LevelPlayer level;
    float nextBeatTime;
    float timeThreshold;
    bool movePlayed;
    bool success;

    void Start() {
        success = true;
        timeThreshold = 0.2f;
        //movePlayed = false;
    }

    void Update() {
        if(!success) {
            // omg failed
        }
    }

    public void OnMoveChange(float nextBeat) {
        nextBeatTime = nextBeat;
        if(!level.IsLeading() && !movePlayed) {
            // if there was no move played on the last move
            success = false;
        }
        movePlayed = false;
    }

    public void MovePlayed(DogState move) {
        if(!movePlayed) { // only one move per move!
            movePlayed = true;
            bool correctState = move == level.CurrentDogState();
            bool inTime = Mathf.Abs(Time.time - nextBeatTime) < timeThreshold;

            if(!correctState || !inTime) {
                success = false;
            }
        }
    }
}
