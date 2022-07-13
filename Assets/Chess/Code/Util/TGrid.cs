using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TGrid<T>
{
    int width, height;
    T[,] grid;

    public TGrid(int width, int height){
        this.width = width;
        this.height = height;
        grid = new T[width, height];
    }

    public void setTile(int x, int y, T newElem){
        grid[x, y] = newElem;
    }

    
    public T getTile(int x, int y){
        return grid[x, y];
    }

    public (int, int) getDimensions(){
        return (width, height);
    }

    public override string ToString(){
        string res = "[";

        for(int i = 0; i < width; i++){
            for(int j = 0; j < height; j++){
                res += ", " + grid[i, j];
            }
            res += "\n";
        }

        res += "]";

        return res;
    }
}
