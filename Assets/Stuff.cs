using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Stuff : PooledObject
{
    public Rigidbody Body { get; private set; }
    MeshRenderer[] meshRenderers;

    private void OnLevelWasLoaded(int level)
    {
        ReturnToPool();
    }

    private void Awake()
    {
        Body = GetComponent<Rigidbody>();
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Kill Zone"))
            ReturnToPool();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetMaterial(Material stuffMaterial)
    {
        foreach (MeshRenderer mr in meshRenderers)
        {
            mr.material = stuffMaterial;
        }

    }
}
