using UnityEngine;
using System.Collections;
using System.Threading;

public class Game : MonoBehaviour {

	// Use this for initialization
    float timerCheck = 1f;
    float timer = 0f;
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer >= timerCheck)
        {
            GameObject.Find("AI").GetComponent<AI>().OutOfBounds();
            timer = 0f;
            Debug.Log("Running OOB check");
        }
        
	}
}
