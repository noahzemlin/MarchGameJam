using UnityEngine;

public class Dragonball : MonoBehaviour
{
    [Range(1,7)]
    public int stars = 1;

    public SpriteRenderer spriteRenderer;
    public bool grabbed = false;
    public Sprite[] sprites;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (grabbed || other.gameObject.layer != LayerMask.NameToLayer("Player"))
            return;
        grabbed = true;
        Debug.Log("Collected " + stars + " star ball!");
        GlobalManager.CollectBall(stars);
        Destroy(this.gameObject);
    }

    private void OnValidate()
    {
        spriteRenderer.sprite = sprites[stars-1];
    }
}
