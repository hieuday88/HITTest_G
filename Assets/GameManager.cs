using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text scoreText;
    public int score = 0;

    public int highScore = 0;

    public int sec = 5000;

    public bool hasFood = false;

    public GameObject foodPrefab;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

    }

    void Update()
    {
        if (sec >= 300 * Time.timeScale)
        {
            SpawnFood();
            sec = 0;
        }
        else
        {
            sec += 1;
        }
    }

    void SpawnFood()
    {
        if (hasFood) return;
        float x = Random.Range(-7.5f, 7.5f);
        float y = Random.Range(-3.5f, 3.5f);
        Instantiate(foodPrefab, new Vector3(x, y, 0), Quaternion.identity);
        hasFood = true;
    }
}
