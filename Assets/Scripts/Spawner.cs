using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 1f;
    public int minHeight;
    public int maxHeight;

    private void OnEnable() {
        InvokeRepeating(nameof(SpawnPipes), spawnRate, spawnRate);
    }

    private void OnDisable() {
        CancelInvoke(nameof(SpawnPipes));
    }

    private void SpawnPipes() {
        GameObject pipe = Instantiate(pipePrefab, transform.position, Quaternion.identity);
        pipe.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }

}
