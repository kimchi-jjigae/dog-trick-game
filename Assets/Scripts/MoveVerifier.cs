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
    public MusicBox musicBox;

    public GradeTextController gradeText;
    MoveGrade moveGrade;

    List<float> thresholdTimes;
    float nextBeatTime;
    bool movePlayed;
    bool success;
    bool leading;

    void Start() {
        success = true;
        movePlayed = false;
        leading = true;

        thresholdTimes = new List<float>() {
            00.05f,
            00.08f,
            00.10f,
            00.20f,
            99.00f // magic number :/
        };
    }

    public void OnMoveChange(float beatTime) {
        // don't need to process stuff if leading or if on "break" move
        if(!leading && level.CurrentMoveNumber() != 0) {
            // go through previous move stuff
            if(!movePlayed) { 
                success = false;
                moveGrade = MoveGrade.Miss;
                gradeText.StartText(moveGrade);
            }

            if(!success) {
                level.LevelLost();
                musicBox.Lose();
            }

            // set up new move stuff
            movePlayed = false;
        }
        nextBeatTime = beatTime;
        leading = level.IsLeading();
    }

    public void MovePlayed(DogState move) {
        if(!movePlayed) { // only one move per move!
            movePlayed = true;

            if(move != level.CurrentDogState()) {
                moveGrade = MoveGrade.Wrong;
            }
            else {
                float timeDifference = Mathf.Abs(Time.time - nextBeatTime);
                moveGrade = MoveGrade.Perfect;
                while(timeDifference > thresholdTimes[(int)moveGrade]) {
                    moveGrade++;
                }
            }

            if((int)moveGrade >= (int)MoveGrade.Miss) {
                success = false;
            }

            gradeText.StartText(moveGrade);
        }
    }

    public void StartLevel() {
        leading = true;
        success = true;
        movePlayed = false;
    }
}
