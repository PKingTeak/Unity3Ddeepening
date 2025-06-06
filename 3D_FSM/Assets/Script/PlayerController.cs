using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerInputs playerInputs { get; private set; }

    public PlayerInputs.PlayerActions playerActions { get; private set; }

    private void Awake()
    {

        playerInputs = new PlayerInputs();
        playerActions = playerInputs.Player;

        //OnEnable과 호출 순서에 따라서 오류가 생길수 있기 때문에 
    }
    
    private void OnEnable()
    {
        playerInputs.Enable(); //켜질때 on
    }

    private void OnDisable()
    {
        playerInputs.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
