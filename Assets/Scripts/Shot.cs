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

    public AudioSource audioSource;
    public ParticleSystem particlePrefab;
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
                Invoke("AnimationEnable", 0.2f);
                Invoke("BulletInst", 0.3f);

            }
        }
        
    }

    void AnimationEnable()
    {
        animator.enabled = true;
    }
    void AnimationDisable()
    {
        animator.enabled = false;
        audioSource.enabled = false;
    }
    public void BulletInst()
    {

        ParticleSystem particleSystem = Instantiate(particlePrefab);

        // Set the position and rotation of the instantiated particle system
        particleSystem.transform.position = bulletPos.transform.position;
        particleSystem.transform.rotation = bulletPos.transform.rotation;

        // Play the particle system
        particleSystem.Play();
        audioSource.enabled = true;
        Instantiate(bullet, bulletPos.transform.position, bulletPos.transform.rotation);
        Invoke("AnimationDisable" , 1f);
       
    }
}
