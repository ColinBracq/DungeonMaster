using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float vitesse;
    public Rigidbody2D rb;
    public float dureeVie;
    public float degats;
    public bool ExploOuP = false;
    public float portéExplo;
    public bool ProjectAlliéOuEnnemi = false;

    public GameObject finProj;

    public void ParametreProj(float _vitesse, float _dureeVie, float _degats,float _porteExplo)
    {
        vitesse = _vitesse; dureeVie = _dureeVie; degats = _degats; portéExplo = _porteExplo;
    }

    private void Start()
    {
        
        rb.velocity = transform.up * vitesse;
        Destroy(gameObject, dureeVie);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (!ProjectAlliéOuEnnemi)
        {
            Ennemi ennemi = hitInfo.GetComponent<Ennemi>();
            if (ennemi != null)
            {
                ennemi.PrendreDegats(degats);
                if (ExploOuP)
                {
                    Collider2D[] ennemiesBlesses = Physics2D.OverlapCircleAll(rb.position,portéExplo);
                    for (int i = 0; i < ennemiesBlesses.Length; i++)
                    {
                        ennemiesBlesses[i].GetComponent<Ennemi>().PrendreDegats(degats);

                    }
                }

            }
        } else {
            Joueur joueur = hitInfo.GetComponent<Joueur>();
            if (joueur != null)
            {
                joueur.PrendreDegats(degats);
            }
        }
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, portéExplo);
    }
}
