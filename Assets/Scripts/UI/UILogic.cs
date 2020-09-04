using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UILogic : MonoBehaviour
{
    [SerializeField] RectTransform main, world_T, world_1, world_2;
    [SerializeField] float time, delay;
    public void MoveWorld_T(int world)
    {
        if(world == 0)
        {
            MoveUI(main, new Vector2(0, -1080), time, delay, Ease.InBounce);
            MoveUI(world_T, new Vector2(0, 0), time, delay, Ease.InBounce);
        }
        if(world == 1)
        {
            MoveUI(main, new Vector2(0, 0), time, delay, Ease.InBounce);
            MoveUI(world_T, new Vector2(0, 1080), time, delay, Ease.InBounce);
        }
    }
    public void MoveWorld_1(int world)
    {
        if (world == 0)
        {
            MoveUI(main, new Vector2(0, -1080), time, delay, Ease.InBounce);
            MoveUI(world_1, new Vector2(0, 0), time, delay, Ease.InBounce);
        }
        if (world == 1)
        {
            MoveUI(main, new Vector2(0, 0), time, delay, Ease.InBounce);
            MoveUI(world_1, new Vector2(-1920, 0), time, delay, Ease.InBounce);
        }
    }
    public void MoveWorld_2(int world)
    {
        if (world == 0)
        {
            MoveUI(main, new Vector2(0, -1080), time, delay, Ease.InBounce);
            MoveUI(world_2, new Vector2(0, 0), time, delay, Ease.InBounce);
        }
        if (world == 1)
        {
            MoveUI(main, new Vector2(0, 0), time, delay, Ease.InBounce);
            MoveUI(world_2, new Vector2(1920, 0), time, delay, Ease.InBounce);
        }
    }
    void MoveUI(RectTransform rectTransform,Vector2 position,float moveTime,float delay,Ease ease)
    {
        rectTransform.DOAnchorPos(position, moveTime).SetDelay(delay).SetEase(ease);  
    }

}
