﻿using LitJson;
using Toast.Gamebase;
using UnityEngine;
using UnityEngine.UI;

namespace GamebaseSample
{
    public class GameInfo : MonoBehaviour
    {
        [SerializeField]
        private Text appVersionText = null;
        [SerializeField]
        private Text sdkVersionText = null;
        [SerializeField]
        private Text userIDText = null;
        [SerializeField]
        private Text accessTokenText = null;
        [SerializeField]
        private Text lastLoggedInProviderText = null;
        [SerializeField]
        private Text languageCodeText = null;
        [SerializeField]
        private Text carrierCodeText = null;
        [SerializeField]
        private Text carrierNameText = null;
        [SerializeField]
        private Text countryCodeText = null;
        [SerializeField]
        private Text countryCodeOfUSIMText = null;
        [SerializeField]
        private Text countryCodeOfDeviceText = null;
        [SerializeField]
        private Text authProviderProfileText = null;

        private void OnEnable()
        {
            LoadData();
        }

        #region UIButton.onClick
        public void ClickCloseButton()
        {
            Destroy(gameObject);
        }
        #endregion

        private void LoadData()
        {
            GetAppVersion();
            GetSDKVersion();
            GetUserID();
            GetAccessToken();
            GetLastLoggedInProvider();
            GetLanguageCode();
            GetCarrierCode();
            GetCarrierName();
            GetCountryCode();
            GetCountryCodeOfUSIM();
            GetCountryCodeOfDevice();
            GetAuthProviderProfile(lastLoggedInProviderText.text);
        }

        private void GetAuthProviderProfile(string providerName)
        {
            GamebaseResponse.Auth.AuthProviderProfile profile = Gamebase.GetAuthProviderProfile(providerName);

            if (profile == null)
            {
                authProviderProfileText.text = string.Empty;
                return;
            }

            authProviderProfileText.text = JsonMapper.ToJson(profile);
        }

        private void GetAppVersion()
        {
            appVersionText.text = SampleVersion.VERSION;
        }

        private void GetSDKVersion()
        {
            sdkVersionText.text = Gamebase.GetSDKVersion();
        }

        private void GetUserID()
        {
            userIDText.text = Gamebase.GetUserID();
        }

        private void GetAccessToken()
        {
            accessTokenText.text = Gamebase.GetAccessToken();
        }

        private void GetLastLoggedInProvider()
        {
            lastLoggedInProviderText.text = Gamebase.GetLastLoggedInProvider();
        }

        private void GetLanguageCode()
        {
            languageCodeText.text = Gamebase.GetDeviceLanguageCode();
        }

        private void GetCarrierCode()
        {
            carrierCodeText.text = Gamebase.GetCarrierCode();
        }

        private void GetCarrierName()
        {
            carrierNameText.text = Gamebase.GetCarrierName();
        }

        private void GetCountryCode()
        {
            countryCodeText.text = Gamebase.GetCountryCode();
        }

        private void GetCountryCodeOfUSIM()
        {
            countryCodeOfUSIMText.text = Gamebase.GetCountryCodeOfUSIM();
        }

        private void GetCountryCodeOfDevice()
        {
            countryCodeOfDeviceText.text = Gamebase.GetCountryCodeOfDevice();
        }
    }
}