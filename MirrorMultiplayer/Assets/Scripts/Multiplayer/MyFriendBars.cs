using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyFriendBars : NetworkBehaviour
{
    public GameObject FriendBar;
    public RectTransform Location;

    public void CreateNewBarOfSelf(string Name)
    {
        GameObject bar = Instantiate(FriendBar);
        RectTransform rect = bar.GetComponent<RectTransform>();
        bar.GetComponent<MultiplayerHealthBarRef>();
        rect.SetParent(Location);
        rect.localScale = Vector3.one;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
