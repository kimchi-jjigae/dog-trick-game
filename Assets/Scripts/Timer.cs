using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {
    
    // classes the Timer sends its time updates to: //
    public SliderValueUpdater sliderValueUpdater;
    public ParticleController particleController;
    public LevelPlayer levelPlayer;

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
        // get beat position between 0.0f and 1.0f //
        float timeSinceLastBeat = Time.time - lastBeatTime;
        float predictedBeatLength = nextBeatTime - lastBeatTime;
        float beatPosPercent = timeSinceLastBeat / predictedBeatLength;

        sliderValueUpdater.OnTimerUpdate(beatPosPercent);

        if(OnBeat()) {
            particleController.OnBeat();
            levelPlayer.OnBeat();

            lastBeatTime = nextBeatTime;
            nextBeatTime = (beatNumber + 1) * beatLength;
            beatNumber++;
        }
	}

    bool OnBeat() {
        return Time.time > nextBeatTime;
    }
}
