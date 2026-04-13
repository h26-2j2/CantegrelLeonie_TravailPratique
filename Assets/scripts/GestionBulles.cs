using UnityEngine;

public class GestionBulles : MonoBehaviour
{
     string[] nomBulle = { "bulle_1", "bulle_2", "bulle_3" };
     AudioSource audioSource;
     public AudioClip RondJaune;
     public AudioClip TriangleBleu;
     public AudioClip CarreRouge;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    void OnMouseDown()
    {
        if (gameObject.tag == nomBulle[0])
        {
            audioSource.PlayOneShot(RondJaune);
        }
      
        if (gameObject.tag == nomBulle[1])
        {
            audioSource.PlayOneShot(TriangleBleu);
        }
       
        if (gameObject.tag == nomBulle[2])
        {
            audioSource.PlayOneShot(CarreRouge);
        }
        
    }
    
}
