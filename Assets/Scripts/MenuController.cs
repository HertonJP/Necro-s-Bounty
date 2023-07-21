using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    public string sceneName;
    [SerializeField] private TMP_Text volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private GameObject confirmationPrompt = null;
    [SerializeField] private float defaultVolume = 1.0f;

    [SerializeField] private TMP_Text senTextValue = null;
    [SerializeField] private Slider senSlider = null;
    [SerializeField] private int defaultSen = 4;
    public int mainSen = 4;
    public void PlayButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ExitButton()
    {
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0.0");
    }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        StartCoroutine(ComfirmationBox());
    }

    public void SetSens(float sensitivity)
    {
        mainSen = Mathf.RoundToInt(sensitivity);
        senTextValue.text = sensitivity.ToString("0");
    }
    public void GameplayApply()
    {
        PlayerPrefs.SetFloat("masterSen", mainSen);
        StartCoroutine(ComfirmationBox());
    }
    public void ResetButton()
    {
            AudioListener.volume = defaultVolume;
            volumeSlider.value = defaultVolume;
            volumeTextValue.text = defaultVolume.ToString("0.0");
            VolumeApply();
            senTextValue.text = defaultSen.ToString("0");
            senSlider.value = defaultSen;
            mainSen = defaultSen;
            GameplayApply();
    }

    public IEnumerator ComfirmationBox()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPrompt.SetActive(false);
    }
}
