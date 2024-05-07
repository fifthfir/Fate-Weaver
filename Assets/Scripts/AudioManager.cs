using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

	public AudioSource[] soundEffects;

	public AudioSource bgm, levelEndMusic;

	Subscription<SimpleDivItemSelectionEvent> simple_div_item_selection_event;
	Subscription<DivinationStartsEvent> divination_starts_event_subscription;

	private void Awake()
	{
		instance = this;
	}

	// Start is called before the first frame update
    void Start()
    {
		simple_div_item_selection_event = EventBus.Subscribe<SimpleDivItemSelectionEvent>(PlaySelectionSFX);
		divination_starts_event_subscription = EventBus.Subscribe<DivinationStartsEvent>(PlayDivinationSFX);

    }

    // Update is called once per frame
    void Update()
    {

    }

	public void PlaySFX(int soundToPlay)
	{
		// soundEffects[soundToPlay].Stop();
		soundEffects[soundToPlay].pitch = Random.Range(.9f, 1.1f);
		soundEffects[soundToPlay].Play();
	}

	void PlaySelectionSFX(SimpleDivItemSelectionEvent e)
    {
		PlaySFX(1);
    }

	void PlayDivinationSFX(DivinationStartsEvent e)
    {
		PlaySFX(2);
    }
}
