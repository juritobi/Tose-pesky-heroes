using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour {
    public float destroyTime;
    public Vector3 offset = new Vector3(0,100,-100);
	// Use this for initialization
	void Start () {
        transform.localPosition += offset;
        destroyTime = 1;
        Destroy(gameObject, destroyTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
