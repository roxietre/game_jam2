using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    private AudioClip hitSound;
    static AudioSource audioHit;
    private AudioClip laserSound;
    static AudioSource audioLaser;
    private AudioClip powerup;
    static AudioSource audioPower;

    // Start is called before the first frame update
    void Start()
    {
        hitSound = AudioClip.Create("Hit_Hurt", 44100 * 2, 1, 44100, false);
        audioHit = GetComponent<AudioSource>();
        audioHit.clip = hitSound;
        laserSound = AudioClip.Create("Laser_Shoot", 44100 * 2, 1, 44100, false);
        audioLaser = GetComponent<AudioSource>();
        audioLaser.clip = laserSound;
        powerup =   AudioClip.Create("Powerup", 44100 * 2, 1, 44100, false);
        audioPower = GetComponent<AudioSource>();
        audioPower.clip = powerup;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Hit_Hurt":
                audioHit.Play();
                break;
            case "Powerup":
                audioPower.Play();
                break;
            case "Laser_Shoot":
                audioLaser.Play();
                break;
        }
    }
}
