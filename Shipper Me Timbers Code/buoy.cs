using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buoy : MonoBehaviour
{
    public AudioClip alarm;
    private AudioSource source;
    public float maxRayDistance= 2;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }
	void Update ()
    {
        Ray ray = new Ray(transform.position, Vector3.left);
        Ray ray2 = new Ray(transform.position, Vector3.right);
        RaycastHit hit;


        Debug.DrawLine(transform.position, transform.position + Vector3.left * maxRayDistance, Color.red);
        Debug.DrawLine(transform.position, transform.position + Vector3.right * maxRayDistance, Color.green);
        if (Physics.Raycast(ray, out hit, maxRayDistance))
        {
            source.PlayOneShot(alarm, .1f);
        }

        if (Physics.Raycast(ray2, out hit, maxRayDistance))
        {
            source.PlayOneShot(alarm, .2f);
        }

    }
}
