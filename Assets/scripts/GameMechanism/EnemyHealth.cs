using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    [SerializeField] AudioSource dieSoundSource;
    [SerializeField] AudioClip dieSoundClip;


    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        if (hitPoints > 0)
        {
            hitPoints -= damage;

            if (hitPoints <= 0){
                Die();
            }
        }
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;
        dieSoundSource.PlayOneShot(dieSoundClip);
        GetComponent<Animator>().SetTrigger("Dead");
    }
}
