using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pistol : MonoBehaviour
{
    RaycastHit hit;
    
    public int currentAmmo=12;  //mermi say�s�
    public int maxAmmo=12; //silahtaki mermi alma kapasitesi
    public int carriedAmmo=60;  //ta��d���m�z mermi

    [SerializeField]
    float rateofFire;  //ne kadar s�rede ate� edilece�ini hesaplar
    float nextFire=0; //ba�lang�� s�resi

    [SerializeField]
    float weaponRange; //at�� mesafesi(ne kadar uza�a at�� yapabiliriz

    public Transform shootPoint; //merminin ��kaca�� yer

    public float damage = 20f;

   

    public ParticleSystem muzzleFlash;

    AudioSource pistolAS;
    public AudioClip shootAC;
    public AudioClip emptyFire;

    Animator anim;

    bool isReloading;

    public Text current;
    public Text carried;

    public GameObject bulletHole;
    public AudioClip shootMetalAC;

    public GameObject bloodEffect;
    public GameObject headShootBlood;
    private void Start()
    {
        UpdateAmmoUI();
        muzzleFlash.Stop(); //oyun ba�lad���nda �al��mas�n
        pistolAS = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();

    }
    private void Update()
    {
        if(currentAmmo>0 && Input.GetButton("Fire1")) //mouse'un sol tu�una bas�nca ve mermin varsa ate� et
        {
            Shoot();
        }
        else if (currentAmmo < 0 && Input.GetButton("Fire1") && !isReloading)
        {
            EmptyFire();
        }
        else if(Input.GetKeyDown(KeyCode.R) && currentAmmo <= maxAmmo && !isReloading)
        {
            isReloading = true;
            Reload();
        }
    }

    //her at�� aras�na 0.5 gibi belirli bir fark koyar.Yani 0.5 sn aral�k ile at�� yapmam�z� sa�lar
    void Shoot()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + rateofFire;

            anim.SetTrigger("Shoot");
            currentAmmo--; //at�� yap�ld��� i�in mermi azald�

            ShootRay();
        }

        UpdateAmmoUI();

    }

    void ShootRay()
    {

        if (Physics.Raycast(shootPoint.position, shootPoint.forward, out hit, weaponRange)) //merminin ��kaca�� yer,y�n�,hedef,mesafe(bizden ��kan ray bir yere vurursa)
        {
            if (hit.transform.tag == "Enemy")
            {
                EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
               Instantiate(bloodEffect, hit.point, transform.rotation);
                enemy.ReduceHealth(damage);
            }
            else if (hit.transform.tag == "Head")
            {
                EnemyHealth enemy = hit.transform.GetComponentInParent<EnemyHealth>(); //parent'i i�indeki scripte eri�ece�imiz i�in b�yle yazd�k
                enemy.ReduceHealth(100f); //kafas�na vurunca direkt �lecek
                Instantiate(headShootBlood, hit.point, transform.rotation);
                hit.transform.gameObject.SetActive(false);
            }
            else if (hit.transform.tag == "Metal")
            {
                pistolAS.PlayOneShot(shootMetalAC);
                Instantiate(bulletHole, hit.point,Quaternion.FromToRotation(Vector3.up,hit.normal)); //Instantiate ile gameobject olu�turabiliriz.
            }
            else
            {
                Debug.Log("Something else");
            }
        }
    }

    void Reload()
    {
        if (carriedAmmo <= 0) return;
        anim.SetTrigger("Reload");
        StartCoroutine(ReloadCountDown(2f));
        UpdateAmmoUI();
    }

    public void UpdateAmmoUI()
    {
        current.text = currentAmmo.ToString();
        carried.text = carriedAmmo.ToString();
    }
    //mermim yoksa 
    void EmptyFire()
    {
       if(Time.time >nextFire)  //s�rekli teti�e basamamak i�in
        {
            nextFire = Time.time + rateofFire;
            pistolAS.PlayOneShot(emptyFire);
            anim.SetTrigger("Empty");
        }
    }
   
    //ate� edildi�inde muzzle effect �al��s�n sonra dursun
    IEnumerator pistolEffect()
    {
        muzzleFlash.Play();
        pistolAS.PlayOneShot(shootAC);
        yield return new WaitForEndOfFrame();
        muzzleFlash.Stop();
    }

    IEnumerator ReloadCountDown(float timer)
    {
        while(timer > 0f)
        {
            
            timer -= Time.deltaTime;
            yield return null;
        }

        if(timer <= 0)
        {
            isReloading = false;
            int bulletNeeded=maxAmmo - currentAmmo; //�arj�rdeki mermileri fullemek i�in gereken mermi say�s�
            int bulletsToDeduct = (carriedAmmo >= bulletNeeded) ? bulletNeeded : carriedAmmo;
            carriedAmmo -= bulletsToDeduct;  //yan�mda ta��d���m mermiyi silaha koyuyorum
            currentAmmo += bulletsToDeduct;
            UpdateAmmoUI();
        }
    }
}
