using System;
using Entity;
using ReadFile;
using System.Collections;
using System.Collections.Generic;

namespace AlgCompute
{
    public class BFS
    {
        Queue<Tuple<char,char>> ProcessQ= new Queue<Tuple<char,char>>();
        Graph Map = ReadFromFile.province;
        Graph State = new Graph();
    }
}