using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenController : MonoBehaviour
{
    public GameObject Login;
    public GameObject UserPofile;
    public GameObject MyJoinEvent;
    public GameObject MyHostedEvent;
    public GameObject EventSearchResult;
    public GameObject CreateEvent;
    public GameObject Main;
    public GameObject Settings;
    // This method can be called when the button is clicked
    public void LoadSceneByName(string sceneName)
    {
        if (sceneName == "Login")
        {
            switchScenes(true,false,false,false,false,false,false,false);
        }
        if (sceneName == "UserProfile")
        {
            switchScenes(false,true,false,false,false,false,false,false);
        }
        if (sceneName == "My Joined Events")
        {
            switchScenes(false,false,true,false,false,false,false,false);
        }
        if (sceneName == "My Hosted Events")
        {
            switchScenes(false,false,false,true,false,false,false,false);
        }
        if (sceneName == "Event Search Result")
        {
            switchScenes(false,false,false,false,true,false,false,false);
        }
        if (sceneName == "CreateEvent")
        {
            switchScenes(false,false,false,false,false,true,false,false);
        }
        if (sceneName == "Main")
        {
            switchScenes(false,false,false,false,false,false,true,false);
        }
        if (sceneName == "Setting")
        {
            switchScenes(false,false,false,false,false,false,false,true);
        }
    }

    private void switchScenes(bool login, bool userPofile, bool myJoinEvent, 
        bool myHostedEvent, bool eventSearchResult, bool createEvent, bool main, bool settings)
    {
        Login.SetActive(login);
        UserPofile.SetActive(userPofile);
        MyJoinEvent.SetActive(myJoinEvent);
        MyHostedEvent.SetActive(myHostedEvent);
        EventSearchResult.SetActive(eventSearchResult);
        CreateEvent.SetActive(createEvent);
        Main.SetActive(main);
        Settings.SetActive(settings);
    }
}