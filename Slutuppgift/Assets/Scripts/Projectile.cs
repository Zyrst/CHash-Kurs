using UnityEngine;
using System.Collections;

public class Projectile : Entity {
    private Vector3 _dir;
    public Sprite[] _shots;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    public void Create(Vector2 pos, Vector2 dir, Tag tag, float dmg)
    {
        transform.position = pos;
        MyTag = tag;
        _dir = dir;
        Damage = dmg;
        //Use right sprite depedning on enemy or player
        if (MyTag == Tag.Enemy)
        {
            GetComponent<SpriteRenderer>().sprite = _shots[0];
            AttackSpeed = 7f;
        }
        else
            GetComponent<SpriteRenderer>().sprite = _shots[1];
    }
    public override void Move()
    {
        transform.position += (_dir * MoveSpeed) * Time.deltaTime;
        if(transform.position.y >= 11f || transform.position.y <= -11f)
        {
            Destroy(this.gameObject);
        }
    }

    public override void CheckBoundries()
    {
        throw new System.NotImplementedException();
    }

    public override void Kill()
    {
        throw new System.NotImplementedException();
    }

    public override void TakeDamage(float damage)
    {
        throw new System.NotImplementedException();
    }
}
