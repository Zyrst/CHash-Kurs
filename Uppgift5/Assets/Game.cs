using UnityEngine;
using System.Collections;
using System.Threading;
using System.Collections.Generic;

public class Game : MonoBehaviour {

	// Use this for initialization
    float timerCheck = 1f;
    float timer = 0f;

    public GameObject _ai;
    List<GameObject> aiList = new List<GameObject>();

	void Start () {
        for(int i = 0; i < 10; i++)
        {
            aiList.Add(GameObject.Instantiate(_ai, new Vector3(Random.Range(-5f, 5f), Random.Range(-5, 5), 0), new Quaternion()) as GameObject);
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer >= timerCheck)
        {
            foreach(GameObject go in aiList)
            {
                go.GetComponent<AI>().OutOfBounds();
            }
            //GameObject.Find("AI").GetComponent<AI>().OutOfBounds();
            timer = 0f;
            //Debug.Log("Running OOB check");
        }
        
	}
}
