using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class Game : MonoBehaviour {
    private int _score = 0;
    public float _spawnTime = 1f;
    private float _timer = 0f;

    public GameObject _enemy;
    public GameObject _player;
    public Player _currentPlayer;
    private Text _health;

    private static Game _instance = null;

    public static Game Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("Game").GetComponent<Game>();
                return _instance;
            }
            else 
            {
                return _instance;
            }
        }
    }

    public int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
        }
    }
	// Use this for initialization
	void Start () {
        _currentPlayer = Instantiate(_player).GetComponent<Player>();
        GetComponentsInChildren<Text>().FirstOrDefault(x => x.name == "Score").text = ("Score: " + Score.ToString());
        _health = GetComponentsInChildren<Text>().FirstOrDefault(x => x.name == "Health");
        _health.text = "Health: " + _currentPlayer.Health;
	}
	
	// Update is called once per frame
	void Update () {
        _timer += Time.deltaTime;
        if(_timer >= _spawnTime)
        {
            Instantiate(_enemy);
            _timer = 0f;
        }
        _health.text = "Health: " + _currentPlayer.Health;
	}

    public void AddScore(int amount)
    {
        Score += amount;
        GetComponentsInChildren<Text>().FirstOrDefault(x => x.name == "Score").text = ("Score: " + Score.ToString());
    }
}
