using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea;
    private Vector3 pos;
    [SerializeField] GameObject innerWalls;

    private void Start()
    {
        RandomizePosition();
    }
    private void RandomizePosition()
    {
        Bounds bounds = this.gridArea.bounds;

        pos.x = Random.Range(bounds.min.x, bounds.max.x);
        pos.y = Random.Range(bounds.min.y, bounds.max.y);
        this.transform.position = new Vector3(Mathf.Round(pos.x), Mathf.Round(pos.y), 0.0f);

        BoxCollider2D[] colliders = innerWalls.GetComponentsInChildren<BoxCollider2D>();

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].bounds.Contains(this.transform.position))
            {
                RandomizePosition();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("I have collided with smth. It is: ");
        Debug.Log(other.tag);

        if (other.tag == "Player")
        {
            RandomizePosition();
        }
    }
}
