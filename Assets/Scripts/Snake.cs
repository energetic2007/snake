using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;

    private List<Transform> _segments;
    [SerializeField] Transform segmentPrefab;
    private int scoreCount = 0;
    public static Snake instance;
    [SerializeField] private Text score;
    private void Awake()
    {
        instance = this;
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
        if (other.tag == "Food" || other.tag == "Boost")
        {
            Grow();
            scoreCount++;
            Score.AddHighScore(scoreCount);
            score.text = "Score: " + scoreCount.ToString() + " points";
        }
        if (other.tag == "Obstacle")
        {
            Reset();
        }
    }
    private void Reset()
    {
        if (Score.AddHighScore(scoreCount))
        {
            SceneManager.LoadScene("NewRecord");
            SceneController.previousSceneIndex = SceneManager.GetActiveScene().buildIndex;
            return;
        }
        scoreCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}