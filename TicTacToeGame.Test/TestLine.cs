namespace TicTacToeGame.Test
{
    public class TestLine
    {
        public int RowStart { get; set; }
        public int ColumnStart { get; set; }
        public int RowEnd { get; set; }
        public int ColumnEnd { get; set; }
        public int RowEvaluate { get; set; }
        public int ColumnEvaluate { get; set; }
        public string EvaluateValue { get; set; }
        public bool ExpectedCanHandleValue { get; set; }
    }
}