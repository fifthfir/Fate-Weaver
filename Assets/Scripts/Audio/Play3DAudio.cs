using UnityEngine;
using FMODUnity; // Import FMOD Unity integration namespace
using FMOD.Studio;

public class Play3DAudio : MonoBehaviour
{
    public EventReference fmodEvent; // Replace with your FMOD event path
    private EventInstance eventInstance;
    public bool pauseMusic = false;
    public bool playOnStart = true;

    void Start()
    {
        if (playOnStart)
        {
            eventInstance = RuntimeManager.CreateInstance(fmodEvent);
            RuntimeManager.AttachInstanceToGameObject(eventInstance, transform, GetComponent<Rigidbody>());
            eventInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));

            // Start playing the event
            eventInstance.start();
        }
    }

    void Update()
    {
        // Update the 3D attributes based on the game object's current position
        eventInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));
        if (pauseMusic)
        {
            PauseMusic();
        }
    }

    public void PlayOneShot()
    {
        eventInstance = RuntimeManager.CreateInstance(fmodEvent);
        RuntimeManager.AttachInstanceToGameObject(eventInstance, transform, GetComponent<Rigidbody>());
        eventInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));

        // Start playing the event
        eventInstance.start();
    }

    void OnDestroy()
    {
        // Ensure the event instance is stopped and released when the object is destroyed
        eventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        eventInstance.release();
    }

    void PauseMusic()
    {
        AudioManager.instance.PauseMusic();
    }
}