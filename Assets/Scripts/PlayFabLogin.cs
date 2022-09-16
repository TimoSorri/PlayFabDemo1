using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class PlayFabLogin : MonoBehaviour
{
    [Header("LOGIN")]
    private string UserEmailLogin;
    private string UserPasswordLogin;

    public void Start()
    {
        // Tarkistetaan ettei TitleID ole tyhjä eli null
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            // Lisää oma TitleID, jonka löydät PlayFab pilven Game managerista
            PlayFabSettings.TitleId = "404D1";
        }
        var request = new LoginWithEmailAddressRequest { Email = UserEmailLogin, Password = UserPasswordLogin };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
    }
    // Tämä metodi suoritetaan jos loggaus onnistuu
    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call");
    }

    // Tämä metodi suroitetaan jos loggaus epäonnistuu
    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your first API call. :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }

    // Tallentaa Login-lomakkeelta tulleen salasanan
    public void  GetUserPasswordLogin(string passwordIn)
    {
        UserPasswordLogin = passwordIn;
    }

    // Tallentaa Login-lomakkeelta tulleen  sähköpostiosoitteen

    public void GetUserEmailLogin(string emailIn)
    {
        UserEmailLogin = emailIn;
    }

    // Login -painikkeen koodi eli tässä tehdään API-kuts Playfab pilveen ja selvitetään onko käyttäjä olemassa
    public void Login()
    {
        var request = new LoginWithEmailAddressRequest { Email = UserEmailLogin, Password = UserPasswordLogin };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);

    }
}
