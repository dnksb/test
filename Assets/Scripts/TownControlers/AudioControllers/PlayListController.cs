using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayListController : MonoBehaviour
{

    [SerializeField] List<AudioClip> contact;
    [SerializeField] List<AudioClip> gachi;
    [SerializeField] List<AudioClip> phonk;
    [SerializeField] List<AudioClip> Wladiwastock;
    [SerializeField] List<AudioClip> rock;
    [SerializeField] List<AudioClip> xtc;
    private List<List<AudioClip>> clips;
    public AudioSource audioSource;

    public int nowFM = 0;

    [SerializeField] KeyCode SetCameraKey;
    [SerializeField] GameObject musicName;

    // Start is called before the first frame update
    void Start()
    {
    clips = new List<List<AudioClip>>(){};
    	clips.Add(contact);
        clips.Add(gachi);
        clips.Add(phonk);
        clips.Add(Wladiwastock);
        clips.Add(rock);
        clips.Add(xtc);

        audioSource.loop = false;
    }

    private AudioClip GetRandomClip()
    {
        return clips[nowFM][Random.Range(0, clips[nowFM].Count)];
    }

    void Update()
    {
        if(!audioSource.isPlaying)
        {
            audioSource.clip = GetRandomClip();
            audioSource.Play();
            musicName.transform.GetComponent<Text>().text = audioSource.clip.name;
        }
        if (Input.GetKeyDown (SetCameraKey))
        {
            if(nowFM >= clips.Count - 1)
                nowFM = 0;
            else
                nowFM++;

                    Debug.Log(nowFM);
            audioSource.clip = GetRandomClip();
                audioSource.Play();
                musicName.transform.GetComponent<Text>().text = audioSource.clip.name;
        }
    }

    public void ChangeMusic()
    {
        if(nowFM >= clips.Count - 1)
                nowFM = 0;
            else
                nowFM++;

                    Debug.Log(nowFM);
            audioSource.clip = GetRandomClip();
                audioSource.Play();
                musicName.transform.GetComponent<Text>().text = audioSource.clip.name;
    }
}
