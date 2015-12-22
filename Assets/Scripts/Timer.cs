using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {
    
    public GameObject timerSlider;
    Slider slider;

    public float beatsPerMinute;
    float beatLength;
    float halfBeat;
    float sliderValue;
    float lastBeatTime;

    int beatNumber;

    public ParticleSystem timerParticles;

	void Start () {
        slider = timerSlider.GetComponent<Slider>();
        beatLength = 60.0f / beatsPerMinute;
        halfBeat = 30.0f / beatsPerMinute;
        sliderValue = 0.0f;
        slider.maxValue = 1.0f;
        
        beatNumber = 0;
	}
	
	void Update () {
        float beatPos = Time.time % beatLength;
	    sliderValue = beatPos + halfBeat;
        if(sliderValue > beatLength) {
            sliderValue = sliderValue - beatLength;
        }

        slider.value = sliderValue;
        // on beat //
        if(OnBeat()) {
            timerParticles.Emit(30);
            beatNumber++;
            lastBeatTime = Time.time;
        }
	}

    public bool OnBeat(float tolerance = 0.02f) {
        float beatPos = Time.time % beatLength;
        bool onABeat = Mathf.Abs(beatPos - beatLength) < 0.02f;
        bool missedABeat = Time.time - lastBeatTime > beatLength;
        return onABeat || missedABeat;
    }
}
