using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHit : MonoBehaviour
{
    public AudioClip[] weaponClips;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "Monster")
        {
            int randomWeaponClip = Random.Range(0, weaponClips.Length);
            audioSource.clip = weaponClips[randomWeaponClip];
            audioSource.Play();
        }
    }
}
