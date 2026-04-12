using UnityEngine;
using UnityEngine.EventSystems; //!verfier si permission d'utiliser !!!!!!

public class Pointage : MonoBehaviour
{


    string[] nomBulle = { "bulle_1", "bulle_2", "bulle_3" };
    string[] nomBoite = { "boite_1", "boite_2", "boite_3", "boite_4", "boite_5", "boite_6" };
    private int points = 0;
    private bool BonneBoite = false;
    private bool MauvaiseBoite = false;

    private bool DeuxiemeBoiteActivee = false;


  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Step 1 — figure out if it's the right box
        if ((gameObject.tag == nomBulle[0] && collision.gameObject.tag == nomBoite[0]) ||
            (gameObject.tag == nomBulle[1] && collision.gameObject.tag == nomBoite[1]) ||
            (gameObject.tag == nomBulle[2] && collision.gameObject.tag == nomBoite[2]))
        {
            DeuxiemeBoiteActivee = true;
            BonneBoite = true;
            MauvaiseBoite = false;

        }

        else if ((gameObject.tag == nomBulle[0] && collision.gameObject.tag == nomBoite[3]) ||
            (gameObject.tag == nomBulle[1] && collision.gameObject.tag == nomBoite[4]) ||
            (gameObject.tag == nomBulle[2] && collision.gameObject.tag == nomBoite[5]))
        {
            if (DeuxiemeBoiteActivee == true)
            {
                BonneBoite = true;
                MauvaiseBoite = false;
            }
            else
            {
                BonneBoite = false;
                MauvaiseBoite = true;
            }

        }

        // Step 2 — assign points based on result
        if (MauvaiseBoite == true)
        {
            points -= 1;
            Debug.Log(points);
        }
        else if (BonneBoite == true)
        {
            points += 3;
            Debug.Log(points);
        }
        else
        {
            BonneBoite = false;
            MauvaiseBoite = true;
        }
    }
}
