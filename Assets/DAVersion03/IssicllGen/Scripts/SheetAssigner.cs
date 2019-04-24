using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheetAssigner : MonoBehaviour {
    
    public Texture2D[] StartRooms;
    
	public Texture2D[] BasicRooms;
    
    public Texture2D[] BossRooms;
   
    public Texture2D[] SpecialRooms;

    [SerializeField]
	GameObject RoomObj;
	public Vector2 roomDimensions = new Vector2(16*17,16*9);
	public Vector2 gutterSize = new Vector2(16*9,16*4);
	public void Assign(Room[,] rooms){
		foreach (Room room in rooms){
			//skip point where there is no room
			if (room == null){
				continue;
			}
            //pick a random index for the array
            int index;
			//find position to place room
			Vector3 pos = new Vector3(room.gridPos.x * (roomDimensions.x + gutterSize.x), room.gridPos.y * (roomDimensions.y + gutterSize.y), 0);
			RoomInstance myRoom = Instantiate(RoomObj, pos, Quaternion.identity).GetComponent<RoomInstance>();
            switch (room.type)
            {
                case 0:
                    //Basic Room
                    index = Mathf.RoundToInt(Random.value * (BasicRooms.Length - 1));
                    myRoom.Setup(BasicRooms[index], room.gridPos, room.type, room.doorTop, room.doorBot, room.doorLeft, room.doorRight);
                    break;
                case 1:
                    //Start Room    
                    index = Mathf.RoundToInt(Random.value * (StartRooms.Length - 1));
                    myRoom.Setup(StartRooms[index], room.gridPos, room.type, room.doorTop, room.doorBot, room.doorLeft, room.doorRight);
                    break;
                case 2:
                    //Boss Room
                    index = Mathf.RoundToInt(Random.value * (BossRooms.Length - 1));
                    myRoom.Setup(BossRooms[index], room.gridPos, room.type, room.doorTop, room.doorBot, room.doorLeft, room.doorRight);
                    break;
                case 3:
                    //Special Room
                    index = Mathf.RoundToInt(Random.value * (SpecialRooms.Length - 1));
                    myRoom.Setup(SpecialRooms   [index], room.gridPos, room.type, room.doorTop, room.doorBot, room.doorLeft, room.doorRight);
                    break;

            }
			
		}
	}
}
