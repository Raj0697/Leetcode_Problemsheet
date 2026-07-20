public class StockSpanner
{
    private Stack<(int price, int count)> st;

    public StockSpanner()
    {
        st = new Stack<(int, int)>();
    }

    public int Next(int price)
    {
        int cnt = 1;

        while (st.Count > 0 && st.Peek().price <= price)
        {
            cnt += st.Peek().count;
            st.Pop();
        }

        st.Push((price, cnt));
        return cnt;
    }
}