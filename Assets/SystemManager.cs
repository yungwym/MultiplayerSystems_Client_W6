using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemManager : MonoBehaviour
{
    // UI Variables 
    GameObject submitButton;
    GameObject usernameInput;
    GameObject passwordInput;
    GameObject loginToggle;
    GameObject createToggle;

    //Member Variables 
    GameObject networkedClient;



    // Start is called before the first frame update
    void Start()
    {
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();

        foreach (GameObject go in allObjects)
        {
            if (go.name == "UserField")
                usernameInput = go;
            else if (go.name == "PassField")
                passwordInput = go;
            else if (go.name == "SubmitButton")
                submitButton = go;
            else if (go.name == "LoginToggle")
                loginToggle = go;
            else if (go.name == "CreateToggle")
                createToggle = go;
            else if (go.name == "NetworkedClient")
                networkedClient = go;
        }

        submitButton.GetComponent<Button>().onClick.AddListener(SubmitButtonPressed);

        loginToggle.GetComponent<Toggle>().onValueChanged.AddListener(LoginTogglePressed);
        createToggle.GetComponent<Toggle>().onValueChanged.AddListener(CreateTogglePressed);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SubmitButtonPressed()
    {
        //Send Login Info to Server
        Debug.Log("Submit Clicked");

        string user = usernameInput.GetComponent<InputField>().text;
        string pass = passwordInput.GetComponent<InputField>().text;

        string msg;

        if (createToggle.GetComponent<Toggle>().isOn)

            msg = ClientToServerSignifiers.CreateAccount + "," + user + "," + pass;
        else
            msg = ClientToServerSignifiers.Login + "," + user + "," + pass;


        networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(msg);

        Debug.Log(msg);
    }

    public void LoginTogglePressed(bool newValue)
    {


        createToggle.GetComponent<Toggle>().SetIsOnWithoutNotify(!newValue);
    }

    public void CreateTogglePressed(bool newValue)
    {


        loginToggle.GetComponent<Toggle>().SetIsOnWithoutNotify(!newValue);
    }

}
