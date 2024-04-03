using AutomataVideoGenerator.Automatons;
using AutomataVideoGenerator.Automatons.GPUCompute;
using AutomataVideoGenerator.Automatons.Standard;
using System.Drawing;

//new BoostedGameOfLife(100, 100).run(50, "BoostedGOLResults", 10);
//new BoostedBugs(100, 100).run(50, "BoostedBUGSResults", 10);

new GenericBSN(100, 100, GenericBSN.defaults.GameOfLife).run(50, "BoostedGOLResults", 10);
new GenericBSN(100, 100, GenericBSN.defaults.Bugs).run(50, "BoostedBugsResults", 10);

