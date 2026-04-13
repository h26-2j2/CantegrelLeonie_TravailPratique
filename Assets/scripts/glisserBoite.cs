

using UnityEngine;
using UnityEngine.EventSystems; 

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
