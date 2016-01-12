using UnityEngine;
using System.Collections;

public abstract class Entity : MonoBehaviour {
    //Different stats for the entities
    public float Health;
    public float AttackSpeed;
    public float MoveSpeed;
    public float Damage;

    public enum Tag : int { Player = 0, Enemy = 1, Neutral = 2}
    private Tag _tag;
    public Tag MyTag
    {
        get
        {
            return _tag;
        }
        set 
        {
            _tag = value;
        }
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    //Implemented in inherited classes
    public abstract void Move();
    public abstract void CheckBoundries();
    public abstract void Kill();
    public abstract void TakeDamage(float damage);
}
