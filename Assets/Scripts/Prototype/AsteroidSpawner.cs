using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Material material;
    public GameObject asteroid;

    private float spawnTimer = 0f;

    private void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer < 0)
        {
            CreateAsteroid();
            spawnTimer = 1f;
        }
    }

    public void CreateAsteroid()
    {
        asteroid = ProcAsteroid.Clone(new Vector3(transform.position.x + Random.Range(1f, 3f), transform.position.y + Random.Range(1f, 3f), transform.position.z + Random.Range(1f, 3f)));
        asteroid.GetComponent<MeshRenderer>().sharedMaterial = material;
    }

}
