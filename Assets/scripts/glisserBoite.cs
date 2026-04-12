

using UnityEngine;
using UnityEngine.EventSystems; //!verfier si permission d'utiliser !!!!!!

public class glisserBoite : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    } 

  public void AuDebutGlisser(BaseEventData eventData){
    GetComponent<Collider2D>().enabled = false;
 PointerEventData pointerEventData = eventData as PointerEventData;
    Vector3 NouvellePosition = Camera.main.ScreenToWorldPoint(pointerEventData.position);
    NouvellePosition.z = 0;
 transform.position = NouvellePosition;

 
  }
  public void AuGlisser(BaseEventData eventData){
    PointerEventData pointerEventData = eventData as PointerEventData;
    Vector3 NouvellePosition = Camera.main.ScreenToWorldPoint(pointerEventData.position);
    NouvellePosition.z = 0;
 transform.position = NouvellePosition;
  }
  public void AuFinGlisser(BaseEventData eventData){
 GetComponent<Collider2D>().enabled = true;
  }

  void Update()
{
    float nouvellePositionX = transform.position.x;
    float nouvellePositionY = transform.position.y;
    transform.position = new Vector2(nouvellePositionX, nouvellePositionY);

    if (transform.position.x > 9f)
    {
        transform.position = new Vector2(-8f, 5f);
    }
} }
//liste
/* 1. lorsque la boite arrive à la fin du tapis roulant, elle réapparaît à sa position initiale
 2. on peut cliquer et glisser la boîte
 3. lorsque la carte est cliquée et glissée à la bonne position, elle disparait
 4 les points accumulent correctement
 5. les sprites changent correctement*/

