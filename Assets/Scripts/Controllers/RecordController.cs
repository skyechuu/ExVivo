using UnityEngine;

public class RecordController : MonoBehaviour {

    private AudioSource source;
    private AudioClip playingRecording;
    private InventoryItemView itemView;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (source.isPlaying && itemView != null)
        {
            itemView.SetForegroundFillAmount(source.time/playingRecording.length);
        }
    }

    public void PlayRecording(AudioClip recording)
    {
        source.Stop();
        source.PlayOneShot(recording);
    }

    public void PlayRecording(AudioClip recording, InventoryItemView item)
    {
        source.Stop();
        playingRecording = recording;
        if (itemView != null)
            itemView.SetForegroundFillAmount(1);
        itemView = item;

        source.clip = recording;
        source.Play();
    }

    public void StopPlaying()
    {
        source.Stop();
        if(itemView != null)
        {
            itemView.SetForegroundFillAmount(1);
            itemView = null;
        }
    }


}
