using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GenerateMap : MonoBehaviour {

    public enum Grid {
        Empty,
        Grass,
        Water
    }

    public Tilemap tileMapWater;
    public Tilemap tileMapGrass;
    public Tile grass;
    public Tile water;
    public int MapWidth = 10;
    public int MapHeight = 10;
    public GameObject boulderObject;

    public float waterCoverage = 0.1f;
    public int waterSize = 1;

    // Start is called before the first frame update
    void Start() {
        InitialiseGrid();
        SpawnResources();
    }

    private void InitialiseGrid() {

        for (int x = 0; x < MapWidth; x++) {
            for (int y = 0; y < MapHeight; y++) {
                tileMapGrass.SetTile(new Vector3Int(x - (MapWidth / 2), y - (MapHeight / 2), 0), grass);
            }
        }

        float grassTracker = MapWidth * MapHeight;
        float waterTracker = 16.0f;

        while ((waterTracker / grassTracker) < waterCoverage) {
            Vector3Int currentPos = new Vector3Int(Random.Range(-MapWidth / 2, MapWidth / 2), Random.Range(-MapHeight / 2, MapHeight / 2), 0);
            bool keepDrawing = true;

            while (keepDrawing) {
                for (int x = -1; x <= 1; x++) {
                    for (int y = -1; y <= 1; y++) {
                        Vector3Int surroundingPos = new Vector3Int(x, y, 0);
                        Vector3Int nextPos = currentPos + surroundingPos;
                        if ((nextPos.x >= -MapWidth / 2 && nextPos.x < MapWidth / 2) &&
                            (nextPos.y >= -MapHeight / 2 && nextPos.y < MapHeight / 2) &&
                            tileMapWater.GetTile(nextPos) != water &&
                            !(nextPos.x >= -2 && nextPos.x <= 1 && nextPos.y >= -2 && nextPos.y <= 1)) {
                            tileMapWater.SetTile(nextPos, water);
                            waterTracker += 1.0f;
                        }
                    }
                }
                int threshold = Random.Range(0, 210);
                if (threshold <= waterSize) {
                    currentPos = MovePos(currentPos);
                    if (currentPos.x < -MapWidth / 2 || currentPos.x >= MapWidth / 2 || currentPos.y < -MapHeight / 2 || currentPos.y >= MapHeight / 2) {
                        keepDrawing = false;
                    }
                }
                else {
                    keepDrawing = false;
                }
            }
        }
    }

    Vector3Int MovePos(Vector3Int pos) {
        int decider = Random.Range(1, 5);

        switch (decider) {
            case 1:
                pos.x -= 1;
                break;
            case 2:
                pos.y -= 1;
                break;
            case 3:
                pos.x += 1;
                break;
            case 4:
                pos.y += 1;
                break;
        }
        return pos;
    }

    private void SpawnResources() {
        for (int i = 0; i < 5; i++) {
            int spotX = Random.Range(-MapWidth + 1, MapWidth - 1);
            int spotY = Random.Range(-MapHeight + 1, MapHeight - 1);

            Instantiate(boulderObject, new Vector3(spotX/2, spotY/2, 0), new Quaternion());
        }
        
    }
}
