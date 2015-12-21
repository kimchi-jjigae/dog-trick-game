using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {
    
    public GameObject timerSlider;
    Slider slider;

    public MusicBox musicBox;
    public float beatsPerMinute;
    float beatLength;
    float halfBeat;
    float sliderValue;

    public ParticleSystem timerParticles;

	void Start () {
        slider = timerSlider.GetComponent<Slider>();
        beatLength = 60.0f / beatsPerMinute;
        halfBeat = 30.0f / beatsPerMinute;
        sliderValue = 0.0f;
        slider.maxValue = 1.0f;
	}
	
	void Update () {
        float currentTime = Time.time;
        float beatTime = currentTime % beatLength;
	    sliderValue = beatTime + halfBeat;
        if(sliderValue > beatLength) {
            sliderValue = sliderValue - beatLength;
        }

        slider.value = sliderValue;
        // on beat //
        if(Mathf.Abs(beatTime - beatLength) < 0.02) {
            musicBox.Kick();
            timerParticles.Emit(30);
        }
	}
}
