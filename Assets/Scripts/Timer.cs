using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {
    
    // classes the Timer sends its time updates to: //
    public SliderValueUpdater sliderValueUpdater;
    public ParticleController particleController;
    public LevelPlayer levelPlayer;
    public MusicBox musicBox;
    public LeaderController leader;
    public DogController dog;

    // timing variables //
    public float beatsPerMinute;
    float beatLength;
    float halfBeatLength;
    float lastBeatTime;
    float nextBeatTime;

    int beatNumber;

	void Start () {
        beatLength = 60.0f / beatsPerMinute;
        halfBeatLength = 30.0f / beatsPerMinute;
        
        beatNumber = 0;
        lastBeatTime = 0.0f;
        nextBeatTime = GetNextBeatTime();
	}
	
	void Update () {
        sliderValueUpdater.OnTimerUpdate(BeatPosPercent());

        if(OnBeat()) {
            beatNumber++;
            lastBeatTime = nextBeatTime;
            nextBeatTime = GetNextBeatTime();

            particleController.OnBeat();
            musicBox.OnBeat();
            leader.OnBeat();
            dog.OnBeat();
            levelPlayer.OnBeat(); // should be last, since it advances the move
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

    float GetNextBeatTime() {
        return (beatNumber + 1) * beatLength;
    }
}
