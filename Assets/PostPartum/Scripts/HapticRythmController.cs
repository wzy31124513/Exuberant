using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticRythmController : MonoBehaviour
{
    public enum HapticState
    {
        Idle,
        Right,
        Left,
        Both
    }

    public HapticState PreviousHapticState = HapticState.Idle;
    public HapticState CurrentHapticState = HapticState.Idle;
    public int TotalHapticStateCount = 4;

    private bool ShouldProcessHaptic = false;
    
    private float ControllerTimeElapsed;
    private float TotalPlayTimeElapsed;

    private int HapticStateCount = 0;
    
    private float ControllerTimeDelay = 0.25f;//0.1f
    private float DualControllerTime = 0.25f;//0.25f
    private float SingleControllerTime = 0.1f;//0.1f

    private float ControllerFrequency = 1.0f;
    private float SingleControllerAmplitude = 0.25f;//0.1f;
    private float DualControllerAmplitude = 0.1f;//0.2f;
    
    public void PlayRythm()
    {
        ShouldProcessHaptic = true;
        HapticStateCount = 0;
        ControllerTimeElapsed = 0;
        Vibrate(ControllerFrequency, DualControllerAmplitude);
        PreviousHapticState = HapticState.Idle;
        CurrentHapticState = HapticState.Both;
        Debug.Log("Idle to Both");
    }
    
    public void Vibrate(float frequency = 1.0f, float amplitude = 1.0f)
    {
        OVRInput.SetControllerVibration(frequency, amplitude, OVRInput.Controller.RTouch);
        OVRInput.SetControllerVibration(frequency, amplitude, OVRInput.Controller.LTouch);
    }
    
    public void VibrateRight(float frequency = 1.0f, float amplitude = 1.0f)
    {
        OVRInput.SetControllerVibration(frequency, amplitude, OVRInput.Controller.RTouch);
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
    }

    public void VibrateLeft(float frequency = 1.0f, float amplitude = 1.0f)
    {
        OVRInput.SetControllerVibration(frequency, amplitude, OVRInput.Controller.LTouch);
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
    }

    public void VibrateStop()
    {
        OVRInput.SetControllerVibration(0.0f, 0.0f, OVRInput.Controller.RTouch);
        OVRInput.SetControllerVibration(0.0f, 0.0f, OVRInput.Controller.LTouch);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!ShouldProcessHaptic)
        {
            return;
        }

        switch (PreviousHapticState)
        {
            case HapticState.Idle:
            {
                switch (CurrentHapticState)
                {
                    case HapticState.Idle:
                    {
                        VibrateStop();
                        ShouldProcessHaptic = false;
                    }
                        break;
                    case HapticState.Right:
                        break;
                    case HapticState.Left:
                    {
                        ControllerTimeElapsed += Time.deltaTime;
                        if (ControllerTimeElapsed >= ControllerTimeDelay)
                        {
                            ControllerTimeElapsed = 0;
                            VibrateRight(ControllerFrequency, SingleControllerAmplitude);
                            HapticStateCount++;
                            PreviousHapticState = CurrentHapticState;
                            CurrentHapticState = HapticState.Right;
                            Debug.Log("Left to Right: HapticStateCount: " + HapticStateCount);
                        }
                    }
                        break;
                    case HapticState.Both:
                    {
                        ControllerTimeElapsed += Time.deltaTime;
                        if (ControllerTimeElapsed >= DualControllerTime)
                        {
                            ControllerTimeElapsed = 0.0f;
                            VibrateStop();
                            PreviousHapticState = CurrentHapticState;
                            CurrentHapticState = HapticState.Idle;
                            Debug.Log("Both to Idle");
                        }
                    }
                        break;
                    default:
                        VibrateStop();
                        break;
                }
            }
                break;
            case HapticState.Right:
            {
                switch (CurrentHapticState)
                {
                    case HapticState.Idle:
                    {
                        ControllerTimeElapsed += Time.deltaTime;
                        if (ControllerTimeElapsed >= ControllerTimeDelay)
                        {
                            ControllerTimeElapsed = 0;
                            VibrateStop();
                            PreviousHapticState = CurrentHapticState;
                            CurrentHapticState = HapticState.Idle;
                            Debug.Log("Idle to Idle: HapticStateCount: " + HapticStateCount);
                        }
                    }
                        break;
                    case HapticState.Right:
                        break;
                    case HapticState.Left:
                    {
                        ControllerTimeElapsed += Time.deltaTime;
                        if (ControllerTimeElapsed >= SingleControllerTime)
                        {
                            ControllerTimeElapsed = 0;
                            VibrateRight(ControllerFrequency, SingleControllerAmplitude);
                            HapticStateCount++;
                            PreviousHapticState = CurrentHapticState;
                            CurrentHapticState = HapticState.Right;
                            if (HapticStateCount > TotalHapticStateCount)
                            {
                                ControllerTimeElapsed = 0;
                                Vibrate(ControllerFrequency, DualControllerAmplitude);
                                PreviousHapticState = CurrentHapticState;
                                CurrentHapticState = HapticState.Both;
                                Debug.Log("Left to Both: HapticStateCount: " + HapticStateCount);
                            }
                            else
                            {
                                Debug.Log("Left to Right: HapticStateCount: " + HapticStateCount);
                            }
                        }
                    }
                        break;
                    case HapticState.Both:
                    {
                        ControllerTimeElapsed += Time.deltaTime;
                        if (ControllerTimeElapsed >= DualControllerTime)
                        {
                            ControllerTimeElapsed = 0.0f;
                            VibrateStop();
                            PreviousHapticState = HapticState.Idle;
                            CurrentHapticState = HapticState.Idle;
                            Debug.Log("Right to Both to Idle");
                        }
                    }
                        break;
                    default:
                        VibrateStop();
                        break;
                }
            }
                break;
            case HapticState.Left:
            {
                switch (CurrentHapticState)
                {
                    case HapticState.Idle:
                    {
                        ControllerTimeElapsed += Time.deltaTime;
                        if (ControllerTimeElapsed >= ControllerTimeDelay)
                        {
                            ControllerTimeElapsed = 0;
                            VibrateStop();
                            PreviousHapticState = CurrentHapticState;
                            CurrentHapticState = HapticState.Idle;
                            Debug.Log("Idle to Idle: HapticStateCount: " + HapticStateCount);
                        }
                    }
                        break;
                    case HapticState.Right:
                    {
                        ControllerTimeElapsed += Time.deltaTime;
                        if (ControllerTimeElapsed >= SingleControllerTime)
                        {
                            ControllerTimeElapsed = 0;
                            VibrateLeft(ControllerFrequency, SingleControllerAmplitude);
                            HapticStateCount++;
                            PreviousHapticState = CurrentHapticState;
                            CurrentHapticState = HapticState.Left;
                            if (HapticStateCount > TotalHapticStateCount)
                            {
                                ControllerTimeElapsed = 0;
                                Vibrate(ControllerFrequency, DualControllerAmplitude);
                                PreviousHapticState = CurrentHapticState;
                                CurrentHapticState = HapticState.Both;
                                Debug.Log("Right to Both: HapticStateCount: " + HapticStateCount);
                            }
                            else
                            {
                                Debug.Log("Right to Left: HapticStateCount: " + HapticStateCount);
                            }
                        }
                    }
                        break;
                    case HapticState.Left:
                        break;
                    case HapticState.Both:
                    {
                        ControllerTimeElapsed += Time.deltaTime;
                        if (ControllerTimeElapsed >= DualControllerTime)
                        {
                            ControllerTimeElapsed = 0.0f;
                            VibrateStop();
                            PreviousHapticState = HapticState.Idle;
                            CurrentHapticState = HapticState.Idle;
                            Debug.Log("Left to Both to Idle");
                        }
                    }
                        break;
                    default:
                        VibrateStop();
                        break;
                }
            }
                break;
            case HapticState.Both:
            {
                switch (CurrentHapticState)
                {
                    case HapticState.Idle:
                    {
                        ControllerTimeElapsed += Time.deltaTime;
                        if (ControllerTimeElapsed >= ControllerTimeDelay)
                        {
                            ControllerTimeElapsed = 0;
                            VibrateLeft(ControllerFrequency, SingleControllerAmplitude);
                            HapticStateCount++;
                            PreviousHapticState = CurrentHapticState;
                            CurrentHapticState = HapticState.Left;
                            Debug.Log("Idle to Left: HapticStateCount: " + HapticStateCount);
                        }
                    }
                        break;
                    case HapticState.Right:
                        break;
                    case HapticState.Left:
                        break;
                    case HapticState.Both:
                        break;
                    default:
                        VibrateStop();
                        break;
                }
            }
                break;
            default:
            {
                VibrateStop();
            }
                break;
        }
    }
}
