using System.Collections.Generic;
using System.Linq;

namespace Permutations
{
  class Program
  {
    static void Main(string[] args)
    {
      Program p = new Program();
      var nums = new int[] { 1, 2, 3 };
      p.Permute(nums);
    }

    public IList<IList<int>> Permute(int[] nums)
    {
      var result = new List<IList<int>>();
      Backtracking(nums, result, new HashSet<int>());
      return result;
    }

    private void Backtracking(int[] nums, List<IList<int>> result, HashSet<int> temp)
    {
      if (temp.Count == nums.Length)
      {
        result.Add(new List<int>(temp));
      }
      else
      {
        // we need to check for all the array elements every time
        for (int i = 0; i < nums.Length; i++)
        {
          if (temp.Contains(nums[i])) continue; // All the game change happened in this line only
          temp.Add(nums[i]);
          Backtracking(nums, result, temp);
          var list = temp.ToList();
          temp.Remove(list[temp.Count - 1]);
        }
      }
    }
  }
}
