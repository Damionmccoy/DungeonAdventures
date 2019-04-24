using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoomSystem : MonoBehaviour {
	Vector3 moveJump = Vector2.zero;
	float horMove, vertMove;

    public float PlayerMoveX = 223.5f; 
    public float PlayerMoveY = 95f;
	void Start(){
		SheetAssigner SA = FindObjectOfType<SheetAssigner>();
		Vector2 tempJump = SA.roomDimensions + SA.gutterSize;
		moveJump = new Vector3(tempJump.x, tempJump.y, 0); //distance b/w rooms: to be used for movement
	}

    /// <summary>
    /// This will change the room based on the direction in the parameters
    /// </summary>
    /// <param name="vert">vertical movement  1--> up, 0 --> no movement, -1 --> down</param>
    /// <param name="horz">vertical movement  -1--> left, 0 --> no movement, 1 --> right</param>
	public void ChangeRoom(float vert, float horz,Transform player)
	{
		
		horMove = System.Math.Sign(horz);//capture input
		vertMove = System.Math.Sign(vert);
		Vector3 tempPos = transform.position;
        Vector3 tempPos2 = player.position;
		tempPos += Vector3.right * horMove * moveJump.x; //jump bnetween rooms based opn input
		tempPos += Vector3.up * vertMove * moveJump.y;
        tempPos2 += Vector3.right * horMove * moveJump.x; //jump bnetween rooms based opn input
        tempPos2 += Vector3.up * vertMove * moveJump.y;
        transform.position = tempPos;

        if(horz == -1)
        {
            tempPos2.x += PlayerMoveX;
        }
        else if(horz == 1)
        {
            tempPos2.x -= PlayerMoveX;
        }

        if(vert == 1)
        {
            tempPos2.y -= PlayerMoveY;
        }
        else if(vert == -1)
        {
            tempPos2.y += PlayerMoveY;
        }

        player.position = tempPos2;
		
	}
}
