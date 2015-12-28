using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum MoveGrade {
    Perfect = 0,
    Excellent,
    Good,
    Okay,
    Miss,
    Wrong
}

public class MoveVerifier : MonoBehaviour {

    public Timer timer;
    public LevelPlayer level;
    public GradeTextController gradeText;
    float nextBeatTime;
    List<float> thresholdTimes;
    bool movePlayed;
    bool success;
    MoveGrade moveGrade;

    void Start() {
        success = true;
        movePlayed = false;

        thresholdTimes = new List<float>() {
            00.05f,
            00.08f,
            00.10f,
            00.20f,
            99.00f // magic number
        };
    }

    void Update() {
        if(!success) {
            // omg failed
        }
    }

    public void OnMoveChange(float nextBeat) {
        nextBeatTime = nextBeat;
        if(!level.IsLeading() && !movePlayed && level.CurrentMoveNumber() != 0) {
            // if there was no move played on the last move
            success = false;
            moveGrade = MoveGrade.Miss;
            gradeText.StartText(moveGrade);
        }
        movePlayed = false;
    }

    public void MovePlayed(DogState move) {
        if(!movePlayed) { // only one move per move!
            movePlayed = true;
            float timeDifference = Mathf.Abs(Time.time - nextBeatTime);
            moveGrade = MoveGrade.Perfect;
            while(timeDifference > thresholdTimes[(int)moveGrade]) {
                moveGrade++;
            }

            bool inTime = (int)moveGrade > (int)MoveGrade.Miss;
            bool correctState = move == level.CurrentDogState();
            if(!correctState) {
                moveGrade = MoveGrade.Wrong;
            }

            if(!correctState || !inTime) {
                success = false;
            }

            gradeText.StartText(moveGrade);

        }
    }
}
