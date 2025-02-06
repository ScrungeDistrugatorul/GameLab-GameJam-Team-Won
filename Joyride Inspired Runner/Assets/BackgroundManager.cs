using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public GameObject[] backgrounds;
    public GameObject player;
    
    // Update is called once per frame
    void Update()
    {
        foreach (GameObject background in backgrounds)
        {
            if ((background.transform.localPosition.x + background.GetComponent<SpriteRenderer>().bounds.size.x) -
                player.transform.localPosition.x < 0)
            {
                background.transform.position += new Vector3((background.GetComponent<SpriteRenderer>().bounds.size.x * 3), 
                    0,0);
                // Debug.Log(background.transform.position);
            }
        }        
    }
}
