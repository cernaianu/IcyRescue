using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    public AudioSource backgroundMusic;


    // Start is called before the first frame update
    private void Start()
    {
        Application.targetFrameRate = 75;
    }

    // Update is called once per frame
    private void Update()
    {
        if (playerController.isDead() && playerController.HasBeenHurt)
        {
            playerController.PlayerAnimator.SetBool("dead", true);
            
        }
        backgroundMusic.mute = Settings.isSoundMuted;
    }


}