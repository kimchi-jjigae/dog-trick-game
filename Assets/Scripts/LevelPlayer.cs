using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelPlayer : MonoBehaviour {
    public Timer timer;
    public MusicBox musicBox;
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
                DogState.Bark
            },
            new List<DogState>{
                DogState.Sit,
                DogState.Sit,
                DogState.Sit
            },
            new List<DogState>{
                DogState.Bark,
                DogState.Sit,
                DogState.Bark
            },
            new List<DogState>{
                DogState.Sit,
                DogState.Bark,
                DogState.Sit
            }
        };

        currentSegment = 0;
        currentMove = 0;
        leading = true;
	}
	
    public void OnBeat() {
        if(currentSegment < 4) {
            if(currentMove < 3) {
                DogState move = level[currentSegment][currentMove];
                leader.state = move;
                musicBox.Kick();
                currentMove++;
            }
            else if(currentMove == 3) {
                // pause! //
                musicBox.HighHat();
                currentSegment++;
                currentMove = 0;
            }
        }
    }
}
