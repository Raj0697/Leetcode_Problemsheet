class Solution(object):
    def arraySign(self, nums):
        return 0 if 0 in nums else -1 if sum(x < 0 for x in nums) % 2 else 1