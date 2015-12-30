using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {
    
    // classes the Timer sends its time updates to: //
    public SliderValueUpdater sliderValueUpdater;
    public ParticleController particleController;
    public MusicBox musicBox;
    public LeaderController leader;
    public DogController dog;
    public MoveVerifier moveVerifier;
    public LevelPlayer levelPlayer;

    // timing variables //
    public float beatsPerMinute;
    float startTime;
    float beatLength;
    float halfBeatLength;
    float lastBeatTime;
    float nextBeatTime;
    float nextMoveTime;

    int beatNumber;
    int moveNumber;
    bool paused;

	void Start () {
        beatLength = 60.0f / beatsPerMinute;
        halfBeatLength = 30.0f / beatsPerMinute;
        
        paused = true;
	}
	
	void Update () {
        if(!paused) {
            sliderValueUpdater.OnTimerUpdate(BeatPosPercent());

            if(OnBeat()) { // every thud
                beatNumber++;
                lastBeatTime = nextBeatTime;
                nextBeatTime = GetNextBeatTime();

                particleController.OnBeat();
                musicBox.OnBeat();
                leader.OnBeat();
                dog.OnBeat();
            }
            else if(OnMoveChange()) { // should be a half-beat's length before OnBeat()
                moveNumber++;
                nextMoveTime = GetNextMoveTime();

                if(moveNumber != 1) {
                    // does not increment the first time
                    levelPlayer.OnMoveChange(); 
                }
                moveVerifier.OnMoveChange(nextBeatTime); 
            }
        }
	}

    float BeatPosPercent() {
        // get beat position between 0.0f and 1.0f //
        float timeSinceLastBeat = Time.time - lastBeatTime;
        float predictedBeatLength = nextBeatTime - lastBeatTime;
        return timeSinceLastBeat / predictedBeatLength;
    }

    bool OnBeat() {
        return Time.time > nextBeatTime;
    }

    bool OnMoveChange() {
        return Time.time > nextMoveTime;
    }

    float GetNextBeatTime() {
        return startTime + (beatNumber + 1) * beatLength;
    }

    float GetNextMoveTime() {
        return startTime + (moveNumber * beatLength) + halfBeatLength;
    }

    public void StartLevel() {
        paused = false;

        beatNumber = 0; // _not_ off by one; the
        moveNumber = 0; // first beat/move is 1

        startTime = Time.time;
        lastBeatTime = startTime;
        nextBeatTime = GetNextBeatTime();
        nextMoveTime = GetNextMoveTime();

        sliderValueUpdater.RestartValue();
    }

    public void PauseTimer() {
        paused = true;
    }

    public void TogglePause() {
        paused = !paused;
        if(!paused) { // unpausing
        }
    }
}
