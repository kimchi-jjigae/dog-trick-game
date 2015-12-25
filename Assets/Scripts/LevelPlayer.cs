using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelPlayer : MonoBehaviour {
    public Timer timer;
    public DogStateChanger leader;
    public DogStateChanger dog;

    List<List<DogState>> level;
    int levelNumber;
    int currentSegment;
    int currentMove;

    bool leading;

	void Start () {
        level = new List<List<DogState>>{
            new List<DogState>{
                DogState.Bark,
                DogState.Bark,
                DogState.Bark,
                DogState.Idle
            },
            new List<DogState>{
                DogState.Sit,
                DogState.Sit,
                DogState.Sit,
                DogState.Idle
            },
            new List<DogState>{
                DogState.Bark,
                DogState.Sit,
                DogState.Bark,
                DogState.Idle
            },
            new List<DogState>{
                DogState.Sit,
                DogState.Bark,
                DogState.Sit,
                DogState.Idle
            }
        };

        currentSegment = 0;
        currentMove = 0;
        leading = true;
	}
	
    public void OnBeat() {
        // goes through the current level! //
        if(currentSegment < 4) {
            if(currentMove < 3) {
                currentMove++;
            }
            else if(currentMove == 3 && leading) {
                // goes through all the moves
                // again, but as a non leader
                leading = false;
                currentMove = 0;
            }
            else if(currentMove == 3 && !leading) {
                // switches back to leading mode
                // and onto the next segment
                leading = true;
                currentSegment++;
                currentMove = 0;
            }
        }
    }

    public bool IsLeading() {
        return leading;
    }

    public int CurrentMoveNumber() {
        return currentMove;
    }

    public DogState CurrentDogState() {
        return level[currentSegment][currentMove];
    }
}
