using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [Header("Movement")]
    public float swervespeed = 3f;
    public float swerveamount = 2f;
    private float startX;
    [Header("Spawning")]
    public GameObject enemyprefab;
    public float spawnRate = 1.5f;
    public float xMin = -3f;
    public float xMax = 3f;
    public float ySpawn = 6f;
    void Start()
    {
        startX = transform.position.x;

        if (enemyprefab != null)
            StartCoroutine(SpawnEnemies());
    }

    void Update()
    {
        transform.Translate(Vector3.down * 3f * Time.deltaTime);

        float newX = startX + Mathf.Sin(Time.time * swervespeed) * swerveamount;
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

        if (transform.position.y < -6.5f)
            Destroy(gameObject);
    }
        
    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);

            // Spawn at random horizontal position
            Vector3 spawnPos = new Vector3(Random.Range(xMin, xMax), ySpawn, 0);
            Instantiate(enemyprefab, spawnPos, Quaternion.identity);
        }
    }
}
