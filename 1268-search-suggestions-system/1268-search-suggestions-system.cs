public class Solution {
    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord) {
        var result = new List<IList<string>>();
        var previouse = products.OrderBy(it => it).ToList();
        for (var i = 0; i < searchWord.Length; i++)
        {
            var temp = new List<string>();
            foreach (var product in previouse)
            {
                if (product.Length > i && product[i] == searchWord[i])
                {
                    temp.Add(product);
                }
            }

            previouse = temp;
            result.Add(temp.Take(3).ToArray());
        }

        return result;
    }
}