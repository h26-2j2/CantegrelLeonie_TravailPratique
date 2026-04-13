using UnityEngine;

public class ActivationEtoile1 : MonoBehaviour
{
    deposerBoite deposerboite;
    public GameObject depose;
    [SerializeField] Sprite[] SpritesEtoiles;
    [SerializeField] Sprite newSprite;
  

    void Start()
    {
        
    }
    void Awake()
    {
        deposerboite = depose.GetComponent<deposerBoite>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (deposerboite.points >=3)
        {
            newSprite = SpritesEtoiles[1];
          
        }
        else if (deposerboite.points < 3)
        {
            newSprite = SpritesEtoiles[0];
        }
       
    
 gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;

} }