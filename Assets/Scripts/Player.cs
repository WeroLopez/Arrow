using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoreGame.SystemMovements;
using UnityEngine.UI;
using CoreGame.ObjectPooler;

#pragma warning disable 0649

public class Player : MonoBehaviour {

    /*protected float healthValue;
    protected int manaValue;
    [SerializeField, Range(1, 1000)]
    protected float maxHealthValue;
    [SerializeField, Range(50,1000)]
    protected int maxManaValue;
    [SerializeField]
    protected float guardValue;
    [SerializeField]
    public float attackValue;
    protected bool usesMana;
    [SerializeField]
    protected GameObject healthBar;
    protected Image healthBarValue;
    [SerializeField]
    protected GameObject manaBar;
    protected Image manaBarValue;*/

    [SerializeField]
    protected float movementSpeed;
    protected Rigidbody rb;

    [SerializeField]
    Transform cameraPivot;

    protected ObjectPooler objectPooler;

    private void Awake()
    {
        objectPooler = ObjectPooler.Instance;
        rb = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start () {
        /*healthBarValue = healthBar.transform.GetChild(1).GetComponent<Image>();
        healthValue = maxHealthValue;
        RefreshHealth(0f);
        if (usesMana)
        {
            manaValue = maxManaValue;
            manaBar.SetActive(true);
            manaBarValue = manaBar.transform.GetChild(1).GetComponent<Image>();
            RefreshMana(0);
            StartCoroutine(ManaRegen());
        }*/
    }
	
	// Update is called once per frame
	void Update ()
    {
        PlayerMove.Move(transform, rb, cameraPivot, movementSpeed);
    }
    
    protected void OnCollisionEnter(Collision collision)
    {
        /*if (collision.gameObject.tag == "Spike") {
            RefreshHealth(-collision.gameObject.GetComponent<Spike>().spike);
        }*/
    }

    protected void OnTriggerEnter(Collider other)
    {
        /*if (other.tag == "HealthPickup") {
            RefreshHealth(other.GetComponent<PickupValue>().value);
            Destroy(other.transform.parent.gameObject);
            audioSource.PlayOneShot(audioPickUp);
        }*/
        /*else if (other.tag == "Damage") {
            RefreshHealth(-100f);
        }*/
    }

    /*public void RefreshHealth(float healthChange)
    {
        healthValue = healthValue + healthChange < 0 ? 0 :
            healthValue + healthChange > maxHealthValue ? maxHealthValue :
            healthValue + healthChange;

        healthBarValue.fillAmount = healthValue / maxHealthValue;
        if(healthChange < 0)
        {
            audioSource.PlayOneShot(audioDamage);
        }
        if (healthValue <= 0)
        {
            objectPooler.GetObjectFromPool("EnemyExplosion", transform.position, transform.rotation, null);
            gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// regresa true si se hay mana suficiente para substraer el mana del mana actual,
    /// regresa false si no hay suficiente mana
    /// </summary>
    /// <param name="manaChange">cantidad de mana en la que va a cambiar; (-) para quitar, (+) para agregar</param>
    /// <returns></returns>
    protected virtual bool RefreshMana(int manaChange)
    {
        if (manaValue + manaChange < 0)
            return false;
        manaValue = manaValue + manaChange > maxManaValue ? maxManaValue
            : manaValue + manaChange;
        //refrescar la barra de mana
        manaBarValue.fillAmount = (float)manaValue / maxManaValue;

        return true;
    }

    IEnumerator ManaRegen()
    {
        while (true)
        {
            RefreshMana(5);
            yield return new WaitForSeconds(1f);
        }
    }*/
}
