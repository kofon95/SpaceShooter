using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {

    public float secondsBeforeDestroy;
	void Start ()
    {
        Destroy(gameObject, secondsBeforeDestroy);
	}
}
