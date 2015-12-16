using UnityEngine;
using System.Collections;

public class Enemy : Entity {
    private Vector3 mDir;
    private float mViewPortSize;
    public Sprite[] _sprites;

	// Use this for initialization
	void Start () {
        MyTag = Tag.Enemy;
        mDir = new Vector3(Random.Range(-4f, 4f), Random.Range(-2f, -1f), 0); //Random direction
        transform.position = new Vector3(Random.Range(-5f, 5f), 10.5f);
        Health = 1f;
        Damage = 1f;
        MoveSpeed = Random.Range(1f, 2f);
        mViewPortSize = Camera.main.orthographicSize;
        GetComponent<SpriteRenderer>().sprite = _sprites[Random.Range(0, 3)];
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        CheckBoundries();
        if(Health <= 0f)
        {
            Kill();
        }
	}

    public override void Move()
    {
        transform.position += mDir * MoveSpeed * Time.deltaTime;
    }

    public override void CheckBoundries()
    {
        float edge = mViewPortSize * 0.75f;
         if (transform.position.x > edge)
         {
             mDir.x *= -1;
         }
         else if (transform.position.x < -edge)
         {
             mDir.x *= -1;
         }

        if(transform.position.y < -mViewPortSize - 2f)
        {
            Game.Instance.AddScore(-5);
            Destroy(this.gameObject);
        }
    }

    public override void Kill()
    {
        Game.Instance.AddScore(10);
    }
}
