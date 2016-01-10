using UnityEngine;
using System.Collections;

public class HealPickUp : MonoBehaviour {
    public float _lifeTime;
    private float _timer = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        _timer += Time.deltaTime;
        if(_timer >= _lifeTime)
        {
            Destroy(this.gameObject);
        }
	}


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name.Contains("Player"))
        {
            //if collision with player increase currenthealth
            col.GetComponent<Player>().Health += 10f;
            Destroy(this.gameObject);
        }
    }
}
