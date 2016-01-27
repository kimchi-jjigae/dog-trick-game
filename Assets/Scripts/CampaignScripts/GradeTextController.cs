using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GradeTextController : MonoBehaviour {

    float startTime;
    float duration;

    void Start() {
        startTime = 0.0f;
        duration = 0.2f;
    }

    void Update() {
        if(Time.time - startTime > duration) {
            gameObject.SetActive(false);
        }
    }

    public void StartText(MoveGrade moveGrade) {
        startTime = Time.time;
        gameObject.SetActive(true);
        GetComponent<Text>().text = moveGrade.ToString() + "!";
    }
}
