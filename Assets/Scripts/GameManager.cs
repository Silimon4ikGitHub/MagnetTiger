using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public int CoinsCollected;

    public Action Attrackt;
    public Action Boost;
    public SpeedBoost speedBoost;
    public Player Player;
    public Magnet Magnet;
    public InputManager InputManager;
    public SectorFactory SectorFactory;
    public TextMeshProUGUI ScoreText;

    private void Start()
    {
        SectorFactory.CreateSectors();
        SubscribeAttract();
    }

    private void Update()
    {
        Player.MoveUp();

        Boost?.Invoke();

        if (Input.touchCount > 0)
        {
            Attrackt?.Invoke();
        }

        if (Input.GetMouseButton(0))
        {
            Attrackt?.Invoke();
        }
    }
    
    public void UpdateScore()
    {
        ScoreText.text = CoinsCollected.ToString();
    }

    public void SubscribeAttract()
    {
        
        Attrackt += Magnet.AttractItems;
        
    }
    public void UnSubscribeAttract()
    {
        Attrackt -= Magnet.AttractItems;
    }
}
