using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    
    public AudioSource gameOverSFX;
    public AudioSource priestAttackSFX;
    public AudioSource priestWalkSFX;
    public AudioSource necroAttackSFX;
    public AudioSource knightAttackSFX;
    public AudioSource knightWalkSFX;

    public void gameOverSound()
    {
        gameOverSFX.Play();
    }
    public void priestAttackSound()
    {
        priestAttackSFX.Play();
    }
    public void priestWalkSound()
    {
        priestWalkSFX.Play();
    }

    public void necroAttackSound()
    {
        necroAttackSFX.Play();
    }

    public void knightAttackSound()
    {
        knightAttackSFX.Play();
    }

    public void knigtWalkSound()
    {
        knightWalkSFX.Play();
    }
}
