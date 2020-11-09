using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_merge_sort_script : MonoBehaviour
{// the maximum number of cubes we want to sort
 public int NOC = 20;

    // maximum height of a cube is 10 
      public int Cube_H = 20;

    //array of GameObjects
      public GameObject[] Cubes;

    /* void printer(int[] list)
     {
         string s = "";
         for(int i=0;i<list.Length;i++)
         {
             s = s + list[i].ToString(); 
         }

         Debug.Log(s);
     }
    */

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

            //setting up the dimensions of the cube
            cube.transform.localScale = new Vector3(0.9f, random_value, 1);

            //setting up the position of each cube
            cube.transform.position = new Vector3(i, random_value / 2.0f, 0);

            //to reference the parent array Cubes
            cube.transform.parent = this.transform;

            Cubes[i] = cube;

        }

    }

    void merge(GameObject[] arr, int l, int m, int r)
    {

        int n1 = m - l + 1;
        int n2 = r - m;
        Debug.Log("n1 : " + n1 + " n2 : " + n2);
        Debug.Log(" l : " + l + "m : " + m + "r : " + r);
        GameObject temp;
        Vector3 temp_position;

        // Create temp arrays
        GameObject[] L = new GameObject[n1];
        GameObject[] R = new GameObject[n2];
        int i, j;

        // Copy data to temp arrays
        for (i = 0; i < n1; ++i)
        {
            L[i] = arr[l + i];
            L[i].transform.localPosition = arr[l + i].transform.localPosition;
            Debug.Log(l + i);

        }   
        
        for (j = 0; j < n2-1; ++j)
            {
                R[j] = arr[m + 1 + j];
            R[j].transform.localPosition = arr[m + 1 + j].transform.localPosition;
                Debug.Log(m + 1 + j);
            }
            // Merge the temp arrays

            // Initial indexes of first 
            // and second subarrays
            i = 0;
            j = 0;

            // Initial index of merged 
            // subarry array
            int k = l;
            while (i < n1 && j < n2-1)
            {
                Debug.Log(" l[i] : " + L[i].transform.localScale.y + " R[j] : " + R[j].transform.localScale.y);
                if (L[i].transform.localScale.y < R[j].transform.localScale.y)
                {

                    temp = arr[k];
                    arr[k] = L[i];
                    L[i] = temp;
                    temp_position = arr[i].transform.localPosition;



                    arr[k].transform.localPosition = new Vector3(L[i].transform.localPosition.x, temp_position.y, temp_position.z);
                    L[i].transform.localPosition = new Vector3(temp_position.x, L[i].transform.localPosition.y, L[i].transform.localPosition.z);


                    i++;
                }
                else
                {

                    temp = arr[k];
                    arr[k] = R[j];
                    R[j] = temp;
                    temp_position = arr[k].transform.localPosition;
                    arr[k].transform.localPosition = new Vector3(R[j].transform.localPosition.x, temp_position.y, temp_position.z);
                    R[j].transform.localPosition = new Vector3(temp_position.x, R[j].transform.localPosition.y, R[j].transform.localPosition.z);
                    j++;
                }
                k++;
            }

            // Copy remaining elements 
            // of L[] if any 
            while (i < n1)
            {
                temp = arr[k];
                arr[k] = L[i];
                L[i] = temp;
                temp_position = arr[i].transform.localPosition;
                arr[k].transform.localPosition = new Vector3(L[i].transform.localPosition.x, temp_position.y, temp_position.z);
                L[i].transform.localPosition = new Vector3(temp_position.x, L[i].transform.localPosition.y, L[i].transform.localPosition.z);

                i++;
                k++;
            }

            // Copy remaining elements 
            // of R[] if any 
            while (j < n2-1)
            {

                temp = arr[k];
                arr[k] = R[j];
                R[j] = temp;
                temp_position = arr[k].transform.localPosition;
                arr[k].transform.localPosition = new Vector3(R[j].transform.localPosition.x, temp_position.y, temp_position.z);
                R[j].transform.localPosition = new Vector3(temp_position.x, R[j].transform.localPosition.y, R[j].transform.localPosition.z);

                j++;
                k++;
            }
        }
    

  void sort(GameObject [] list,int l,int r)
    {
       
        if(l<r)
        {
           
            int m = (l + r) / 2;
            sort(list, l, m);
            sort(list, m + 1, r);

            merge(list, l, m, r);
            
        }
    }

    void Start()
    {
        //int[] list =new int[] {2,1,4,5,3};

        //Debug.Log("initial : ");

        //  printer(list);
        init();
       sort(Cubes,0,NOC);
      
      //  printer(list);

    }

  
   
}
