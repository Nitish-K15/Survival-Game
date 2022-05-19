using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AquariusMax.Demo
{
    public class SiegeWeaponFire : MonoBehaviour
    {

        public GameObject bulletPrefab;

        [SerializeField]
        bool autoSpawnBullets = false;

        [HideInInspector]
        public bool isLoaded = false;
        [HideInInspector]
        public bool isReady = false;

        [SerializeField]
        float fireSpeed = 1800.0f;

        Animator anim;

        [SerializeField]
        Transform loadPoint;

        GameObject bulletInstance;

        private void Awake()
        {
            anim = GetComponent<Animator>();

            // if not specified in editor, choose by naming convention
            if (loadPoint == null)
            {
                loadPoint = transform.Find("LoadPoint");
            }
        }

        public void Activate()
        {
            if (!isReady)
            {
                Ready();
                return;
            }

            if (isReady && !isLoaded)
            {
                // TODO: sync up with pickup script
                LoadBullet(null);
                return;
            }

            if (isReady && isLoaded)
            {
                Fire();
                return;
            }
        }

        public void Ready()
        {
            if (!isReady)
            {
                anim.SetTrigger("Load");
                isReady = true;
            }
        }

        public void LoadBullet(GameObject bullet)
        {
            if (isReady && !isLoaded)
            {
                if (bullet == null && autoSpawnBullets)
                {
                    bulletInstance = Instantiate(bulletPrefab, loadPoint);
                    Rigidbody bulletRB = bulletInstance.GetComponent<Rigidbody>();
                    if (bulletRB != null)
                    {
                        bulletRB.isKinematic = true;
                    }

                    isLoaded = true;
                }

                if (bullet != null)
                {
                    bulletInstance = bullet;
                    bullet.transform.position = loadPoint.position;
                    bullet.transform.parent = loadPoint;
                    var rb = bullet.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.isKinematic = true;
                    }

                    isLoaded = true;
                }
            }
        }

        public void Fire()
        {
            if (isLoaded)
            {
                anim.SetTrigger("Fire");
            }
        }

        void OnAnimFire()
        {
            isReady = false;
            isLoaded = false;
            Rigidbody bulletRB = bulletInstance.GetComponent<Rigidbody>();
            if (bulletRB != null)
            {
                bulletRB.isKinematic = false;
                bulletInstance.transform.parent = null;
                // bulletRB.AddForce(loadPoint.forward * fireSpeed * Time.deltaTime);
                bulletRB.velocity = loadPoint.forward * fireSpeed * Time.deltaTime;
            }

            bulletInstance = null;
        }
    }
}
