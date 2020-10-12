using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPlayer : MonoBehaviour
{
    float speed, minDist;
    bool isHurt;
    // Start is called before the first frame update
    void Start()
    {
        speed = 4f;
        minDist = 2f;
        isHurt = false;
    }
    IEnumerator Die()
    {
        GetComponent<Animation>().Play("die");
        yield return new WaitForSeconds(2);
        this.gameObject.SetActive(false);
    }

    public void Hurt()
    {
        isHurt = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (isHurt)
        {
            StartCoroutine(Die());

        }
        else
        { 
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        GetComponent<Animation>().Play("walk");
        Ray r = new Ray(transform.position,transform.forward);

        RaycastHit hit;

        if (Physics.SphereCast(r, 0.5f, out hit))
        {
            if(hit.distance < minDist)
            {
                float angle = Random.Range(-100, 100);
                transform.Rotate(new Vector3(0,angle,0));
            }//change diraction
        }; // check obstacle
        }
    }
}
