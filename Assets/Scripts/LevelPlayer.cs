﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LevelPlayer : MonoBehaviour {
    public Timer timer;

    List<List<DogState>> level;
    int levelNumber;
    int currentSegment;
    int currentMove;

    bool leading;
    bool paused;

	void Start () {
        level = SpawnNewLevel();

        currentSegment = 0;
        currentMove = 0;
        leading = true;
        paused = false;
	}
	
    public void OnMoveChange() {
        if(!paused) {
            StepThroughLevel();
        }
    }

    void StepThroughLevel() {
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

    List<List<DogState>> SpawnNewLevel() {
        List<List<DogState>> newLevel = new List<List<DogState>>();

        List<DogState> possibleStates = new List<DogState>();
        foreach(DogState state in System.Enum.GetValues(typeof(DogState))) {
            if(state != DogState.Idle) {
                possibleStates.Add(state);
            }
        }

        for(int i = 0; i < 4; ++i) {
            List<DogState> newSegment = new List<DogState>();
            for(int j = 0; j < 3; ++j) {
                int move = Random.Range(0, possibleStates.Count);
                newSegment.Add(possibleStates[move]);
            }
            newSegment.Add(DogState.Idle);
            newLevel.Add(newSegment);
        }
        return newLevel;
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
