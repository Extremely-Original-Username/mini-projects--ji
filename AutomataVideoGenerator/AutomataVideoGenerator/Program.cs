using AutomataVideoGenerator.Automatons;
using AutomataVideoGenerator.Automatons.Standard;
using System.Drawing;

//runAutomaton(new GameOfLife(100, 100), 100, "GOLResults");

runGPUAutomaton(new BoostedBugs(5, 5), 50, "BoostedBUGSResults");
runAutomaton(new Bugs(100, 100), 50, "BUGSResults");

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

static void runGPUAutomaton(BaseGpuAutomaton automaton, int cycles, string savePath = "results")
{
    Directory.CreateDirectory(savePath);

    for (int i = 0; i < cycles; i++)
    {
        Console.Clear();
        Console.WriteLine("Processing: " + i);
        automaton.getImage(100).Save(savePath + "/" + i + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);
        automaton.update();
    }
}