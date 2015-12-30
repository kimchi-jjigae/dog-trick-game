using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public interface ITimerOnBeat {
    void OnBeat();
}
public interface ITimerOnMoveChange {
    void OnMoveChange(int moveNumber);
}
public interface ITimerOnStop {
    void OnStop();
}
public interface ITimerOnStart {
    void OnStart();
}

public class Timer : MonoBehaviour {
    
    // classes the Timer sends its time updates to: //
    public SliderValueUpdater sliderValueUpdater;
    public MoveVerifier moveVerifier;
    public LevelPlayer levelPlayer;
    List<ITimerOnBeat> onBeatSubscribers;
    List<ITimerOnMoveChange> onMoveChangeSubscribers;
    List<ITimerOnStop> onStopSubscribers;
    List<ITimerOnStart> onStartSubscribers;

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

        onBeatSubscribers = new List<ITimerOnBeat>();
        onMoveChangeSubscribers = new List<ITimerOnMoveChange>();
        onStartSubscribers = new List<ITimerOnStart>();
        onStopSubscribers = new List<ITimerOnStop>();
	}
	
	void Update () {
        if(!paused) {
            sliderValueUpdater.OnTimerUpdate(BeatPosPercent());

            if(OnBeat()) { // every thud
                beatNumber++;
                lastBeatTime = nextBeatTime;
                nextBeatTime = GetNextBeatTime();

                foreach(ITimerOnBeat subscriber in onBeatSubscribers) {
                    subscriber.OnBeat();
                }
            }
            if(OnMoveChange()) { // should be a half-beat's length before OnBeat()
                moveNumber++;
                nextMoveTime = GetNextMoveTime();

                foreach(ITimerOnMoveChange subscriber in onMoveChangeSubscribers) {
                    subscriber.OnMoveChange(moveNumber);
                }
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

    public float GetNextBeatTime() {
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

        foreach(ITimerOnStart subscriber in onStartSubscribers) {
            subscriber.OnStart();
        }
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

    public void AddSubscriber(ITimerOnBeat subscriber) {
        onBeatSubscribers.Add(subscriber);
    }

    public void AddSubscriber(ITimerOnMoveChange subscriber) {
        onMoveChangeSubscribers.Add(subscriber);
    }
}
