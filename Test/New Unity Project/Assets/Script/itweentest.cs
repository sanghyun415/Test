using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itweentest : MonoBehaviour {
    public GameObject ttt;
	// Use this for initialization
	void Start () {
        iTween.MoveTo(ttt, iTween.Hash("path", iTweenPath.GetPath("PosMove1"), "time", 5.5f, "orienttopath", false, "easetype", iTween.EaseType.linear, "oncomplete", "TweenStop"));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void TweenStop()
    {
        Debug.Log("ttttttt");
    }
}
