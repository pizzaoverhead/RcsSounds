using System;
using System.Collections.Generic;
using UnityEngine;

class RcsSounds : ModuleRCS
{
    [KSPField]
    public string rcsSoundFile = "RcsSounds/Sounds/RCSnoise";
    [KSPField]
    public float rcsVolume = 0.5f;
    [KSPField]
    public bool internalRcsSoundOnly = false;
    [KSPField]
    public float rcsSoundFade = 1;

    public FXGroup RcsSound = null;

    public override void OnStart(PartModule.StartState state)
    {
        base.OnStart(state);

        try
        {
            if (state == StartState.Editor || state == StartState.None) return;

            if (!GameDatabase.Instance.ExistsAudioClip(rcsSoundFile))
                Debug.LogError("RcsSounds: Audio file not found: \"" + rcsSoundFile + "\"");

            if (RcsSound != null)
            {
                RcsSound.audio = gameObject.AddComponent<AudioSource>();
                //RcsSound.audio.rolloffMode = AudioRolloffMode.Logarithmic;
                RcsSound.audio.dopplerLevel = 0f;
                RcsSound.audio.Stop();
                RcsSound.audio.clip = GameDatabase.Instance.GetAudioClip(rcsSoundFile);
                RcsSound.audio.loop = true;
            }
            else
                Debug.LogError("RcsSounds: FXGroup not found.");
        }
        catch (Exception ex)
        {
            Debug.LogError("RcsSounds OnStart: " + ex.Message + " " + ex.Message);
        }
    }

    public override void OnUpdate()
    {
        try
        {
            if (RcsSound != null)
            {
                if (!internalRcsSoundOnly || CameraManager.Instance.currentCameraMode == CameraManager.CameraMode.IVA ||
                    CameraManager.Instance.currentCameraMode == CameraManager.CameraMode.Map)
                {
                    bool rcsActive = false;
                    float rcsHighestPower = 0f;

                    // Check for the resource as the effects still fire slightly without fuel.
                    var resourceList = new List<PartResource>();
                    part.GetConnectedResources(PartResourceLibrary.Instance.GetDefinition("MonoPropellant").id, resourceList);
                    double totalAmount = 0;
                    foreach (PartResource r in resourceList)
                        totalAmount += r.amount;

                    if (totalAmount >= 0.01) // 0.01 is the smallest amount shown in the resource menu.
                    {
                        foreach (FXGroup f in thrusterFX)
                        {
                            rcsActive = rcsActive | f.Active;
                            rcsHighestPower = Mathf.Max(rcsHighestPower, f.Power);
                        }
                    }

                    if (rcsActive)
                    {
                        RcsSound.audio.pitch = Mathf.Lerp(0.5f, 1f, rcsHighestPower);
                        RcsSound.audio.volume = GameSettings.SHIP_VOLUME * rcsVolume * (float)Math.Pow(rcsHighestPower, rcsSoundFade);
                        if (!RcsSound.audio.isPlaying)
                            RcsSound.audio.Play();
                    }
                    else
                        RcsSound.audio.Stop();
                }
                else
                    RcsSound.audio.Stop();
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("RcsSounds OnUpdate: " + ex.Message + " " + ex.Message);
        }

        base.OnUpdate();
    }
}