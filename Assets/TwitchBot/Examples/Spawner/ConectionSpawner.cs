using CielaSpike;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TwitchBot;
using System.Threading;

public class ConectionSpawner : UnityBot 
{
    public GameObject spawnPrefab;
    public int maxRetry;

    Dictionary<string, GameObject> usersGameObject = new Dictionary<string, GameObject>(); 

    // List spawns
    [SerializeField] Transform objList;
    [SerializeField] Transform []spawnList;
    int i = 1;

    void Start()
    {
        ConnectionTwitch();

        spawnList = objList.GetComponentsInChildren<Transform>();
    }

    void ConnectionTwitch()
    {
        commands = new Dictionary<string, BotCommand>();
        commands.Add("!up", new BotCommand((a,b) => 
        {
            var username = b["display-name"].ToLower();
            if(usersGameObject.ContainsKey(username))
            {
                usersGameObject[username].transform.position += Vector3.up;
            }
        }));

        whenNewMessage += (username, message) => Debug.Log($"{username}: {message}");
        whenNewSystemMessage += (message) => {};//Debug.Log($"System: {message}");
        whenDisconnect += () => Debug.Log("Desconexion");
        whenStart += () => Debug.Log("Conexion");

        whenNewChater += (username) => 
		{	           	
            var a = Instantiate(spawnPrefab, spawnList[i]);
            i++;
            
            a.name = username;
            usersGameObject.Add(username.ToLower(), a);
		};

        this.StartCoroutineAsync(StartConnection(maxRetry));
    }
}
