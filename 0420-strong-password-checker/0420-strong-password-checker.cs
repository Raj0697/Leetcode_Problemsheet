public class Solution {
    public int StrongPasswordChecker(string password) {
         if (string.IsNullOrEmpty(password)) return 6;

 var length = password.Length;
 var sb = new StringBuilder();
 sb.Append(password[0]);
 for (int i = 1; i < length; i++)
 {
     if (password[i] != password[i - 1])
         sb.Append(' ');
     sb.Append(password[i]);
 }

 bool hasDigit = false, hasLower = false, hasUpper = false;
 int replacements = 0;
 var replace = new int[3] { 0, 0, 0 };
 var words = sb.ToString().Split();
 foreach (var word in words)
 {
     var ch = word[0];
     hasDigit = hasDigit || char.IsDigit(ch);
     hasLower = hasLower || char.IsLower(ch);
     hasUpper = hasUpper || char.IsUpper(ch);

     replacements += word.Length / 3;
     if (word.Length >= 3)
         replace[word.Length % 3]++;
 }

 var deletions = Math.Max(0, length - 20);
 var additions = Math.Max((hasDigit ? 0 : 1) + (hasLower ? 0 : 1) + (hasUpper ? 0 : 1), 6 - length);

 var d = deletions;
 replacements -= Math.Min(replace[0], d);
 d = Math.Max(d - replace[0], 0);
 replacements -= Math.Min(replace[1], d / 2);
 d = Math.Max(d - replace[1] * 2, 0);
 replacements -= d / 3;

 return deletions + Math.Max(replacements, additions);
    }
}