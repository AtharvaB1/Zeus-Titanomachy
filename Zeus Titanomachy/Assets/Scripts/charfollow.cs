using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charfollow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject zeus;
    int k;
    static bool kYes;
    void Start()
    {
        this.transform.position = zeus.transform.position;
        k = 0;
        kYes = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(k);
        if (k == 0)
        {
            this.transform.position= new Vector3(zeus.transform.position.x+1, zeus.transform.position.y + 11, zeus.transform.position.z);
            //really scuffed, need to fix so rotate works too
        }
        else
        {
            this.transform.position = new Vector3(zeus.transform.position.x-7,zeus.transform.position.y+13,zeus.transform.position.z-3);
            //really scuffed, fix rotate again
        }
        if (kYes && Input.GetKeyDown(KeyCode.L))
        {
            if(k>=1)
            k = 0;
            else
            k++;
        }

    }
}
