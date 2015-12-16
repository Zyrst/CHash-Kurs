using UnityEngine;
using System.Collections;

public class Player : Entity {
    private float mViewPortSize;
    private Sprite mSprite;
	// Use this for initialization
	void Start () {
        MyTag = Tag.Player;
        MoveSpeed = 10;
        Health = 100;
        Damage = 1f;
        AttackSpeed = 0.5f;
        mViewPortSize = Camera.main.orthographicSize;
        mSprite = GetComponent<SpriteRenderer>().sprite;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        CheckBoundries();
	}

    public override void Move()
    {
        float y = 0;
        float x = 0;
        if (Input.GetKey(KeyCode.W))
        {
            y += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            y -= 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            x -= 1;
        }
        if(Input.GetKey(KeyCode.D))
        {
            x += 1;
        }

        x *= MoveSpeed;
        y *= MoveSpeed;

        transform.position += new Vector3(x * Time.deltaTime, y * Time.deltaTime, 0);
        
       
    }

    public override void CheckBoundries()
    {
        //Magic number to find edge(ish)
        float edge = mViewPortSize * 0.75f;
        if (transform.position.x > edge)
        {
            float over = transform.position.x - edge;
            transform.position -= new Vector3(over, 0, 0);
        }
        else if (transform.position.x < (-edge))
        {
            float over = transform.position.x + edge;
            transform.position -= new Vector3(over, 0, 0);
        }

        if((transform.position.y + 0.5f) > mViewPortSize)
        {
            float over = (transform.position.y + 0.5f) - mViewPortSize;
            transform.position -= new Vector3(0, over, 0);
        }
        else if((transform.position.y - 0.5f) < -mViewPortSize)
        {
            float over = (transform.position.y - 0.5f) + mViewPortSize;
            transform.position -= new Vector3(0, over, 0);
        }
    }

    public override void Kill()
    {
        throw new System.NotImplementedException();
    }
}
