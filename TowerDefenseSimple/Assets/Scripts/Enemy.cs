using UnityEngine.UI;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;

    

    [HideInInspector]
    public float speed = 10f;

    public float startHealth = 100;
    private float health;

    public int worth = 50;

    [Header("Death Effect")]
    public GameObject deathEffect;
    public AudioClip deathSound;

    [Header("Unity Stuff")] 
    public Image healthBar;
    
    void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;
        
        if (health <= 0)
        {
            Die();
        }
    }

    //percentage: pct
    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }    

    void Die()
    {
        PlayerStats.Money += worth;
        GameObject effect = (GameObject) Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 3f);

        //Debug.Log("Error hapen!!");
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        Destroy(gameObject);
    }

}
