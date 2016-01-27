using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public interface ITimerOnBeat {
    void OnTimerBeat();
}
public interface ITimerOnMoveChange {
    void OnTimerMoveChange(int moveNumber);
}
public interface ITimerOnStart {
    void OnTimerStart();
}
public interface ITimerOnStop {
    void OnTimerStop();
}
public interface ITimerOnUpdate {
    void OnTimerUpdate(float beatPosPercent);
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
    List<ITimerOnUpdate> onUpdateSubscribers;

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
        onUpdateSubscribers = new List<ITimerOnUpdate>();
	}
	
	void Update () {
        if(!paused) {
            foreach(ITimerOnUpdate subscriber in onUpdateSubscribers) {
                subscriber.OnTimerUpdate(BeatPosPercent());
            }

            if(OnBeat()) { // every thud
                beatNumber++;
                lastBeatTime = nextBeatTime;
                nextBeatTime = GetNextBeatTime();

                foreach(ITimerOnBeat subscriber in onBeatSubscribers) {
                    subscriber.OnTimerBeat();
                }
            }
            if(OnMoveChange()) { // should be a half-beat's length before OnBeat()
                moveNumber++;
                nextMoveTime = GetNextMoveTime();

                foreach(ITimerOnMoveChange subscriber in onMoveChangeSubscribers) {
                    subscriber.OnTimerMoveChange(moveNumber);
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

    public void StopTimer() {
        paused = true;
        foreach(ITimerOnStop subscriber in onStopSubscribers) {
            subscriber.OnTimerStop();
        }
    }

    public void StartTimer() {
        paused = false;
        InitialiseValues();

        foreach(ITimerOnStart subscriber in onStartSubscribers) {
            subscriber.OnTimerStart();
        }
    }

    public void PauseTimer() {
        paused = true;
    }

    public void UnpauseTimer() {
        paused = false;
    }

    public void SetBPM(float newBPM) {
        beatsPerMinute = newBPM;
        beatLength = 60.0f / beatsPerMinute;
        halfBeatLength = 30.0f / beatsPerMinute;
    }

    public void AddSubscriber(ITimerOnBeat subscriber) {
        onBeatSubscribers.Add(subscriber);
    }

    public void AddSubscriber(ITimerOnMoveChange subscriber) {
        onMoveChangeSubscribers.Add(subscriber);
    }

    public void AddSubscriber(ITimerOnStart subscriber) {
        onStartSubscribers.Add(subscriber);
    }

    public void AddSubscriber(ITimerOnStop subscriber) {
        onStopSubscribers.Add(subscriber);
    }

    public void AddSubscriber(ITimerOnUpdate subscriber) {
        onUpdateSubscribers.Add(subscriber);
    }

    void InitialiseValues() {
        beatNumber = 0;
        moveNumber = 0;

        startTime = Time.time;
        lastBeatTime = startTime;
        nextBeatTime = GetNextBeatTime();
        nextMoveTime = GetNextMoveTime();

    }

}
