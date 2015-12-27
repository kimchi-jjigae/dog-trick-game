using UnityEngine;
using System.Collections;

public class PointsPopulator : MonoBehaviour {

    public Transform pointParent;
    public RectTransform point;
    public Transform point_off;

	// Use this for initialization
	void Start () {
	    for(int i = 0; i < 4; ++i) {
            RectTransform p = Instantiate(point) as RectTransform;
            p.transform.SetParent(pointParent, false);
            p.anchoredPosition = new Vector2(210 + (50 * i), 0);
        }
	}
	
	// Update is called once per frame
	void Update () {
	}
}
