public class RandomizedCollection {
  private readonly Random random;
  private readonly IDictionary<int, ISet<int>> locations;
  private readonly IList<int> nums;
    public RandomizedCollection() {
         random = new Random();
 locations = new Dictionary<int, ISet<int>>();
 nums = new List<int>();
    }
    
    public bool Insert(int val) {
         if (!locations.ContainsKey(val))
     locations[val] = new HashSet<int>();

 locations[val].Add(nums.Count);
 nums.Add(val);
 return locations[val].Count == 1;
    }
    
    public bool Remove(int val) {
         if (!locations.ContainsKey(val)) return false;

 var id = locations[val].First();
 locations[val].Remove(id);

 var num = nums[nums.Count - 1];
 nums[id] = num;
 locations[num].Add(id);
 locations[num].Remove(nums.Count - 1);
 nums.RemoveAt(nums.Count - 1);

 if (locations[val].Count == 0) locations.Remove(val);

 return true;
    }
    
    public int GetRandom() {
         var id = random.Next(nums.Count);
 return nums[id];
    }
}

/**
 * Your RandomizedCollection object will be instantiated and called as such:
 * RandomizedCollection obj = new RandomizedCollection();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */