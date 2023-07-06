using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pistol : MonoBehaviour
{
    RaycastHit hit;
    
    public int currentAmmo=12;  //mermi sayýsý
    public int maxAmmo=12; //silahtaki mermi alma kapasitesi
    public int carriedAmmo=60;  //taþýdýðýmýz mermi

    [SerializeField]
    float rateofFire;  //ne kadar sürede ateþ edileceðini hesaplar
    float nextFire=0; //baþlangýç süresi

    [SerializeField]
    float weaponRange; //atýþ mesafesi(ne kadar uzaða atýþ yapabiliriz

    public Transform shootPoint; //merminin çýkacaðý yer

    public float damage = 20f;

    EnemyHealth enemy;

    public ParticleSystem muzzleFlash;

    AudioSource pistolAS;
    public AudioClip shootAC;
    public AudioClip emptyFire;

    Animator anim;

    bool isReloading;

    public Text current;
    public Text carried;

    private void Start()
    {
        UpdateAmmoUI();
        muzzleFlash.Stop(); //oyun baþladýðýnda çalýþmasýn
        enemy = FindObjectOfType<EnemyHealth>();
        pistolAS = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();

    }
    private void Update()
    {
        if(currentAmmo>0 && Input.GetButton("Fire1")) //mouse'un sol tuþuna basýnca ve mermin varsa ateþ et
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

    //her atýþ arasýna 0.5 gibi belirli bir fark koyar.Yani 0.5 sn aralýk ile atýþ yapmamýzý saðlar
    void Shoot()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + rateofFire;

            anim.SetTrigger("Shoot");
            currentAmmo--; //atýþ yapýldýðý için mermi azaldý

            ShootRay();
        }

        UpdateAmmoUI();

    }

    void ShootRay()
    {

        if (Physics.Raycast(shootPoint.position, shootPoint.forward, out hit, weaponRange)) //merminin çýkacaðý yer,yönü,hedef,mesafe(bizden çýkan ray bir yere vurursa)
        {
            if (hit.transform.tag == "Enemy")
            {
                enemy.ReduceHealth(damage);
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
       if(Time.time >nextFire)  //sürekli tetiðe basamamak için
        {
            nextFire = Time.time + rateofFire;
            pistolAS.PlayOneShot(emptyFire);
            anim.SetTrigger("Empty");
        }
    }
   
    //ateþ edildiðinde muzzle effect çalýþsýn sonra dursun
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
            int bulletNeeded=maxAmmo - currentAmmo; //þarjördeki mermileri fullemek için gereken mermi sayýsý
            int bulletsToDeduct = (carriedAmmo >= bulletNeeded) ? bulletNeeded : carriedAmmo;
            carriedAmmo -= bulletsToDeduct;  //yanýmda taþýdýðým mermiyi silaha koyuyorum
            currentAmmo += bulletsToDeduct;
            UpdateAmmoUI();
        }
    }
}
