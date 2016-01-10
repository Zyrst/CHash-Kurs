using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class Game : MonoBehaviour {

    /*Timers*/
    public float _spawnTime = 1f;
    public float _meteorSpawnTime = 0.5f;
    private float _timer = 0f;
    private float _meteorTimer = 0f;

    public int _meteorSpawnChance;
    public bool _playerDead = false;
    //The rate of fire which the enemy shoots with
    public float _enemyAttackSpeed = 0.5f;

    //References to different gameobjects and text
    public GameObject _enemy;
    public GameObject _player;
    public Player _currentPlayer;
    private Text _health;
    public GameObject _meteor;

    private static Game _instance = null;

    //use singleton for easy access to game class
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

    private int _score = 0;

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
        _enemyAttackSpeed = 0.5f;   //First attackspeed
	}
	
	// Update is called once per frame
	void Update () {
        if (!_playerDead)
        {
            _timer += Time.deltaTime;       //Timer for spawning enemies
            _meteorTimer += Time.deltaTime; //Timer for meteors

            if (_timer >= _spawnTime)
            {
                Instantiate(_enemy); //Spawn enemy
                _timer = 0f;
            }

            if(_meteorTimer >= _meteorSpawnTime)
            {
                _meteorTimer = 0f;
                int chance = Random.Range(0, 100);
                //random chance for a meteor to spawn so it doesn't clutter up
                if (chance <= _meteorSpawnChance)
                {
                    Debug.Log("Spawn meteor");
                    Meteor met = Instantiate(_meteor).GetComponent<Meteor>();
                    float randdir = Random.Range(-1f, 1f);
                    //Random direction and position
                    Vector3 dir;
                    Vector3 pos;
                    if (randdir >= 0)
                    {
                        dir = new Vector3(1f, 0f);
                        pos = new Vector3(-9f, Random.Range(-7f, 7f));
                    }
                    else
                    {
                        dir = new Vector3(-1f, 0f);
                        pos = new Vector3(9f, Random.Range(-7f, 7f));
                    }

                    met.Create(dir, pos);
                }
            }
            _health.text = "Health: " + _currentPlayer.Health; //Keep the health text updated
        }
	}

    public void AddScore(int amount)
    {
        Score += amount;
        //Switch "phase" depending on score
        if (Score >= 300 && Score < 500 && _currentPlayer._shotVersion != Player.Shot.ThreeArc)
        {
            _currentPlayer._shotVersion = Player.Shot.ThreeArc;
            _spawnTime -= 0.1f;
            _enemyAttackSpeed -= 0.1f;
        }
        if (Score >= 500 && _currentPlayer._shotVersion != Player.Shot.ThreeForward)
        {

            _currentPlayer._shotVersion = Player.Shot.ThreeForward;
            _spawnTime -= 0.5f;
            _enemyAttackSpeed -= 0.1f;

        }
        GetComponentsInChildren<Text>().FirstOrDefault(x => x.name == "Score").text = ("Score: " + Score.ToString());
    }

    public void PlayerDied()
    {
        //Player died, remove "HUD" and add the Dead menu
        _playerDead = true;
        GetComponentsInChildren<Text>().FirstOrDefault(x => x.name == "Score").gameObject.SetActive(false);
        _health.gameObject.SetActive(false);
        GetComponentsInChildren<Transform>(true).FirstOrDefault(x => x.name == "Dead").gameObject.SetActive(true);
        GetComponentsInChildren<Text>().FirstOrDefault(x => x.name == "FinalScore").text = "Final Score: " + System.Environment.NewLine + Score.ToString();

        //Remove all enemies
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();
        foreach (Enemy enemey in enemies)
        {
            Destroy(enemey.gameObject);
        }
    }

    public void StartGame()
    {
        //Make a new player object
        Destroy(_currentPlayer.gameObject);
        _currentPlayer = Instantiate(_player).GetComponent<Player>();

        //Reset everything and active HUD + deactive deadmenu
        Score = 0;
        _playerDead = false;
        Text score = GetComponentsInChildren<Text>(true).FirstOrDefault(x => x.name == "Score");
        score.gameObject.SetActive(true);
        score.text = ("Score: " + Score.ToString());
        _health.gameObject.SetActive(true);
        _health.text = "Health: " + _currentPlayer.Health;
        _enemyAttackSpeed = 0.5f;
        GetComponentsInChildren<Transform>().FirstOrDefault(x => x.name == "Dead").gameObject.SetActive(false);
    }
}
