using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;
public class SettingsMenu : MonoBehaviour
{
 public AudioMixer audioMixer;
 public Resolution[] resolutions;
 public Dropdown resolutionDropdown;
 public Slider volumeMusiqueSlider;
 public Slider volumeSoundSlider;
 private void Start()
 {
  audioMixer.GetFloat("VolumeMusic", out float musicValueForSlider);
  volumeMusiqueSlider.value = musicValueForSlider;
  audioMixer.GetFloat("VolumeSound", out float soundValueForSlider);
  volumeSoundSlider.value = soundValueForSlider;
  
  resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
  resolutionDropdown.ClearOptions();
  List<String> options = new List<string>();
  int currentResolutionIndex = 0;
  for (int i = 0; i < resolutions.Length; i++)
  {
   string option = resolutions[i].width + "x" + resolutions[i].height;
   options.Add(option);
   if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
   {
    currentResolutionIndex = i;
   }
  }
  resolutionDropdown.AddOptions(options);
  resolutionDropdown.value = currentResolutionIndex;
  resolutionDropdown.RefreshShownValue();
  
 }

 public void SetVolumeMusic(float volume)
 {
  audioMixer.SetFloat("VolumeMusic", volume);
 }
 public void SetVolumeSound(float volume)
 {
  audioMixer.SetFloat("VolumeSound", volume);
 }
 public void setFullScreen(bool isFullScreen)
 {
  Screen.fullScreen = isFullScreen;
 }

 public void setResolution(int resolutionIndex)
 {
  Resolution resolution = resolutions[resolutionIndex];
  Screen.SetResolution(resolution.width,resolution.height,Screen.fullScreen);
 }
}
