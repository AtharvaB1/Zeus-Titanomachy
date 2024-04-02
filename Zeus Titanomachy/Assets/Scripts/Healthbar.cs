using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Healthbar : MonoBehaviour
{
    [SerializeField] public Image HealthBarSprite;

    private Camera cam;
    private void Start()
    {
        cam = Camera.main;
    }
    public void updateHealthBar(float max, float current)
    {
        HealthBarSprite.fillAmount = current / max;
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
    }
}
