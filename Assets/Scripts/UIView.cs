using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIView : MonoBehaviour {

	// Use this for initialization
	virtual public void Show () {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    public void Hide () {
        gameObject.SetActive(false);
	}
}
