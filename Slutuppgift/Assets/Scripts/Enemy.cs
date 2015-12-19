using UnityEngine;
using System.Collections;

public class Enemy : Entity {
    private Vector3 mDir;
    private float mViewPortSize;
    public Sprite[] _sprites;
    public GameObject _projectile;
    public GameObject _explosion;
    public GameObject _heal;

    private bool _cd = true;
    private float _timer = 0f;

	// Use this for initialization
	void Start () {
        MyTag = Tag.Enemy;
        mDir = new Vector3(Random.Range(-4f, 4f), Random.Range(-2f, -1f), 0); //Random direction
        transform.position = new Vector3(Random.Range(-5f, 5f), 10.5f);
        Health = 1f;
        Damage = 1f;
        MoveSpeed = Random.Range(1f, 2f);
        AttackSpeed = Game.Instance._enemyAttackSpeed;
        mViewPortSize = Camera.main.orthographicSize;
        GetComponent<SpriteRenderer>().sprite = _sprites[Random.Range(0, 3)];
	}
	
	// Update is called once per frame
	void Update () {
        Fire();
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
        Instantiate(_explosion).transform.position = transform.position;
        int rand = Random.Range(0, 100);
        if( rand < 50)
        {
            Instantiate(_heal, transform.position, Quaternion.identity);
        }

        Destroy(this.gameObject);
    }

    public override void TakeDamage(float damage)
    {
        Health -= damage;
    }

    public void Fire()
    {
        if(!_cd)
        {
            Instantiate(_projectile).GetComponent<Projectile>().Create(transform.position + new Vector3(0, -0.7f), new Vector2(0, -1f), Tag.Enemy, Damage);
            _cd = true;
        }
        else
        {
            _timer += Time.deltaTime;
            if (_timer >= AttackSpeed)
            {
                _cd = false;
                _timer = 0f;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //if(col.collider.name.Contains("Player"))
        //{
        //    col.collider.GetComponent<Player>().TakeDamage(Damage * 5);
        //    Kill();
        //}
        //else if (col.collider.name.Contains("Projectile"))
        //{
        //    Projectile proj = col.collider.GetComponent<Projectile>();
        //    if(proj.MyTag == Tag.Player)
        //    {

        //    }
        //}
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name.Contains("Player"))
        {
            col.GetComponent<Player>().TakeDamage(Damage * 5);
            Kill();
        }
        else if (col.name.Contains("Projectile"))
        {
            Projectile proj = col.GetComponent<Projectile>();
            if (proj.MyTag == Tag.Player)
            {
                Destroy(col.gameObject);
                Kill();
                
            }
        }
        else if(col.name.Contains("Meteor"))
        {
            Instantiate(_explosion).transform.position = transform.position;
            Destroy(this.gameObject);
        }
    }
}
