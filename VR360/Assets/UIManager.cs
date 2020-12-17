using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.Audio;

public class UIManager : MonoBehaviour
{
    [Header("MainMenu/HUD")]
    public GameObject mainMenu;
    public GameObject hud;

    [Header("Panels MainMenu")]
    public GameObject menu;
    public GameObject selection;

    [Header("Hud")]
    public Image pause;
    public Image play;
    public Image sound;
    public Image mute;

    [Header("VideoPlayer")]
    public VideoPlayer player;

    [Header("AudioSource")]
    public AudioSource source;

    public void StartPlayer(VideoClip clip)
    {
        //Assigns the clip && audio
        player.clip = clip;
        player.audioOutputMode = VideoAudioOutputMode.AudioSource;
        player.SetTargetAudioSource(0, source);
        //Turns On the player
        player.gameObject.SetActive(true);
        //Turns On The Hud
        TurnOnHud();
        //Starts The Player
        player.Play();
        
    }

    public void PlayPausePlayer()
    {
        //Checks if the VideoPlayer is playing
        if (player.isPlaying)
        {
            //if so then pause
            player.Pause();
            //Changes icon
            TurnOffIcon(pause.gameObject);
            TurnOnIcon(play.gameObject);
        }
        else
        {
            //if not then unpause
            player.Play();
            //Changes icon
            TurnOffIcon(play.gameObject);
            TurnOnIcon(pause.gameObject);
        }
        
    }

    public void StopPlayer()
    {
        //Stops the clip
        player.Stop();
        //Turns off the player
        player.gameObject.SetActive(false);
        //Turns off the hud
        TurnOffHud();
    }

    private void TurnOffIcon(GameObject icon)
    {
        //Turns on icon
        icon.SetActive(false);
    }

    private void TurnOnIcon(GameObject icon)
    {
        //Turns off icon
        icon.SetActive(true);
    }

    public void MuteUnMutePlayer()
    {
        //Checks if the AudioSource is muted
        if (source.mute)
        {
            //if so then unmute
            source.mute = false;
            //Changes icon
            TurnOffIcon(mute.gameObject);
            TurnOnIcon(sound.gameObject);
        }
        else
        {
            //if not then mute
            source.mute = true;
            //Changes icon
            TurnOffIcon(sound.gameObject);
            TurnOnIcon(mute.gameObject);
        }
    }

    private void TurnOnHud()
    {
        //Turns on the HUD
        hud.SetActive(true);
        //Turns off The selectionmenu
        mainMenu.SetActive(false);
        selection.SetActive(false);
    }

    private void TurnOffHud()
    {
        //Turns off the HUD
        hud.SetActive(false);
        //Turns on the selectionMenu
        mainMenu.SetActive(false);
        selection.SetActive(true);
    }


}
