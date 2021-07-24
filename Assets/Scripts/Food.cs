using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    public Text score;

    public BoxCollider2D gridArea;
    public int scoreCount = 0;
    private Vector3 pos;

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
    { //Bounds dontSpawnBounds = this._dontSpawn.bounds;
        Bounds bounds = this.gridArea.bounds;

        pos.x = Random.Range(bounds.min.x, bounds.max.x);
        pos.y = Random.Range(bounds.min.y, bounds.max.y);

        for (int i = 0; i < _dontSpawn.Count; i++)
        {
            Bounds _dontSpawnBounds = this._dontSpawn[i].bounds;
            if (_dontSpawn[i].bounds.Contains(pos))
            {
                Debug.Log("ping");
                // pos.x = Random.Range(bounds.min.x, bounds.max.x);
                // pos.y = Random.Range(bounds.min.y, bounds.max.y);
                RandomizePosition();
            }


            //float xDontSpawn = _dontSpawn[i].min.x;
            /* if (x >= _dontSpawnBounds.min.x && x <= _dontSpawnBounds.max.x)
             {
                 Debug.Log("ping");
                 x = Random.Range(bounds.min.x, bounds.max.x);
             }
             if (y >= _dontSpawnBounds.min.y && x <= _dontSpawnBounds.max.y)
             {
                 Debug.Log("ping");
                 y = Random.Range(bounds.min.y, bounds.max.y);
             }
             */
            //private List<float> _dontSpawnCoordinate;
            // float _dontSpawnX = new List<float>() { _dontSpawn[i].min.x, _dontSpawn[i].max.x };
        }

        // float x = 10f;
        //float y = 1f;
        this.transform.position = new Vector3(Mathf.Round(pos.x), Mathf.Round(pos.y), 0.0f);

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
