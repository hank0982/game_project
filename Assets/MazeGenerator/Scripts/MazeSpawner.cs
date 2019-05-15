using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

//<summary>
//Game object, that creates maze and instantiates it in scene
//</summary>
public class MazeSpawner : MonoBehaviour {
    public enum MazeGenerationAlgorithm{
        PureRecursive,
        RecursiveTree,
        RandomTree,
        OldestTree,
        RecursiveDivision,
    }

    public MazeGenerationAlgorithm Algorithm = MazeGenerationAlgorithm.PureRecursive;
    public bool FullRandom = false;
    public int RandomSeed = 12345;
    public GameObject[] Floor = null;
    public GameObject Wall = null;
    public GameObject Pillar = null;
    public int Rows = 5;
    public int Columns = 5;
    public float CellWidth = 5;
    public float CellHeight = 5;
    public bool AddGaps = true;
    public GameObject GoalPrefab = null;

    private BasicMazeGenerator mMazeGenerator = null;

    void Start () {
        try
        {
            Debug.Log("level: " + PlayerPrefs.GetInt("level"));
            Rows = (PlayerPrefs.GetInt("level")+1) * 5;
            Columns = (PlayerPrefs.GetInt("level")+1) * 5;
        }
        catch (Exception e)
        {
            Debug.Log("Cannot get int level!");
            PlayerPrefs.SetInt("level", 0);
            Debug.Log("set level: " + PlayerPrefs.GetInt("level"));
            Rows = PlayerPrefs.GetInt("level") * 5;
            Columns = PlayerPrefs.GetInt("level") * 5;
        }
        // Rows = 3;
        // Columns = 3;
        if (!FullRandom) {
            UnityEngine.Random.InitState(RandomSeed);
        }
        switch (Algorithm) {
        case MazeGenerationAlgorithm.PureRecursive:
            mMazeGenerator = new RecursiveMazeGenerator (Rows, Columns);
            break;
        case MazeGenerationAlgorithm.RecursiveTree:
            mMazeGenerator = new RecursiveTreeMazeGenerator (Rows, Columns);
            break;
        case MazeGenerationAlgorithm.RandomTree:
            mMazeGenerator = new RandomTreeMazeGenerator (Rows, Columns);
            break;
        case MazeGenerationAlgorithm.OldestTree:
            mMazeGenerator = new OldestTreeMazeGenerator (Rows, Columns);
            break;
        case MazeGenerationAlgorithm.RecursiveDivision:
            mMazeGenerator = new DivisionMazeGenerator (Rows, Columns);
            break;
        }
        mMazeGenerator.GenerateMaze ();
        for (int row = 0; row < Rows; row++) {
            for(int column = 0; column < Columns; column++){
                float x = column*(CellWidth+(AddGaps?.2f:0));
                float z = row*(CellHeight+(AddGaps?.2f:0));
                MazeCell cell = mMazeGenerator.GetMazeCell(row,column);
                GameObject tmp;
                GameObject randomFloor = Floor[(UnityEngine.Random.Range(0, Floor.Length))];
                int[] rotation = { 0, 90, 180, 270 };
                int rotationResult = rotation[UnityEngine.Random.Range(0, 4)];
                tmp = Instantiate(randomFloor, new Vector3(x,0,z), Quaternion.Euler(0, rotationResult, 0)) as GameObject;
                tmp.tag = "Floor";
                tmp.transform.parent = transform;
                if(cell.WallRight){
                    tmp = Instantiate(Wall,new Vector3(x+CellWidth/2,0,z)+Wall.transform.position,Quaternion.Euler(0,90,0)) as GameObject;// right
                    tmp.transform.localScale += new Vector3(0, 3, 0);
                    tmp.transform.parent = transform;
                }
                if(cell.WallFront){
                    tmp = Instantiate(Wall,new Vector3(x,0,z+CellHeight/2)+Wall.transform.position,Quaternion.Euler(0,0,0)) as GameObject;// front
                    tmp.transform.localScale += new Vector3(0, 3, 0);
                    tmp.transform.parent = transform;
                }
                if(cell.WallLeft){
                    tmp = Instantiate(Wall,new Vector3(x-CellWidth/2,0,z)+Wall.transform.position,Quaternion.Euler(0,270,0)) as GameObject;// left
                    tmp.transform.localScale += new Vector3(0, 3, 0);
                    tmp.transform.parent = transform;
                }
                if(cell.WallBack){
                    tmp = Instantiate(Wall,new Vector3(x,0,z-CellHeight/2)+Wall.transform.position,Quaternion.Euler(0,180,0)) as GameObject;// back
                    tmp.transform.localScale += new Vector3(0, 3, 0);
                    tmp.transform.parent = transform;
                }

                if(row == Rows-1 && column == Columns-1){
                    tmp = Instantiate(GoalPrefab,new Vector3(x,1,z), Quaternion.Euler(0,0,0)) as GameObject;
                    tmp.transform.parent = transform;
                }
            }
        }
        if(Pillar != null){
            for (int row = 0; row < Rows+1; row++) {
                for (int column = 0; column < Columns+1; column++) {
                    float x = column*(CellWidth+(AddGaps?.2f:0));
                    float z = row*(CellHeight+(AddGaps?.2f:0));
                    GameObject tmp = Instantiate(Pillar,new Vector3(x-CellWidth/2,0,z-CellHeight/2),Quaternion.identity) as GameObject;
                    tmp.transform.localScale += new Vector3(0, 3, 0);
                    tmp.transform.parent = transform;
                }
            }
        }
    }
}
