using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_selection_sort_script : MonoBehaviour
{
    public Material[] mat;
    Renderer rend;


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
            cube.transform.localScale = new Vector3(0.9f,random_value,1);

            //setting up the position of each cube
            cube.transform.position = new Vector3(i,random_value/2.0f,0);

            //to reference the parent array Cubes
            cube.transform.parent = this.transform;


   

            Cubes[i] = cube;
            //LeanTween.color(Cubes[i], Color.white, 1);

            
        }

    }


     IEnumerator selection_sort(GameObject [] list)
    {
        int min_value;
        GameObject temp;
        Vector3 temp_position;

        for (int i = 0; i < list.Length; i++)
        { 
            min_value = i;

            yield return new WaitForSeconds(1);
            //yield return is also a return type but for IEnumerator  and yield when paired with waitforseconds can have a delay for required amount of time .
            for (int j = i + 1; j < list.Length; j++)
            { //comparing the cubes on the basis of height
                
               
                if (list[j].transform.localScale.y < list[min_value].transform.localScale.y)
                {
                    min_value = j;

                   

                }
                
            }
           
            LeanTween.color(list[min_value], Color.yellow, 1);
            if (min_value != i)
            { //delay everytime a swap is happening
                yield return new WaitForSeconds(1);

                temp = list[i];
                list[i] = list[min_value];
                list[min_value] = temp;
                temp_position = list[i].transform.localPosition;
                
                //using leantween to get smooth animation of the swapping 
                LeanTween.moveLocalX(list[i],list[min_value].transform.localPosition.x,1);
                LeanTween.moveLocalZ(list[i], -3, 0.5f).setLoopPingPong(1);
                
                LeanTween.moveLocalX(list[min_value], temp_position.x,1);
                LeanTween.moveLocalZ(list[min_value], 3, 0.5f).setLoopPingPong(1);

                //adding colors 
                LeanTween.color(list[i],Color.magenta,1);



                //list[i].transform.localPosition = new Vector3(list[min_value].transform.localPosition.x, temp_position.y, temp_position.z);
                // list[min_value].transform.localPosition = new Vector3(temp_position.x, list[min_value].transform.localPosition.y, list[min_value].transform.localPosition.z);

                //the above code is used to swap the positions of the current min_value with the actual min value in that iteration 
            }
            else
            {
                LeanTween.color(list[min_value], Color.magenta, 1);
            }

        }

    }

    void Start()
    {
        

        init();
       StartCoroutine(selection_sort(Cubes));

    }

  
}
