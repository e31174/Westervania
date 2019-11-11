using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    // Use this for initialization
    private bool canBeHurt = true;
    public float invinciblityFrames;
    public GameObject musicManager;
    [SerializeField]internal int playerHealth;

    public virtual void TakeDamage(int damage){
        if (canBeHurt == true) {
            playerHealth = playerHealth - damage;
            Camera.main.GetComponent<HUDManager>().SetHealth(playerHealth);

            if (playerHealth <= 0) {
                Die();
            } else {
                CommenceInvincibility();
            }
        }
    }

    void lateUpdate() {

    }

    protected void CommenceInvincibility() {
        canBeHurt = false;
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .5f);
        Invoke("HaltInvincibility", invinciblityFrames);
    }

    protected void HaltInvincibility() {
        GetComponent<SpriteRenderer>().color = Color.white;
        canBeHurt = true;
    }

    protected void Die()
    {
        Destroy(musicManager);
        SceneManager.LoadScene(3);
    }
}
