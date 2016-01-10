using UnityEngine;
using System.Collections;

public class Meteor : Entity {

    public Sprite[] _sprites;
    public GameObject _explosion;
    public float _moveSpeed;
    public Vector3 _dir;

    public float _lifeTime;
    private float _timer = 0f;

	// Use this for initialization
	void Start () {
        //random amount of damage and random sprite
        Damage = Random.Range(1, 11);
        GetComponent<SpriteRenderer>().sprite = _sprites[Random.Range(0, _sprites.Length)];
        _lifeTime = 10f;
        MyTag = Tag.Neutral;
	}
	
    public void Create(Vector3 dir , Vector3 pos)
    {
        //Determine what direction the meteor goes and spawn point
        _dir = dir;
        transform.position = pos;
    }

	// Update is called once per frame
    void Update() {
        Move();
        _timer += Time.deltaTime;
        if(_timer >= _lifeTime)
        {
            //Don't let it live forever
            Kill();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name.Contains("Projectile"))
        {
            Destroy(col.gameObject);
            Kill();
        }
        //Don't collide with other metoers
        else if(col.GetComponent<Entity>().MyTag != Tag.Neutral)
        {
            try
            {
                col.GetComponent<Entity>().TakeDamage(Damage);
                Kill();
            }
            catch (System.NullReferenceException) { }
        }
        
    }

    public override void Move()
    {
        transform.position += _dir * _moveSpeed * Time.deltaTime;
    }

   
    public override void CheckBoundries()
    {
        throw new System.NotImplementedException();
    }

    public override void Kill()
    {
        //Create an explosion and destory this object
        Instantiate(_explosion, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    public override void TakeDamage(float damage)
    {
        Health -= damage;
        if(Health <= 0f)
        {
            Kill();
        }
    }
}
