using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_bubble_sort_script : MonoBehaviour
{
    public Material[] mat;

    
    // the maximum number of cubes we want to sort
    public int NOC = 20;

    // maximum height of a cube is 10 
    public int Cube_H = 20;

    //array of GameObjects
    public GameObject[] Cubes;


    //this is the initializer for our cubes
    void init()
    {
        // initialzing the array with the number of cubes we want
        Cubes = new GameObject[NOC];
        for (int i = 0; i < NOC; i++)
        {

            int random_value = Random.Range(1, Cube_H + 1);
            //this is used to get a set of random values for sorting which ranges from 1 to the max cube height 
            // i used cube height + 1 because Random.Range doesn't include the upper limit in the set of values so if used only the height as upper limit i can never get a cube of max height.

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //the above line is used to create cubes using primitive mesh renderer.

            Renderer cubeRenderer = cube.GetComponent<Renderer>();

            //Call SetColor using the shader property name "_Color" and setting the color to red
            cubeRenderer.material = mat[0];
            //setting up the dimensions of the cube
            cube.transform.localScale = new Vector3(0.9f, random_value, 1);

            //setting up the position of each cube
            cube.transform.position = new Vector3(i, random_value / 2.0f, 0);

            //to reference the parent array Cubes
            cube.transform.parent = this.transform;
            

            Cubes[i] = cube;
           // LeanTween.color(Cubes[i], Color.white, 1);
              
        }

    }

    IEnumerator Bubble_Sort(GameObject[] list)
    {
        GameObject temp;
        Vector3 temp_position;
        int j;

        for(int i=0;i<NOC - 1 ;i++)
        {
            
           
            for( j=0;j<NOC - i -1;j++)
            {
                LeanTween.color(list[j], Color.yellow, 0.15f);

                if (list[j].transform.localPosition.y > list[j+1].transform.localPosition.y)
                {
                    yield return new WaitForSeconds(0.7f);
                    temp = list[j];
                    list[j] = list[j + 1];
                    list[j + 1] = temp;
                    temp_position = list[j].transform.localPosition;
                   
                    LeanTween.moveLocalX(list[j], list[j+1].transform.localPosition.x, 0.15f);
                   

                    LeanTween.moveLocalZ(list[j], -1, 0.2f).setLoopPingPong(1);
                    

                    LeanTween.moveLocalX(list[j+1], temp_position.x, 0.15f);
                    
                    LeanTween.moveLocalZ(list[j+1], 1, 0.2f).setLoopPingPong(1);
                   

                    //list[j].transform.localPosition = new Vector3(list[j+1].transform.localPosition.x, temp_position.y, temp_position.z);
                    // list[j+1].transform.localPosition = new Vector3(temp_position.x, list[j+1].transform.localPosition.y, list[j+1].transform.localPosition.z);

                }else
                    LeanTween.color(list[j], Color.white, 0.15f);

            }
            //for the element which is sorted
            LeanTween.color(list[j], Color.magenta, 0.15f);
        }
        LeanTween.color(list[0], Color.magenta, 0.15f);
    }

    
    void Start()
    {
        init();
       StartCoroutine(Bubble_Sort(Cubes));
    }

 
}
