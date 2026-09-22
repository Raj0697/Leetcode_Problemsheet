/**
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 * interface NestedInteger {
 *
 *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
 *     bool IsInteger();
 *
 *     // @return the single integer that this NestedInteger holds, if it holds a single integer
 *     // Return null if this NestedInteger holds a nested list
 *     int GetInteger();
 *
 *     // @return the nested list that this NestedInteger holds, if it holds a nested list
 *     // Return null if this NestedInteger holds a single integer
 *     IList<NestedInteger> GetList();
 * }
 */
public class NestedIterator {

    IEnumerator<int> _enumerator;

    public NestedIterator(IList<NestedInteger> nestedList) {               
        _enumerator = CreateEnumerable(nestedList).GetEnumerator();
    }

    IEnumerable<int> CreateEnumerable(IList<NestedInteger> nestedList) {
        foreach (var nestedInteger in nestedList) {
            if (nestedInteger.IsInteger()) yield return nestedInteger.GetInteger();
            else foreach (var child in CreateEnumerable(nestedInteger.GetList())) yield return child;            
        }
    }

    public bool HasNext() {
        return _enumerator.MoveNext();
    }

    public int Next() {
        return _enumerator.Current;
    }
}

/**
 * Your NestedIterator will be called like this:
 * NestedIterator i = new NestedIterator(nestedList);
 * while (i.HasNext()) v[f()] = i.Next();
 */