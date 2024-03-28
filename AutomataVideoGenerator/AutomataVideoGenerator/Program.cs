using AutomataVideoGenerator.Automatons;
using AutomataVideoGenerator.Automatons.Standard;
using System.Drawing;

//runAutomaton(new GameOfLife(100, 100), 100, "GOLResults");

runGPUAutomaton(new BoostedBugs(50, 50), 50, "BoostedBUGSResults");
runAutomaton(new Bugs(50, 50), 50, "BUGSResults");

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
        automaton.getImage(10).Save(savePath + "/" + i + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);
        automaton.update();
    }
}