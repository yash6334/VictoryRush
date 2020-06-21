using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] ParticleSystem muzzleParticle;

    [SerializeField] float range = 100f;
    [SerializeField] float damage = 10f;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] float timeBetweenShots;
    [SerializeField] AmmoType ammoType;

    [SerializeField] AudioSource bulletSoundSource;
    [SerializeField] AudioClip bulletSoundClip;

    bool canShoot = true;

    private void OnEnable()
    {
        canShoot = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ammoSlot.GetAmmoAmount(ammoType) > 0 && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        PlayMuzzleFlash();
        ProcessRaycast();
        ProcessSound();
        ammoSlot.ReduceAmmoAmount(ammoType);

        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void ProcessSound()
    {
        bulletSoundSource.PlayOneShot(bulletSoundClip);
    }

    private void PlayMuzzleFlash()
    {
        muzzleParticle.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        var hitEffectGameObject = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(hitEffectGameObject, .1f);
    }
}
