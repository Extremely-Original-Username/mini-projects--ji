using TEST;

ConsoleDisplay<int> console = new ConsoleDisplay<int>(40, 40, new Dictionary<int, char>
{
    { 0, '.' },
    { 1, '#' }
});

GOLAutomaton GOL = new GOLAutomaton(40, 40, new RandomNoiseGen());

while (true)
{
    console.printGrid(GOL.grid);
    GOL.step();
    await Task.Delay(100);
}