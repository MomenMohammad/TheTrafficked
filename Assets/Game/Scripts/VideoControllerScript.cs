using UnityEngine;
using UnityEngine.Video;

public class CharacterVideoAnimator : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public VideoClip[] clips;

    private int currentIndex = -1;
    private bool isLocked = false;

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    public void PlayAnimation(int index, bool lockAnimation = false)
    {
        // If locked, ignore new animations
        if (isLocked) return;

        // Prevent restarting same animation
        if (index == currentIndex) return;

        if (index < 0 || index >= clips.Length)
            return;

        currentIndex = index;

        videoPlayer.Stop();
        videoPlayer.clip = clips[index];
        videoPlayer.Play();

        // Lock if this is an attack (or special animation)
        isLocked = lockAnimation;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        isLocked = false;
    }
}