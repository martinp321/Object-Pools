using UnityEngine;
using System.Collections;

[System.Serializable]
public struct FloatRange
{
    public float RandomInRange
    {
        get
        {
            return Random.Range(.1f, 1f);
        }
    }
}

public class Spawner : MonoBehaviour
{
    public Material stuffMaterial;
    public FloatRange timeBetweenSpawns;
    public Stuff[] stuffPrefabs;
    float timeSinceLastSpawn;

    public float velocity;

    private float currentSpawnDelay;

    private void FixedUpdate()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= currentSpawnDelay)
        {
            timeSinceLastSpawn = 0;
            currentSpawnDelay = timeBetweenSpawns.RandomInRange;
            SpawnStuff();
        }
    }

    void SpawnStuff()
    {

        int prefabIdx = Random.Range(0, stuffPrefabs.Length);
        Stuff prefab = stuffPrefabs[prefabIdx];
        Stuff spawn = prefab.GetPooledInstance<Stuff>();

        spawn.transform.localPosition = transform.position;
        spawn.Body.velocity = transform.up * velocity;
        spawn.SetMaterial(stuffMaterial);

    }
}
