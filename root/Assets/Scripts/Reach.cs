using UnityEngine;
using System.Collections;

public class Reach : MonoBehaviour 
{
    public GameObject ep;
    public float speed = 1.0f;
    //private float startTime;
    //private float tDist;

	void Start () 
    {
        //startTime = Time.time;
        //tDist = Vector3.Distance(transform.position, ep.transform.position);
	}
	

	void Update () 
    {
        //print(ep.transform.position);
        //print(transform.position);

        //float fracDist = ((Time.time - startTime) * speed) / tDist;
        transform.position = Vector3.Lerp(transform.position,ep.transform.position, .5f);
	}
}
