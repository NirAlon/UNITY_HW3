using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public Camera aCamera;
    public GameObject target;
    public GameObject gunEnd;
    LineRenderer shootLine;
    WaitForSeconds shootDuration = new WaitForSeconds(0.1f);
    public GameObject npc;
    // Start is called before the first frame update
    void Start()
    {
        shootLine = GetComponent<LineRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetButtonDown("Shoot"))
        {
            RaycastHit hit;
            if (Physics.Raycast(aCamera.transform.position,aCamera.transform.forward,out hit))
            {
                GetComponent<AudioSource>().Play();
                StartCoroutine(GunShooting());
                target.SetActive(true);
                target.transform.position = hit.point;
                shootLine.SetPosition(0, gunEnd.transform.position);
                shootLine.SetPosition(1, hit.point);


                if (Vector3.Distance(hit.point, npc.transform.position) < 5)
                {
                    npc.GetComponent<NPCPlayer>().Hurt();
                }
            }
        }
    }

    IEnumerator GunShooting()
    {
        shootLine.enabled = true;
        yield return shootDuration;
        shootLine.enabled = false;

    }
}
