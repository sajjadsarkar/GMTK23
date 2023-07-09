using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public Camera Camera1;
    public Camera Camera2;

    public GameObject bullet;

    public Transform bulletPos;

    public Animator animator;
    public string ShotAnime;


    // Start is called before the first frame update
    void Start()
    {
        /*        Camera1.enabled = true;
                Camera2.enabled = false;*/
        Invoke("BulletInst", 0.2f);
    }

    // Update is called once per frame
    void Update()
    {

        if(bullet != null)
        {
            if (Bullet.bullet.isDestroyed)
            {
                Invoke("BulletInst", 0.5f);
                animator.SetBool(ShotAnime, true);
            }
        }
   
    }

    public void BulletInst()
    {
        Instantiate(bullet, bulletPos.transform.position, bulletPos.transform.rotation);
    }
}
