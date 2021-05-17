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
    [SerializeField] Spawn []spawnList;
    int i = 0;

    void Start()
    {
        ConnectionTwitch();

        spawnList = objList.GetComponentsInChildren<Spawn>();
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

        commands.Add("!down", new BotCommand((a, b) =>
        {
            var username = b["display-name"].ToLower();
            if (usersGameObject.ContainsKey(username))
            {
                usersGameObject[username].transform.position += Vector3.down;
            }
        }));

        whenNewMessage += (username, message) => Debug.Log($"{username}: {message}");
        whenNewSystemMessage += (message) => {};//Debug.Log($"System: {message}");
        whenDisconnect += () => Debug.Log("Desconexion");
        whenStart += () => Debug.Log("Conexion");

        whenNewChater += (username) => 
		{
            //Debug.Log(spawnList.Length + " Cantidad");
            if (i >= spawnList.Length)
                return;

            //Debug.Log("Pasamos");
            var a = Instantiate(spawnPrefab, spawnList[i].transform);
            i++;
            
            a.name = username;
            usersGameObject.Add(username.ToLower(), a);
		};

        this.StartCoroutineAsync(StartConnection(maxRetry));
    }
}
