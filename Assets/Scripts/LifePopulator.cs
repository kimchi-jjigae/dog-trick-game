using UnityEngine;
using System.Collections;

public class LifePopulator : MonoBehaviour {
    public Transform lifeParent;
    public RectTransform lifePrefab;
    public RectTransform nolifePrefab;
    public float leftOffset;
    public float lifeSize;

	// Use this for initialization
	void Start () {
	    populate(3, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void populate(int onAmount, int offAmount) {
        for(int i = 0; i < onAmount + offAmount; ++i) {
            RectTransform life;
            if(i < onAmount) {
                life = Instantiate(lifePrefab) as RectTransform;
            }
            else {
                life = Instantiate(nolifePrefab) as RectTransform;
            }
            life.transform.SetParent(lifeParent, false);
            life.anchoredPosition = new Vector2(leftOffset + (lifeSize * i), 0.0f);
        }
    }
}
