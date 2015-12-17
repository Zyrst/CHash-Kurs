using UnityEngine;
using System.Collections;

public abstract class Entity : MonoBehaviour {
    public float Health;
    public float AttackSpeed;
    public float MoveSpeed;
    public float Damage;

    public enum Tag : int { Player = 0, Enemy = 1}
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

    public abstract void Move();
    public abstract void CheckBoundries();

    public abstract void Kill();

    public abstract void TakeDamage(float damage);
}
