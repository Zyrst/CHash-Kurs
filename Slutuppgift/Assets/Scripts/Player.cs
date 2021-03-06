﻿using UnityEngine;
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
        //Look at input on WASD , if pressed add or subtract from its axis
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

        //Multiply with a speed
        x *= MoveSpeed;
        y *= MoveSpeed;
        //Add on current pos with delta
        transform.position += new Vector3(x * Time.deltaTime, y * Time.deltaTime, 0);
        
       
    }

    public override void CheckBoundries()
    {
        //Magic number to find edge(ish)
        float edge = mViewPortSize * 0.75f;

        if (transform.position.x > edge)
        {
            //See how much the ship is outside the screen and move it back
            float over = transform.position.x - edge;
            transform.position -= new Vector3(over, 0, 0);
        }
        else if (transform.position.x < (-edge))
        {
            float over = transform.position.x + edge;
            transform.position -= new Vector3(over, 0, 0);
        }
        //Look at top and bottom and move back if needed
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
        //No cooldown
        if(!_cd)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                _cd = true;
                //Use the right shot config
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
                        GameObject go1 = Instantiate(_projectile);
                        go1.GetComponent<Projectile>().Create(_weaponslots[1].transform.position, new Vector2(-0.5f, 1f), Tag.Player, Damage);
                        go1.transform.Rotate(new Vector3(0,0,25));
                        GameObject go2 = Instantiate(_projectile);
                        go2.GetComponent<Projectile>().Create(_weaponslots[2].transform.position, new Vector2(0.5f, 1f), Tag.Player, Damage);
                        go2.transform.Rotate(new Vector3(0, 0, -25));
                        break;
                    default:
                        break;
                }
            }
        }
        else
        {
            //Count up cooldown timer
            _timer += Time.deltaTime;
            if(_timer >= AttackSpeed)
            {
                //Reset
                _cd = false;
                _timer = 0f;
            }
        }
    }
    public override void Kill()
    {
        Game.Instance.PlayerDied();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name.Contains("Projectile"))
        {
            Projectile proj = col.GetComponent<Projectile>();
            if(proj.MyTag == Tag.Enemy)
            {
                TakeDamage(proj.Damage);
                proj.TakeDamage(Damage);
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
