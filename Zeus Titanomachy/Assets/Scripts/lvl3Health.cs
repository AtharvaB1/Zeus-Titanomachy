using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvl3Health : MonoBehaviour
{
    public static float zHealth = 100f;
    public static float t1Health = 100f;
    public static float t2Health = 100f;
    public static float t3Health = 100f;
    public GameObject t1;
    public GameObject t2;
    public GameObject t3;
    public GameObject t1S;
    public GameObject t2S;
    public GameObject t3S;
    public static bool ext1 = false;
    public static bool ext2 = false;
    public static bool ext3 = false;
    public GameObject bolt;
    public static bool bgot = false;
    bool spawn;
    // Start is called before the first frame update
    void Start()
    {
        spawn = false;
        zHealth = 100f;
        t1Health = 100f;
        t2Health = 100f;
        t3Health = 100f;
        ext1 = false;
        ext2 = false;
        ext3 = false;
        bgot = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (t1Health <= 0)
        {
            Destroy(t1); ext1 = true; Destroy(t1S);
        }
        if (t2Health <= 0)
        {
            Destroy(t2); ext2 = true; Destroy(t2S);
        }
        if (t3Health <= 0)
        {
            Destroy(t3); ext3 = true; Destroy(t3S);
        }
        if(zHealth <= 0)
        {
            SceneManager.LoadScene(5);
        }
        if(ext1 && ext2 && ext3&&!spawn)
        {
            Instantiate(bolt,new Vector3(0,3,0), Quaternion.identity);
            spawn = true;
        }
    }
}
