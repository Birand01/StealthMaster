using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public delegate void OnBulletSoundHandler(SoundType soundType,bool state);
    public static event OnBulletSoundHandler OnBulletSound;

    [SerializeField] private List<Transform> shootPoints;
    internal GameObject bulletPrefab;
    internal float bulletSpeed, reloadDelay;
    private float currentDelay;
    private Collider[] colliders;
    private bool canShoot = true;

    //private BulletPool bulletPool;
    //[SerializeField] private int bulletPoolCount = 10;
    protected virtual void Awake()
    {
        //bulletPool = GetComponent<BulletPool>();
        colliders = GetComponentsInParent<Collider>();
    }
    protected virtual void Start()
    {
        //bulletPool.Inýtýalize(bulletPrefab, bulletPoolCount);
    }
    protected virtual void Update()
    {
        if (canShoot == false)
        {
            
            currentDelay -= Time.deltaTime;
            if (currentDelay <= 0)
            {
               
                canShoot = true;
              
            }
        }
    }
    public virtual void Shoot(IDamageable damageable,bool state)
    {
        if(state)
        {
            if (canShoot && this.gameObject.GetComponentInParent<EnemyHealth>().Health>0)
            {
                canShoot = false;
                currentDelay = reloadDelay;

                foreach (var barrel in shootPoints)
                {
                    OnBulletSound?.Invoke(SoundType.BulletSound, true);
                    //GameObject bullet = bulletPool.CreateObject();
                    GameObject bullet = Instantiate(bulletPrefab);
                    bullet.transform.position = barrel.position;
                    bullet.transform.localRotation = barrel.rotation;
                    Vector3 direction = damageable.GetTransform().position - bullet.transform.position;
                    bullet.transform.LookAt(damageable.GetTransform());
                    bullet.GetComponent<Rigidbody>().velocity = direction * bulletSpeed;
                   
                    foreach (var collider in colliders)
                    {
                        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), collider);
                    }
                }

            }

        }
    }


}
