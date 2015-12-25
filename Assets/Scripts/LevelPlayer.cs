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
        if(currentSegment < 4) {
            if(currentMove < 3) {
                currentMove++;
            }
            else if(currentMove == 3) {
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
