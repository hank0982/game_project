using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimate : MonoBehaviour
{
    [SerializeField] private KeyCode attackKey;
    private Animator animator;
    private bool isAttacking = false;
    public AudioClip[] playerMusicClip;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void AttackInput()
    {
       
        if (Input.GetKeyDown(attackKey) && !isAttacking)
        {
            StartCoroutine("AttackRoutine");
            isAttacking = true;
            //int randomAttackMusicClip = Random.Range(0, 4);
            //audioSource.clip = playerMusicClip[randomAttackMusicClip];
            //audioSource.Play();
        }

    }
    IEnumerator AttackRoutine()
    {
        int randomAttack = Random.Range(1, 3);
        animator.SetInteger(Animator.StringToHash("Condition"), randomAttack);
        yield return new WaitForSeconds(0.5f);
        animator.SetInteger(Animator.StringToHash("Condition"), 0);
        isAttacking = false;
    }
    // Update is called once per frame
    void Update()
    {
        AttackInput();
    }
}
