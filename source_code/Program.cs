using System.Net;
using System.Reflection;
using HtmlAgilityPack;
static HtmlDocument GetDocument(string url)
{
    HtmlWeb web = new HtmlWeb();
    HtmlDocument doc = web.Load(url);
    return doc;
}
static bool search(string input, Dictionary<string, string> symbols, int iter)
{
    if (symbols.ContainsKey(input.Substring(iter, 1)))
    {
        if (!(iter + 1 < input.Length - 1))
        {
            return true;
        }
        bool res = search(input, symbols, iter + 1);
        if (res == true)
        {
            return true;
        }
        else
        {
            if (symbols.ContainsKey(input.Substring(iter, 2)))
            {
                if (!(iter + 2 < input.Length - 1))
                {
                    return true;
                }
                res = search(input, symbols, iter + 2);
                if (res == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
    else if (symbols.ContainsKey(input.Substring(iter, 2)))
    {
        if (!(iter + 2 < input.Length - 1))
        {
            return true;
        }
        bool res = search(input, symbols, iter + 2);
        if (res == true)
        {
            return true;
        }
        else
        {
            if (symbols.ContainsKey(input.Substring(iter, 1)))
            {
                if (iter + 2 == input.Length - 1)
                {
                    return true;
                }
                res = search(input, symbols, iter + 1);
                if (res == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
    else
    {
        return false;
    }
}
string t = Environment.CurrentDirectory;
string readingPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"symbols.txt");
string[] _symbols = File.ReadAllLines(readingPath);
HtmlDocument doc = GetDocument("https://www.usna.edu/Users/cs/roche/courses/s15si335/proj1/files.php%3Ff=names.txt.html");
HtmlNodeCollection linkNodes = doc.DocumentNode.SelectNodes("//td[not(contains(@class, 'ln'))]");
Dictionary<string, string> symbols = new Dictionary<string, string>();
string _input = linkNodes[0].InnerText;
string[] input = _input.Split(new char[] { ' ', '>', '\n'});
for (int i = 0; i < input.Length; i++)
{
    input[i] = input[i].ToUpper();
}
for(int i = 0; i < _symbols.Length; i++)
{
    _symbols[i] = _symbols[i].ToUpper();
    symbols.Add(_symbols[i], _symbols[i]);
}
List<string> results = new List<string>();
for(int i = 0; i < input.Length; i++)
{
    string name = input[i];
    int iter = 0;
    bool res = search(name, symbols, iter);
    if (res)
    {
        results.Add(name);
    }
}
string writingPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"names.txt");
using (FileStream fs = File.Open(writingPath, FileMode.OpenOrCreate, FileAccess.ReadWrite)) { lock (fs) { fs.SetLength(0); } }
using (StreamWriter writer = new StreamWriter(writingPath, true))
{
    writer.WriteLine("Celkem " + results.Count + " jmen.");
    for (int i = 0; i < results.Count; i++)
    {
        writer.WriteLine(results[i]);
    }
    writer.Close();
}
System.Diagnostics.Process.Start("notepad.exe", writingPath);
