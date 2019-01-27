public class Solution
{
    public string Convert(string s, int numRows)
    {
        int n = numRows;
        int l = s.Length;

        if (n == 1)
        {
            return s;
        }
        string ret = "";
        string endStr = "";
        for (int i = 0, j = 0; 2 * i * (n - 1) - j < s.Length; i++)
        {
            ret += s[2 * i * (n - 1) - j];
            s = s.Remove(2 * i * (n - 1) - j, 1);
            j++;
            if ((2 * i + 1) * (n - 1) - j < s.Length)
            {
                endStr += s[(2 * i + 1) * (n - 1) - j];
                s = s.Remove((2 * i + 1) * (n - 1) - j, 1);
                j++;
            }
        }

        if (n > 2)
        {
            int numCycle = l / (2 * n - 2) + 1;
            n -= 2;
            int i = 1;
            string middle = "";

            int blank;
            while (s.Length > 0)
            {
                while(n>s.Length)
                {
                    s += "0";
                }
                string buf = s.Substring(0, n < s.Length?n:s.Length);
                if (i < 0)
                {
                    buf = Reverse(buf);
                }
                i *= -1;
                middle += buf;
                s = s.Remove(0, n < s.Length?n:s.Length);
            }

            for(int k=0;k<n;k++)
            {
                for(int m=0;m<numCycle*2;m++)
                {
                    if(k+m*n<middle.Length)
                    {
                        if(middle[k+m*n] != '0')
                        {
                            ret += middle[k+m*n];
                        }                        
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }


        return ret + endStr;
    }

    public static string Reverse(string str)

    {

        if (string.IsNullOrEmpty(str))

        {

            throw new ArgumentException("参数不合法");

        }

        char[] chars = str.ToCharArray();

        int begin = 0;

        int end = chars.Length - 1;

        char tempChar;

        while (begin < end)

        {

            tempChar = chars[begin];

            chars[begin] = chars[end];

            chars[end] = tempChar;

            begin++;

            end--;

        }

        string strResult = new string(chars);

        return strResult;

    }
}

