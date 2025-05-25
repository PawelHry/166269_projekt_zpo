namespace zpo_projekt;

public class BłądBazyDanychWyjątek : Exception
{
    public BłądBazyDanychWyjątek(string msg, Exception? inner = null)
        : base(msg, inner) { }
}

public class EncjaNieZnalezionoWyjątek : Exception
{
    public EncjaNieZnalezionoWyjątek(string msg) : base(msg) { }
}
