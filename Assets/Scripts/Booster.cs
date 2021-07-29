using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    public float spawnTime;
    public float spawnDelay;
    public BoxCollider2D gridArea;

    public Renderer _renderer;
    [SerializeField] GameObject innerWalls;

    private void Start()
    {
        Spawn();
    }
    private void Spawn()
    {
        Bounds bounds = this.gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
        StartCoroutine(DelayAction());

        BoxCollider2D[] colliders = innerWalls.GetComponentsInChildren<BoxCollider2D>();
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].bounds.Contains(this.transform.position))
            {
                Spawn();
            }
        }
    }

    IEnumerator DelayAction()
    {
        _renderer.enabled = false;
        yield return new WaitForSeconds(20f);
        _renderer.enabled = true;
        yield return new WaitForSeconds(10f);
        Spawn();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Obstacle")
        {
            Spawn();
        }
    }
}
