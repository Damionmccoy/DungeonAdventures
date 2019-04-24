using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInstance : MonoBehaviour {
	public Texture2D tex;
	[HideInInspector]
	public Vector2 gridPos;
	public int type; // 0: normal, 1: enter
	[HideInInspector]
	public bool doorTop, doorBot, doorLeft, doorRight;
	[SerializeField]
	GameObject doorU, doorD, doorL, doorR, doorWall;
	[SerializeField]
	ColorToGameObject[] mappings;
	float tileSize = 16;
	Vector2 roomSizeInTiles = new Vector2(9,17);
    public int NumOfEnemies;
    [Range(0, 1)]
    public float EnemyChanceToSpawn;
    public List<GameObject> Enemies;
    private List<Vector3> EmptyTiles;
    private List<DoorTrigger> doors;
    private List<Vector3> doorLocations;

    //The start function for this class
	public void Setup(Texture2D _tex, Vector2 _gridPos, int _type, bool _doorTop, bool _doorBot, bool _doorLeft, bool _doorRight){
        //Set variables
        tex = _tex;
		gridPos = _gridPos;
		type = _type;
		doorTop = _doorTop;
		doorBot = _doorBot;
		doorLeft = _doorLeft;
		doorRight = _doorRight;

        //initialize lists 

        doors = new List<DoorTrigger>();
        doorLocations = new List<Vector3>();
        EmptyTiles = new List<Vector3>();
        //Room funcion calls for setup
        MakeDoors();
		GenerateRoomTiles();
        PlaceEnemies();
	}
	void MakeDoors(){
        DoorTrigger door;
		//top door, get position then spawn
		Vector3 spawnPos = transform.position + Vector3.up*(roomSizeInTiles.y/4 * tileSize) - Vector3.up*(tileSize/4);
        //doors.Add(spawnPos);
		door = PlaceDoor(spawnPos, doorTop, doorU);
        if(door != null)
        {
            //Debug.Log("set door");
            door.DoorXPos = 0;
            door.DoorYPos = 1;
            doors.Add(door);
        }
		//bottom door
		spawnPos = transform.position + Vector3.down*(roomSizeInTiles.y/4 * tileSize) - Vector3.down*(tileSize/4);
		door = PlaceDoor(spawnPos, doorBot, doorD);
        //doors.Add(spawnPos);
        if (door != null)
        {
            //Debug.Log("set door");
            door.DoorXPos = 0;
            door.DoorYPos = -1;
            doors.Add(door);
        }
        //right door
        spawnPos = transform.position + Vector3.right*(roomSizeInTiles.x * tileSize) - Vector3.right*(tileSize);
		door = PlaceDoor(spawnPos, doorRight, doorR);
        //doors.Add(spawnPos);
        if (door != null)
        {
            //Debug.Log("set door");
            door.DoorXPos = 1;
            door.DoorYPos = 0;
            doors.Add(door);
        }
        //left door
        spawnPos = transform.position + Vector3.left*(roomSizeInTiles.x * tileSize) - Vector3.left*(tileSize);
		door = PlaceDoor(spawnPos, doorLeft, doorL);
        
        if (door != null)
        {
           
            //Debug.Log("set door");
            door.DoorXPos = -1;
            door.DoorYPos = 0;
            doors.Add(door);
        }
    }
	DoorTrigger PlaceDoor(Vector3 spawnPos, bool door, GameObject doorSpawn){
        // check whether its a door or wall, then spawn
        doorLocations.Add(spawnPos);
        if (door){
            return Instantiate(doorSpawn, spawnPos, Quaternion.identity, transform).GetComponent<DoorTrigger>();
           
		}else{
			Instantiate(doorWall, spawnPos, Quaternion.identity).transform.parent = transform;
            return null;
		}
	}
	void GenerateRoomTiles(){
		//loop through every pixel of the texture
		for(int x = 0; x < tex.width; x++){
			for (int y = 0; y < tex.height; y++){
				GenerateTile(x,y);
			}
		}
	}
	void GenerateTile(int x, int y){
		Color pixelColor = tex.GetPixel(x,y);
		//skip clear spaces in texture
		if (pixelColor.a == 0){
            EmptyTiles.Add(positionFromTileGrid(x, y)); //add the tile to a list so we can use them later
            return;
		}
		//find the color to math the pixel
		foreach (ColorToGameObject mapping in mappings){
			if (mapping.color.Equals(pixelColor)){
				Vector3 spawnPos = positionFromTileGrid(x,y);//spawn the object associated with the color
				Instantiate(mapping.prefab, spawnPos, Quaternion.identity).transform.parent = this.transform;
			}else{
                //EmptyTiles.Add( positionFromTileGrid(x, y)); //add the tile to a list so we can use them later 
			}
		}
	}
	Vector3 positionFromTileGrid(int x, int y){
		Vector3 ret;
		//find difference between the corner of the texture and the center of this object
		Vector3 offset = new Vector3((-roomSizeInTiles.x + 1)*tileSize, (roomSizeInTiles.y/4)*tileSize - (tileSize/4), 0);
		//find scaled up position at the offset
		ret = new Vector3(tileSize * (float) x, -tileSize * (float) y, 0) + offset + transform.position;
		return ret;
	}

    void CheckEmptyTilesForDoors()
    {
        foreach(Vector3 tile in doorLocations)
        {
            if (EmptyTiles.Contains(tile))
            {
                EmptyTiles.Remove(tile);
            }
        }
    }

    void PlaceEnemies()
    {

        //funny math to try to keep the enemies spaced out 
        int space = (EmptyTiles.Capacity / NumOfEnemies)/2;
        int spaceCount = 0;
        CheckEmptyTilesForDoors();

        foreach (Vector3 pos in EmptyTiles)
        {


            float rand = Random.Range(0, 1);

            if(NumOfEnemies > 0 && rand < EnemyChanceToSpawn && spaceCount <= 0)
            {
                print("spawn enemy");
                NumOfEnemies--;
                spaceCount = space;
                int choice = Random.Range(0, Enemies.Capacity);
                GameObject enemy = Enemies[choice];
                Instantiate(enemy, pos, Quaternion.identity).transform.parent = this.transform;
            }
            else
            {
                spaceCount--;
            }
        }
    }
}
