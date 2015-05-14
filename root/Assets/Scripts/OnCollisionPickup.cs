using UnityEngine;
using System.Collections;

public class OnCollisionPickup : MonoBehaviour {

    public GameObject inventory;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            inventory.GetComponent<PlayerInventory>().items.Add(gameObject);
            Object.DontDestroyOnLoad(gameObject);
            Object.DontDestroyOnLoad(col.gameObject);
            gameObject.transform.parent = col.transform;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            //gameObject.transform.localPosition.x = 0;
            
            gameObject.SetActive(false);
            Application.LoadLevel("DDOL2");
        }
    }

	void Start () 
    {
	
	}
	

	void Update () 
    {
	
	}
}
