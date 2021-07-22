using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    public Text score;

    public BoxCollider2D gridArea;
    public int scoreCount = 0;
    [SerializeField] private List<BoxCollider2D> _dontSpawn;

    // private void FixedUpdate()
    // {
    //     RandomizePosition();
    // }
    private void Start()
    {
        RandomizePosition();
    }
    private void RandomizePosition()
    {
        Bounds bounds = this.gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        // float x = 10f;
        //float y = 1f;
        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);

        //   Debug.Log("randomizing");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Player")
        {
            RandomizePosition();
            scoreCount++;
            score.text = "Score: " + scoreCount.ToString() + " points";

        }
        else if (other.tag == "Obstacle")
        {
            Debug.Log("ping");
            RandomizePosition();
        }
    }
}
