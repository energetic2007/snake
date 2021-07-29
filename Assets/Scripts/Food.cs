using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] GameObject innerWalls;
    [SerializeField] BoxCollider2D gridArea;
    private void Start()
    {
        Spawn();
    }
    public void Spawn()
    {
        Bounds bounds = this.gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);

        BoxCollider2D[] colliders = innerWalls.GetComponentsInChildren<BoxCollider2D>();

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].bounds.Contains(this.transform.position))
            {
                Spawn();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            Spawn();
    }
}