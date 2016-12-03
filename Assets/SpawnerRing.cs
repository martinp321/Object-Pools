using UnityEngine;
using System.Collections;


public class SpawnerRing : MonoBehaviour
{

    public int numberOfSpawners;
    public Spawner spawnerPrefab;
    public float radius, tiltAngle;

    void Awake()
    {
        for (int i = 0; i < numberOfSpawners; i++)
            createSpawners(i);

    }

    void createSpawners(int index)
    {
        Transform rotater = new GameObject("Rotater").transform;
        rotater.SetParent(transform, false);
        rotater.localRotation = Quaternion.Euler(0f, index * 360f / numberOfSpawners, 0f);

        Spawner spawner = Instantiate<Spawner>(spawnerPrefab);
        spawner.transform.SetParent(rotater, false);
        spawner.transform.localPosition = new Vector3(0f, 0f, radius);
        spawner.transform.localRotation = Quaternion.Euler(tiltAngle, 0f, 0f);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
