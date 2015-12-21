using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {
    
    public GameObject timerSlider;
    Slider slider;

    public MusicBox musicBox;

    public float beatLength;

	void Start () {
        slider = timerSlider.GetComponent<Slider>();
        slider.maxValue = beatLength;
	}
	
	void Update () {
        float currentTime = Time.time;
        float beatTime = currentTime % beatLength;
	    slider.value = beatTime;
        if(Mathf.Abs(beatTime - beatLength) < 0.02) {
            musicBox.Kick();
        }
	}
}
