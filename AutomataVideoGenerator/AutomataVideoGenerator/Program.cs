﻿using AutomataVideoGenerator.Automatons;
using System.Drawing;

runAutomaton(new GameOfLife(100, 100), 100, "GOLResults");
runAutomaton(new Bugs(100, 100), 100, "BUGSResults");

static void runAutomaton(BaseAutomaton automaton, int cycles, string savePath = "results")
{
    Directory.CreateDirectory(savePath);

    for (int i = 0; i < cycles; i++)
	{
        Console.Clear();
        Console.WriteLine("Processing: " + i);
        automaton.getImage(1).Save(savePath + "/" + i + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);
        automaton.update();
    }
}