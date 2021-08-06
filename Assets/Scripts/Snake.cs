using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;

    private List<Transform> _segments;
    public Transform segmentPrefab;
    private int boost = 0;

    private int scoreCount = 0;
    private int highScoreCount;
    public static Snake instance;
    [SerializeField] private Text score, highScore;
    private void Awake()
    {
        instance = this;
        if (PlayerPrefs.HasKey("SaveScore"))
        {
            highScoreCount = PlayerPrefs.GetInt("SaveScore");
            highScore.text = highScoreCount.ToString() + " points";
        }
    }

    private void Start()
    {
        _segments = new List<Transform>();

        _segments.Add(this.transform);
    }

    public void Up()
    {
        if (_direction != Vector2.down)
            _direction = Vector2.up;
    }

    public void Down()
    {
        if (_direction != Vector2.up)
            _direction = Vector2.down;
    }
    public void Right()
    {
        if (_direction != Vector2.left)
            _direction = Vector2.right;
    }
    public void Left()
    {
        if (_direction != Vector2.right)
            _direction = Vector2.left;
    }

    private void FixedUpdate()
    {
        if (boost == 0)
            Time.fixedDeltaTime = 0.3f;
        else if (boost == 1)
            Time.fixedDeltaTime = 0.1f;
        else if (boost == 2)
            Time.fixedDeltaTime = 0.5f;

        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }

        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
            );
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;

        _segments.Add(segment);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();
            scoreCount++;
            AddHighScore();
            score.text = "Score: " + scoreCount.ToString() + " points";
        }
        else if (other.tag == "Obstacle")
        {
            Reset();
        }
        else if (other.tag == "Boost")
        {
            Grow();
            scoreCount++;
            AddHighScore();
            score.text = "Score: " + scoreCount.ToString() + " points";
            StartCoroutine(SnakeSpeed());
        }
        IEnumerator SnakeSpeed()
        {
            int rand = Random.Range(1, 2);
            boost = rand;
            yield return new WaitForSeconds(7f);
            boost = 0;
        }

    }
    private void AddHighScore()
    {
        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetInt("SaveScore", highScoreCount);
        }
    }
    private void Reset()
    {
        if (scoreCount == highScoreCount)
        {
            SceneManager.LoadScene("NewRecord");
            SceneController.sceneIndex = SceneManager.GetActiveScene().buildIndex;
            return;
        }
        scoreCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}