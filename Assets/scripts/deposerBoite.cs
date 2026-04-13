using UnityEngine;
using UnityEngine.EventSystems; 

public class deposerBoite : MonoBehaviour
{


    string[] nomBulle = { "bulle_1", "bulle_2", "bulle_3" };
    string[] nomBoite = { "boite_1", "boite_2", "boite_3", "boite_4", "boite_5", "boite_6" };
    public int points = 0;
    private bool isBonneBoite = false;
   public AudioClip sonPlacementMauvais;
    public AudioClip sonPlacementBon;

    public AudioClip sonEtoile;



    AudioSource audioSource;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("START - Total points" + this.points);
           audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Debug.Log("UPDATE - Total points" + this.points);
    }

    // Update is called once per frame
    public void AuDeposer(BaseEventData eventData)
    {
        PointerEventData pointerEventData = eventData as PointerEventData;
        GameObject objetDepose = pointerEventData.pointerDrag;
        objetDepose.transform.SetParent(transform);
        objetDepose.transform.localPosition = Vector3.zero;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D - Total points" + this.points);
      
        this.isBonneBoite = false;
  
        if ((gameObject.tag == nomBulle[0] && collision.gameObject.tag == nomBoite[0]) ||
            (gameObject.tag == nomBulle[1] && collision.gameObject.tag == nomBoite[1]) ||
            (gameObject.tag == nomBulle[2] && collision.gameObject.tag == nomBoite[2]))
        {
            
            this.isBonneBoite = true;
        }
       

       
        if (this.isBonneBoite == false)
        {
            this.points--;
            Debug.Log("pointperdu: "+ this.points);
             audioSource.PlayOneShot(sonPlacementMauvais);
        }
        else
        {
            this.points++;
            Debug.Log("pointgagne: "+ this.points);
            collision.gameObject.GetComponent<GestionBoites>().Cacher();
            audioSource.PlayOneShot(sonPlacementBon);
        }

        if (this.points == 1 || this.points == 2 || this.points == 3)
        {
            audioSource.PlayOneShot(sonEtoile);
        
        }
       
    }
}
/*
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
*/


