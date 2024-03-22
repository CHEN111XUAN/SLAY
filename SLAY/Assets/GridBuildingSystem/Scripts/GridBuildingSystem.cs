using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBuildingSystem : MonoBehaviour {
    public static GridBuildingSystem Instance { get; private set; }
    private Grid<GridObject> grid;

    private void Awake() {
        Instance = this;

        int gridWidth = 20;
        int gridHeight = 10;
        float cellSize = 1f;
        Vector3 originPosition = new Vector3(-10, -5);
        grid = new Grid<GridObject>(gridWidth, gridHeight, cellSize, originPosition, (Grid<GridObject> g, int x, int y) => new GridObject(g, x, y));
    }

    public class GridObject {
        private Grid<GridObject> grid;
        private int x;
        private int y;

        public Sprite placedObject;

        public GridObject(Grid<GridObject> grid, int x, int y) {
            this.grid = grid;
            this.x = x;
            this.y = y;
            placedObject = null;
        }

        public override string ToString() {
            return x + ", " + y + "\n" + placedObject;
        }
    }

    private void Update() {
        // if (Input.GetMouseButtonDown(0)) {
        // }
    }

    // Get Mouse Position in World with Z = 0f
    private Vector3 GetMouseWorldPosition() {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }
    private Vector3 GetMouseWorldPositionWithZ() {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }
    private Vector3 GetMouseWorldPositionWithZ(Camera worldCamera) {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }
    private Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera) {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
}