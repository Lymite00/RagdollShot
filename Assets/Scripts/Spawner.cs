using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int lineCount;
    public int spawnInterval;
    public float spawnPos;
    public int spawnToRagdoll;
    public GameObject ragdollPrefab;
    public Transform startTransform;

    void Start()
    {
        startTransform.position = transform.position;
        SpawnRagdoll();
    }

    void Update()
    {
        if (spawnToRagdoll > 0)
        {
            SpawnRagdoll();
        }
    }

    public void SpawnRagdoll()
    {

        if (lineCount <= 2)
        {
            var position = startTransform.position;

            position = new Vector3(position.x, position.y, position.z - 5f * spawnToRagdoll);
            Instantiate(ragdollPrefab, position, Quaternion.Euler(0f, -90f, 0f));

        }
        else if (lineCount<=4)
        {
            var position = startTransform.position;

            position = new Vector3(position.x + 2f, position.y, position.z - 5f * spawnToRagdoll);
            Instantiate(ragdollPrefab, position, Quaternion.Euler(0f, -90f, 0f));

        }
        else
        {
            var position = startTransform.position;
            position = new Vector3(position.x + 4f, position.y, position.z - 5f * spawnToRagdoll);
            Instantiate(ragdollPrefab, position, Quaternion.Euler(0f, -90f, 0f));

        }
       

        lineCount++;
        spawnToRagdoll--;
    }
}