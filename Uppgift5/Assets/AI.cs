using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {
    public Vector3 dir;
    float speed = 100;
    CircleCollider2D col;
	// Use this for initialization
	void Start () {
        Random.seed = System.DateTime.Now.Millisecond;
	    dir = new Vector3(Random.Range(-1f, 1f),Random.Range(-1f, 1f),Random.Range(-1f, 1f));
        col = GetComponent<CircleCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += dir * Time.deltaTime;
	}


    public void OutOfBounds()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if(!sprite.isVisible)
        {
            float x = transform.position.x - Camera.main.rect.center.x;
            x *= 0.1f;
            x += Random.Range(0.1f, 0.5f);
            float y = transform.position.y - Camera.main.rect.center.y;
            y *= 0.1f;
            y += Random.Range(0.1f, 0.5f);

            dir = new Vector3(-x , -y, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        Debug.Log("Collision");
        dir += new Vector3(Random.Range(-0.8f, 0.8f), Random.Range(-0.8f, 0.8f), 0);
        if (dir.x > 1f) { dir.x = 1f; }
        if (dir.y > 1f) { dir.y = 1f; }
        if (dir.x < -1f) { dir.x = -1f; }
        if (dir.y < -1f) { dir.y = -1f; }
        dir = -dir;
        
    }
}
