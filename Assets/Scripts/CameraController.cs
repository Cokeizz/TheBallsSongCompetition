using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    [System.Serializable]
    public class PlayerAudio
    {
        public Transform player; // The player's transform
        public AudioSource audioSource; // The player's audio source
    }

    // List of players and their associated audio sources
    [SerializeField] private List<PlayerAudio> playerAudios;

    // End Point Y position
    [SerializeField] private float endPointY;

    private string sceneName;
    private AudioSource currentAudioSource;

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

    private void Update()
    {
        if (playerAudios.Count == 0) return; // If no players are assigned, do nothing

        PlayerAudio targetPlayerAudio = null;

        // Find the player with the lowest Y position below the End Point
        foreach (PlayerAudio playerAudio in playerAudios)
        {
            if (playerAudio.player.position.y > endPointY)
            {
                if (targetPlayerAudio == null || playerAudio.player.position.y < targetPlayerAudio.player.position.y)
                {
                    targetPlayerAudio = playerAudio;
                }
            }
        }

        if (targetPlayerAudio != null)
        {
            // If the currentAudioSource is different from the target, pause the current and unpause the target
            if (currentAudioSource != targetPlayerAudio.audioSource)
            {
                if (currentAudioSource != null)
                {
                    currentAudioSource.Pause(); // Pause the previous audio source
                }

                currentAudioSource = targetPlayerAudio.audioSource;
                currentAudioSource.UnPause(); // Unpause the new target player's audio
            }

            // Keep the X position fixed at 0, follow the lower player's Y position, and keep Z position fixed at -3
            Vector3 targetPosition = new Vector3(0f, targetPlayerAudio.player.position.y, -3f); // Fixed X and Z position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, 4 * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }
}
