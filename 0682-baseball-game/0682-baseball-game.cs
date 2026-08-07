public class Solution {
    public int CalPoints(string[] operations) {
        var roundPoints = new int[operations.Length];
var index = 0;

foreach (var op in operations)
{
    if (op == "C")
        index--;
    else if (op == "D")
    {
        roundPoints[index] = roundPoints[index - 1] * 2;
        index++;
    }
    else if (op == "+")
    {
        roundPoints[index] = roundPoints[index - 1] + roundPoints[index - 2];
        index++;
    }
    else
        roundPoints[index++] = int.Parse(op);
}

var sum = 0;
for (int i = 0; i < index; i++)
    sum += roundPoints[i];

return sum;
    }
}