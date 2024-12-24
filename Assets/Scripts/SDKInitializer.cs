using System;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;

namespace GodsExperiment
{
    public class SDKInitializer : MonoBehaviour
    {
        private async void Awake()
        {
            try
            {
                await UnityServices.InitializeAsync();
                await AuthenticationService.Instance.SignInAnonymouslyAsync();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}
