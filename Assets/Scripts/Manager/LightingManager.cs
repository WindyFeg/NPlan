using System;
using LTK268.Popups;
using UnityEngine;
using Utils;

namespace LTK268.Manager
{
    [ExecuteAlways]
    public class LightingManager : MonoBehaviour
    {
        [SerializeField, Range(0, 10)] private float timeSpeed = 1f;
        [SerializeField] private Light DirectionalLight;
        [SerializeField] private LightingPreset Preset;

        [SerializeField] private int dayTime;
        [SerializeField, Range(0, 24)] private float TimeOfDay;

        private bool _isDayTime;

        private void Start()
        {
            // Set temp dayTime
            dayTime = 0;
        }

        private void Update()
        {
#if UNITY_EDITOR
            // Cheat time
            if (Input.GetKeyDown(KeyCode.C))
            {
                if (TimeOfDay > 6 && TimeOfDay < 18) TimeOfDay = 17.99f;
                else
                {
                    TimeOfDay = 5.99f;
                }
            }
#endif
            if (Preset == null)
                return;

            if (Application.isPlaying)
            {
                //(Replace with a reference to the game time)
                TimeOfDay += Time.deltaTime / 10 * timeSpeed;
                TimeOfDay %= 24; //Modulus to ensure always between 0-24
                
                // Switch to daytime
                if (!_isDayTime && Math.Abs(TimeOfDay - 6) < 0.01f)
                {
                    dayTime += 1;
                    _isDayTime = true; // Prevent multiple call
                    PopupManager.Instance.Show(PopupType.Toast, $"Day {dayTime}");
                }
                // Switch to nighttime
                else if (_isDayTime && Math.Abs(TimeOfDay - 18) < 0.01f)
                {
                    _isDayTime = false; // Prevent multiple call
                    PopupManager.Instance.Show(PopupType.Toast, $"Night {dayTime}");
                    EventManager.Instance.TriggerRandomEvent();
                }

                UpdateLighting(TimeOfDay / 24f);
            }
            else
            {
                UpdateLighting(TimeOfDay / 24f);
            }
        }


        private void UpdateLighting(float timePercent)
        {
            //Set ambient and fog
            RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
            RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);

            //If the directional light is set then rotate and set it's color, I actually rarely use the rotation because it casts tall shadows unless you clamp the value
            if (DirectionalLight != null)
            {
                DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);

                DirectionalLight.transform.localRotation =
                    Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
            }
        }

        //Try to find a directional light to use if we haven't set one
        private void OnValidate()
        {
            if (DirectionalLight != null)
                return;

            //Search for lighting tab sun
            if (RenderSettings.sun != null)
            {
                DirectionalLight = RenderSettings.sun;
            }
            //Search scene for light that fits criteria (directional)
            else
            {
                Light[] lights = GameObject.FindObjectsOfType<Light>();
                foreach (Light light in lights)
                {
                    if (light.type == LightType.Directional)
                    {
                        DirectionalLight = light;
                        return;
                    }
                }
            }
        }
    }
}