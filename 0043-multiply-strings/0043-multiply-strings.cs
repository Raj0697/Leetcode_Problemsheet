public class Solution {
    public string Multiply(string num1, string num2) {
        if (num1 == "0" || num2 == "0") return "0";
        
        int[] result = new int[num1.Length + num2.Length];
        
        for (int i = num1.Length - 1; i >= 0; i--) {
            for (int j = num2.Length - 1; j >= 0; j--) {
                int mul = (num1[i] - '0') * (num2[j] - '0');
                int sum = mul + result[i + j + 1];
                result[i + j + 1] = sum % 10;
                result[i + j] += sum / 10;
            }
        }
        
        var res = new System.Text.StringBuilder();
        foreach (int num in result) {
            if (!(res.Length == 0 && num == 0)) res.Append(num);
        }
        
        return res.ToString();
    }
}