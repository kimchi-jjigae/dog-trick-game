using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {
    
    // classes the Timer sends its time updates to: //
    public SliderValueUpdater sliderValueUpdater;
    public ParticleController particleController;
    public LevelPlayer levelPlayer;
    public MusicBox musicBox;
    public DogStateChanger leader;
    public DogStateChanger dog;

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
        nextBeatTime = beatLength;
	}
	
	void Update () {
        sliderValueUpdater.OnTimerUpdate(BeatPosPercent());

        if(OnBeat()) {
            particleController.OnBeat();
            levelPlayer.OnBeat();
            musicBox.OnBeat();
            leader.OnBeat();
            dog.OnBeat();

            lastBeatTime = nextBeatTime;
            nextBeatTime = (beatNumber + 1) * beatLength;
            beatNumber++;
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
}
