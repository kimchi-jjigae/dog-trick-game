using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderValueUpdater : MonoBehaviour, ITimerOnStop, ITimerOnUpdate {

    public Slider slider;

	void Start () {
        slider.value = 0.5f;
        slider.maxValue = 1.0f;

        Timer timer = GameObject.Find("MainController").GetComponent<Timer>();
        timer.AddSubscriber(this as ITimerOnStop);
        timer.AddSubscriber(this as ITimerOnUpdate);
	}

    public void OnTimerUpdate(float beatPosPercent) {
        // set the middle point to 0.5f //
	    float sliderValue = beatPosPercent + 0.5f;
        slider.value = sliderValue - Mathf.Floor(sliderValue);
    }

    public void OnTimerStop() {
        slider.value = 0.5f;
    }
}
