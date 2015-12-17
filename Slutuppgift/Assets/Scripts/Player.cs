using UnityEngine;
using System.Collections;

public class Player : Entity {
    private float mViewPortSize;
    public GameObject _projectile;
    public GameObject[] _weaponslots;

    private bool _cd = false;
    private float _timer = 0f;
    public enum Shot : int { OneForward = 0, ThreeForward = 1, ThreeArc = 2 };
    public Shot _shotVersion = 0;

	// Use this for initialization
	void Start () {
        MyTag = Tag.Player;
        MoveSpeed = 10;
        Health = 100;
        Damage = 1f;
        mViewPortSize = Camera.main.orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
        if (Health > 0)
        {
            Shoot();
            Move();
            CheckBoundries();
        }
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

    public void Shoot()
    {
        if(!_cd)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                _cd = true;
                switch (_shotVersion)
                {
                    case Shot.OneForward:
                        Projectile go = Instantiate(_projectile).GetComponent<Projectile>();
                        go.Create(_weaponslots[0].transform.position, new Vector2(0f, 1f), Tag.Player, Damage);
                        break;
                    case Shot.ThreeForward:
                        foreach(GameObject g in _weaponslots)
                        {
                            Instantiate(_projectile).GetComponent<Projectile>().Create(g.transform.position, new Vector2(0f, 1f), Tag.Player, Damage);
                        }
                        break;
                    case Shot.ThreeArc:
                        Instantiate(_projectile).GetComponent<Projectile>().Create(_weaponslots[0].transform.position, new Vector2(0f, 1f), Tag.Player, Damage);
                        Instantiate(_projectile).GetComponent<Projectile>().Create(_weaponslots[1].transform.position, new Vector2(-0.5f, 1f), Tag.Player, Damage);
                        Instantiate(_projectile).GetComponent<Projectile>().Create(_weaponslots[2].transform.position, new Vector2(0.5f, 1f), Tag.Player, Damage);
                        break;
                    default:
                        break;
                }
            }
        }
        else
        {
            _timer += Time.deltaTime;
            if(_timer >= AttackSpeed)
            {
                _cd = false;
                _timer = 0f;
            }
        }
    }
    public override void Kill()
    {
        Game.Instance._playerDead = true;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name.Contains("Projectile"))
        {
            if(col.GetComponent<Projectile>().MyTag == Tag.Enemy)
            {
                TakeDamage(col.GetComponent<Projectile>().Damage);
                Destroy(col.gameObject);
            }
        }
    }

    public override void TakeDamage(float damage)
    {
        Health -= damage;
        if(Health <= 0)
        {
            Kill();
        }
    }
}
