using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyPlayerBar : NetworkBehaviour
{

    public RectTransform Location;
    public GameObject HealthPrefab;
    public HealthSystem TargetSystem;

    //public MyFriendBars FriendBars;

    private List<HealthBar> Bars = new List<HealthBar>();
    void Start()
    {
        if(isClient)
        {
            GameObject bar = Instantiate(HealthPrefab);
            RectTransform rect = bar.GetComponent<RectTransform>();
            rect.SetParent(Location);
            rect.position = Vector3.zero;
            rect.localScale = Vector3.one;
            rect.offsetMin = new Vector2(0, 0);
            rect.offsetMax = new Vector2(0, 0);

            HealthBar Bare = bar.GetComponent<HealthBar>();
            Bare.healthSystem = TargetSystem;

            Bars.Add(Bare);

            //foreach (var playerObj in FindObjectsOfType(typeof(GameObject)) as GameObject[]) //Gets client gameObjects
            //{
            //    if (playerObj.CompareTag("Player") && playerObj != gameObject) //Cannot be yourself or objects that isn't the player tag
            //    {
            //        playerObj.GetComponent<MyNetworkPlayer>().SetThisName();
            //        FriendBars.CreateNewBarOfSelf(playerObj.GetComponent<MyNetworkPlayer>().DisplayName); //Gives the FriendBars a copy of the bar
            //    }
            //}
        }
    }

    private void OnDestroy()
    {
        
    }

    public void UpdateHeathBar()
    {
        foreach (HealthBar Babar in Bars)
        {
            Babar.UpdateHealthBar();
        }
    }
}
