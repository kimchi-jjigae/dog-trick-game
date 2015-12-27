using UnityEngine;
using System.Collections;

public class PointsPopulator : MonoBehaviour {

    public Transform pointParent;
    public RectTransform pointPrefab;
    public RectTransform nopointPrefab;
    public float leftOffset;
    public float pointSize;
	
    public void Populate(int onAmount, int offAmount) {
        for(int i = 0; i < onAmount + offAmount; ++i) {
            RectTransform point;
            if(i < onAmount) {
                point = Instantiate(pointPrefab) as RectTransform;
            }
            else {
                point = Instantiate(nopointPrefab) as RectTransform;
            }
            point.transform.SetParent(pointParent, false);
            point.anchoredPosition = new Vector2(leftOffset + (pointSize * i), 0.0f);
        }
    }
}
