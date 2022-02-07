namespace ToyRobotSimulator_Project.Models
{
    public class TableTop
    {
        public int TableSizeX { get; }
        public int TableSizeY { get; }

        public int TableSizeStartX { get; }
        public int TableSizeStartY { get; }

        public TableTop(int tableSizeX, int tableSizeY)
        {
            TableSizeX = tableSizeX;
            TableSizeY = tableSizeY;

            TableSizeStartX = 0;
            TableSizeStartY = 0;
        }
    }
}
