using UnityEngine;
using UnityEngine.UI;


public class ArmeManager : MonoBehaviour
{
    public Transform attackPos;
    public Arme arme;

    public Image visuel;

    public LayerMask ennemies;
    private float cooldown;
    private Vector3 forceRecul;
    public string toucheAttaque = "Fire1";
    public string animMelee = "Melee1";
    public Animator JoueurAnim;

    // Start is called before the first frame update
    void Start()
    {
        visuel.sprite = arme.imageArme;
        visuel.material = arme.materialArme;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Attaque(arme, toucheAttaque);
    }

    void AttaqueMelee(Arme arme, string numeroArme)
    {

        Collider2D[] ennemiesBlesses = Physics2D.OverlapCircleAll(attackPos.position, arme.portee, ennemies);
        forceRecul = attackPos.transform.up;
        for (int i = 0; i < ennemiesBlesses.Length; i++)
        {
            ennemiesBlesses[i].GetComponent<Ennemi>().PrendreDegats(arme.dommage);
            ennemiesBlesses[i].GetComponent<Ennemi>().rb.AddForce(forceRecul);

        }
        JoueurAnim.SetTrigger(animMelee);
    }

    private void AttaqueDistance(Arme arme, string touche)
    {
        var obj = Instantiate(arme.projectile, attackPos.position, transform.rotation);
        obj.GetComponent<Projectile>().ParametreProj(arme.vitesseProj, arme.portee, arme.dommage, arme.porteeExplo);
        JoueurAnim.SetTrigger(animMelee);
    }


    void ChoixAttaque(Arme arme, string touche)
    {
        switch (arme.type)
        {
            case "Arme de mélée":
                AttaqueMelee(arme, touche);
                break;
            case "Arme à distance":
                AttaqueDistance(arme, touche);
                break;
            case "Rien":
                Debug.Log("Rien");
                break;
            default:
                Debug.Log("Type d'arme inconnue");
                break;

        }

    }



    void Attaque(Arme arme, string touche)
    {
        if (Input.GetButton(touche))
        {

            if (Time.time >= cooldown)
            {
                ChoixAttaque(arme, touche);
                cooldown = Time.time + 1f / arme.cadence;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, arme.portee);
    }
}