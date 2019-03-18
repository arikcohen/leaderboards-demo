using PlayFab;
using PlayFab.ClientModels;
//using PlayFab.Sockets;
using UnityEngine;

public class AutoLogin : MonoBehaviour
{
    public string TitleIdOverride = "";    

    PlayFabAuthService _service = new PlayFabAuthService();

    public static LoginResult playerLoginResult;
    public static EntityKey playerEntity;
	
	void Start() {
        PlayFabSettings.CompressApiData = false;

        /* PlayFabSocketsAPI.Debugging = true;
        PlayFabSocketsAPI.Initialize(); */
    }
    
    void Awake() {
	    if (!string.IsNullOrEmpty(TitleIdOverride))
	    {
		    PlayFabSettings.TitleId = TitleIdOverride;
	    }
        PlayFabAuthService.OnDisplayAuthentication += OnPlayFabDisplayAuth;
        PlayFabAuthService.OnLoginSuccess += OnPlayFabLoggedIn;
        _service.InfoRequestParams = new GetPlayerCombinedInfoRequestParams()
        {
            GetPlayerProfile = true,            
            GetUserAccountInfo = true,            
            GetTitleData = true
        };
		_service.Authenticate();
	}

    private void OnPlayFabLoggedIn(LoginResult success)
    {        
	    playerLoginResult = success;
        playerEntity = success.EntityToken.Entity;
        
    }

    private void OnPlayFabDisplayAuth()
    {
        _service.Authenticate(Authtypes.Silent);
    }

}
