using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickGun : MonoBehaviour
{
    public GameObject gunOnTable;
    public GameObject gunInHand;
    public GameObject Aim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        gunOnTable.SetActive(false);
        gunInHand.SetActive(true);
        Aim.SetActive(true);
    }
}
