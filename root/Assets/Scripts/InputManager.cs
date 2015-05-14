using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class InputManager : MonoBehaviour
{
    public GameObject PlayerManager; //user defined types (classes) are always by reference
    public GameObject raycastPos;
    public void Kick(Vector3 dir, Vector3 pos, float kickForce)
    {
        RaycastHit hit;

        if (Physics.Raycast(pos, dir, out hit, .5f))
        {
            if (hit.rigidbody != null && hit.transform.tag == "Interactable")
                hit.rigidbody.AddForce(dir * kickForce);
        }
    }

    // cast rays and return if one of the rays hit an object with a tag being searched for
    bool cast(Vector3 dir, Vector3 pos, string tag, float dist, out RaycastHit hit)
    {
        bool success = false;
        hit = new RaycastHit();
        foreach (RaycastHit hits in Physics.RaycastAll(pos, dir, dist))
            if (hits.collider.CompareTag(tag))
            {
                hit = hits;
                success = true;
            }
        return success;
    }
    

    public void Interact(Vector3 dir, Vector3 pos)
    {

        /////////////////////////////////////////////////////
        //RaycastHit t;
        //bool hitchair = cast(dir, pos, "Seat", 2.5f, out t);
        /////////////////////////////////////////////////////


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //Debug.DrawLine(pos, pos + dir * 2.5f, Color.blue, 2);

        if (Physics.Raycast(pos, dir, out hit, 2.5f))
        {
            //Debug.DrawRay(pos, dir, Color.green, 2, true);
            Debug.DrawLine(pos, pos + dir * 2.5f, Color.green, 2);
            Debug.Log(hit.transform.tag + " was hit!");
        }
        else
        {
            Debug.Log("ray didn't hit anything.");
            Debug.DrawLine(pos, pos + dir * 2.5f, Color.red, 2);
            // Debug.DrawRay(pos, pos + dir * 2.5f, Color.red, 2);
        }
    }

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        Vector3 p_pos = PlayerManager.GetComponent<PlayerManager>().Player.transform.position;
        Vector3 p_fwd = PlayerManager.GetComponent<PlayerManager>().Player.transform.forward; // TransformDirection(Vector3.forward);

        Vector3 cam_pos = Camera.main.transform.position;
        Vector3 cam_fwd = Camera.main.transform.forward;

        bool b_Interact = PlayerManager.GetComponentInChildren<FirstPersonController>().canInteract;

        if (b_Interact)
        {
            //cast rays to find the object I'm colliding with.
            //display item name.



        }

        //hitRay = new Ray(cam_pos, cam_fwd);
        switch (Input.inputString)
        {
            case " ": PlayerManager.GetComponent<PlayerManager>().TakeDamage(20);
                break;
            case "f":
                {
                    Kick(p_fwd, p_pos, PlayerManager.GetComponent<PlayerManager>().kickForce);
                }
                break;
            case "e":
                {
                    Interact(cam_fwd, raycastPos.transform.position);
                }
                break;
        }
    }
}
