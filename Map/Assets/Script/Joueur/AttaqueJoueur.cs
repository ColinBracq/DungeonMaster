using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttaqueJoueur : MonoBehaviour
{
    public Transform attackPos;
    public Arme arme1;
    public Arme arme2;

    public GameObject GOarme1;
    public GameObject GOarme2;
    public LayerMask ennemies;
    private float cooldown;

    public string toucheAttaque1 = "Fire1";
    public string toucheAttaque2 = "Fire2";

    public Animator JoueurAnim;
    // Update is called once per frame
    void Update()
    {
        Attaque(arme1,toucheAttaque1);
        Attaque(arme2,toucheAttaque2);
    }

    void AttaqueMelee(Arme arme,string numeroArme)
    {
        
        Collider2D[] ennemiesBlesses = Physics2D.OverlapCircleAll(attackPos.position, arme.portee, ennemies);
        for (int i = 0; i< ennemiesBlesses.Length; i++)
        {
            ennemiesBlesses[i].GetComponent<Ennemi>().PrendreDegats(arme.dommage);

        }
        if (numeroArme == toucheAttaque1)
        {
            JoueurAnim.SetTrigger("Melee1");
        }
        else if (numeroArme == toucheAttaque2)
        {
            JoueurAnim.SetTrigger("Melee2");
        }
    }

    void Attaque(Arme arme,string touche)
    {
        if (Input.GetButton(touche))
        {
            if (Time.time >= cooldown)
            {
                switch (arme.type)
                {
                    case "Arme de mélée":
                        AttaqueMelee(arme, touche);
                        break;
                    default:
                        Debug.Log("Type d'arme inconnue");
                        break;

                }

                cooldown = Time.time + 1f / arme.cadence;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, arme1.portee);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPos.position, arme2.portee);
    }
}
