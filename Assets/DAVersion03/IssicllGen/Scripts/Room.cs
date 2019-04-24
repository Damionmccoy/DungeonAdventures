using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room {
	public Vector2 gridPos;
	public int type; // 0--> Basic Room; 1--> Start Room; 3--> Boss Room; 4--> Special Room( This is tresure rooms healing rooms ect that are random).
	public bool doorTop, doorBot, doorLeft, doorRight;
	public Room(Vector2 _gridPos, int _type){
		gridPos = _gridPos;
		type = _type;
	}
}
