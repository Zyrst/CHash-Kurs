using UnityEngine;
using System.Collections;

public class Projectile : Entity {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void Move()
    {
    }

    public override void CheckBoundries()
    {
        throw new System.NotImplementedException();
    }

    public override void Kill()
    {
        throw new System.NotImplementedException();
    }
}
