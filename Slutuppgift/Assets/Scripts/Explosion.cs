using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
    public float _time = 5f;
    public float _timer = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        _timer += Time.deltaTime;
        if(_timer >= _time)
        {
            Destroy(this.gameObject);
        }
	}
}
