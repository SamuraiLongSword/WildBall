using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource GameButtonSound;
    [SerializeField] private AudioSource MenuButtonSound;
    [SerializeField] private AudioSource LvlEndSound;
    [SerializeField] private AudioSource JumpSound;
    [SerializeField] private AudioSource LoseSound;
    [SerializeField] private AudioSource Lvl2_4Sound;
    [SerializeField] private AudioSource Lvl3Sound;
    [SerializeField] private AudioSource VictorySound;
    [SerializeField] private AudioSource ObeliskSound;

    [SerializeField] private PlayerMovement PlayerPrefab;
    [SerializeField] private AnimationOpenDoorScript ButtonPrefab;
    [SerializeField] private LevelReloader ReloadLv;
    [SerializeField] private FinishLevelScript FinishLvPrefab;
    [SerializeField] private ShieldPickUp Shield;
    [SerializeField] private FinishGameScript Finish;

    private BlockActivator[] Blocks;

    private void Awake()
    {
        SliderMethod(PlayerPrefs.GetFloat("volume", 0.5f));

        PlayerPrefab.OnJumpSound += HandlerJumpSound;
        ButtonPrefab.OnButtonSound += HandlerButtonSound;
        ReloadLv.OnDeathSound += HandlerDeathSound;
        FinishLvPrefab.OnFinishLvlSound += HandlerFinishLvlSound;
        Shield.OnShieldSound += HandlerFinishLvlSound;
        Finish.OnFinishGame += HandlerFinishGame;

        Blocks = FindObjectsOfType<BlockActivator>();
        foreach (var e in Blocks)
        {
            e.OnActivated += HandlerBlockkSound;
        }
    }

    private void HandlerFinishGame()
    {
        VictorySound.Play();
    }

    private void HandlerFinishLvlSound()
    {
        LvlEndSound.Play();
    }

    private void HandlerDeathSound()
    {
        LoseSound.Play();
    }

    private void HandlerBlockkSound()
    {
        ObeliskSound.Play();
    }

    private void HandlerButtonSound()
    {
        GameButtonSound.Play();
    }

    public void OnMenuButton()
    {
        MenuButtonSound.Play();
    }

    private void HandlerJumpSound()
    {
        JumpSound.Play();
    }

    public void DeathSound()
    {
        LoseSound.Play();
    }

    public void SliderMethod(float volume)
    {
        GameButtonSound.volume = volume;
        MenuButtonSound.volume = volume;
        LvlEndSound.volume = volume;
        JumpSound.volume = volume;
        LoseSound.volume = volume;
        Lvl2_4Sound.volume = volume;
        Lvl3Sound.volume = volume;
        VictorySound.volume = volume;
        ObeliskSound.volume = volume;
    }
}
