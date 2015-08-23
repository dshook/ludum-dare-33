using UnityEngine;
using Util;

[RequireComponent(typeof(AudioSource))]
public class MusicLooper : MonoBehaviour
{
    AudioSource source;
    public float introTime = 10f;

    void Start()
    {
        source = GetComponent<AudioSource>();
        source.Play();
    }

    void Update()
    {
        if (FloatUtils.CloseEnough(source.time, source.clip.length)) {
            source.time = introTime;
        }
    }
}
