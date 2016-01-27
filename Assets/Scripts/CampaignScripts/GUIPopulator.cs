using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// class to be inherited by Life- and PointPopulator //
public class GUIPopulator : MonoBehaviour {
    public Transform itemParent;
    public RectTransform itemPrefab;
    public RectTransform noitemPrefab;
    public float leftOffset;
    public float itemSize;
    List<RectTransform> items;
	
    void Start() {
        items = new List<RectTransform>();
    }
	
    public void Populate(int onAmount, int offAmount) {
        // clearing the list first //
        for(int i = 0; i < items.Count; ++i) {
            Destroy(items[i].gameObject);
        }
        items.Clear();

        // then (re)filling it //
        for(int i = 0; i < onAmount + offAmount; ++i) {
            RectTransform item;
            if(i < onAmount) {
                item = Instantiate(itemPrefab) as RectTransform;
            }
            else {
                item = Instantiate(noitemPrefab) as RectTransform;
            }
            item.transform.SetParent(itemParent, false);
            item.anchoredPosition = new Vector2(leftOffset + (itemSize * i), 0.0f);
            items.Add(item);
        }
    }
}
