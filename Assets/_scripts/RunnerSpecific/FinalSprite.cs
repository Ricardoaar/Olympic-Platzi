using UnityEngine;
using UnityEngine.Playables;

public class FinalSprite : MonoBehaviour
{
    [SerializeField] private PlayableDirector endTimeLine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            endTimeLine.Play();
        }
    }

    
}
