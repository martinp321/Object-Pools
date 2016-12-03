using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Atom : MonoBehaviour
{

    public float attractionForce;

    Rigidbody body;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }
    // Use this for initialization

    private void FixedUpdate()
    {
        body.AddForce(transform.localPosition * -attractionForce);
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
