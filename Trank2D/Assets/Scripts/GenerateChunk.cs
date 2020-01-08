﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateChunk : MonoBehaviour
{
    public GameObject DirtTile;
    public GameObject GrassTile;
    public GameObject StoneTile;
    public int width;
    public float heightMultiplier;
    public int heightAddition;
    public float smoothness;
    float seed;
    void Start()
    {
        Generate();
        seed = Random.Range(-10000f, 10000f);
    }

    public void Generate()
    {
        for(int i = 0; i < width; i++) {
            int h = Mathf.RoundToInt(Mathf.PerlinNoise (seed, i / smoothness ) * heightMultiplier) + heightAddition;
            for(int j = 0; j < h; j++) {
                GameObject selectedTile;
                if(j < h - 4) {
                    selectedTile = StoneTile;
                } else if ( j < h -1) {
                    selectedTile = DirtTile;
                } else {
                    selectedTile = GrassTile;
                }
                Instantiate(selectedTile, new Vector3(i, j), Quaternion.identity);

            }
        }
    }
}
