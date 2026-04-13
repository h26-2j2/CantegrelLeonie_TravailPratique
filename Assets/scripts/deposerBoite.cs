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

  
   public AudioClip[] SonsVic;
   public AudioClip[] SonsDef;

   private AudioClip SonVicJoue;
   private AudioClip SonDefJoue;



    AudioSource audioSource;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("START - Total points" + points);
           audioSource = GetComponent<AudioSource>();
    
    }

    void Update()
    {
        Debug.Log("UPDATE - Total points" + points);
        
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
        Debug.Log("OnTriggerEnter2D - Total points" + points);
      
        isBonneBoite = false;
  
        if ((gameObject.tag == nomBulle[0] && collision.gameObject.tag == nomBoite[0]) ||
            (gameObject.tag == nomBulle[1] && collision.gameObject.tag == nomBoite[1]) ||
            (gameObject.tag == nomBulle[2] && collision.gameObject.tag == nomBoite[2]))
        {
             

            isBonneBoite = true;
        }
       

       
        if (isBonneBoite == false)
        {
            points-=1;
            Debug.Log("pointperdu: "+ points);
             audioSource.PlayOneShot(sonPlacementMauvais);
              SonDefJoue = SonsDef[Random.Range(0, SonsDef.Length)];
            audioSource.PlayOneShot(SonDefJoue);
        }
        else
        {
            points+=3;
            Debug.Log("pointgagne: "+ points);
            collision.gameObject.GetComponent<GestionBoites>().Cacher();
            audioSource.PlayOneShot(sonPlacementBon);
             SonVicJoue = SonsVic[Random.Range(0, SonsVic.Length)];
            audioSource.PlayOneShot(SonVicJoue);
        }

        if (points == 1 || points == 2 || points == 3)
        {
            audioSource.PlayOneShot(sonEtoile);
        
        }
       
    }
}
