using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ActionType
{
    Left,
    Right,
    Jump 
     
}
public abstract class CharactorBase : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float Jump;
    public float Speed;
    public Rigidbody2D mybody;
    public void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
    }

    public abstract void Init();
    public abstract void Hit();
    public virtual void Move(ActionType actionTypeParam)
    {
        switch (actionTypeParam)
        {
            case ActionType.Left:
                mybody.velocity += new Vector2(Speed, 0);
                mybody.transform.localScale = new Vector3(-1, 1, 1);
                break;
                case ActionType.Right:
                mybody.velocity += new Vector2(-Speed, 0);
                mybody.transform.localScale = new Vector3(1, 1, 1);
                break;
                case ActionType.Jump:
                mybody.velocity += new Vector2(0, Jump);
                break;
        }

    }
    public virtual void Die()
    {

    }
   


    public virtual void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Move(ActionType.Right);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Move(ActionType.Left);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Move(ActionType.Jump);
        }
    }


}
