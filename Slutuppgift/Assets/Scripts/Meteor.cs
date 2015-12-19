using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour {

    public Sprite[] _sprites;
    public GameObject _explosion;
    public float _moveSpeed;
    public Vector3 _dir;

    public float _lifeTime;
    private float _timer = 0f;

    private float _damage;

    public float Damage
    {
        get
        {
            return _damage;
        }

        set
        {
            _damage = value;
        }
    }

	// Use this for initialization
	void Start () {
        Damage = Random.Range(1, 11);
        GetComponent<SpriteRenderer>().sprite = _sprites[Random.Range(0, _sprites.Length)];
        _lifeTime = 10f;
	}
	
    public void Create(Vector3 dir , Vector3 pos)
    {
        _dir = dir;
        transform.position = pos;
    }

	// Update is called once per frame
    void Update() {
        Move();
        _timer += Time.deltaTime;
        if(_timer >= _lifeTime)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name.Contains("Projectile"))
        {
            Instantiate(_explosion, this.transform.position , Quaternion.identity);
            Destroy(col.gameObject);
        }
        Destroy(this.gameObject);
    }

    public void Move()
    {
        transform.position += _dir * _moveSpeed * Time.deltaTime;
    }
}
