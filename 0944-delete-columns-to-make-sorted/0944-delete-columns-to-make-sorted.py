class Solution(object):
    def minDeletionSize(self, A):
        return len([True for col in zip(*A) if sorted(col) != list(col)])
        