using UnityEngine;
using System.Collections;

public class ToggleSound : MonoBehaviour
{
	public bool DefaultEnabled;
	public Renderer MuteSign;
	public AudioSource StartSound;

	private GameStorage<bool> soundDisabledStorage = GameStorageKeys.SoundDisabled;

	void Awake ()
	{
		restoreSavedSoundState();
		updateMuteSign();
	}

	void OnMouseDown ()
	{
		bool enableSound = !isSoundActive();
		setSound(enableSound);
		setSavedSoundState(enableSound);
		updateMuteSign();
	}

	private void setSound(bool enable)
	{
		AudioListener.pause = !enable;
		if (enable) {
			startSound();
		}
	}

	private void startSound()
	{
		if (!StartSound.isPlaying) {
			StartSound.Play();
		}
	}

	private bool isSoundActive()
	{
		return !AudioListener.pause;
	}

	private void restoreSavedSoundState()
	{
		bool enableSound = DefaultEnabled;
		if (soundDisabledStorage.Exists()) {
			enableSound = !soundDisabledStorage.Get();
		}
		setSound(enableSound);
	}

	private void setSavedSoundState(bool state)
	{
		soundDisabledStorage.Set(!state);
	}

	private void updateMuteSign()
	{
		if (MuteSign) {
			MuteSign.enabled = !isSoundActive();
		}
	}
}
