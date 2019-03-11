Variable
===

Variable is an element that stores any data. Examples of using the predefined Variables are shown below.

<pre><code>var v1 = new AnyVariable() { Value = 1 };            // 1
var v2 = new AnyVariable() { Value = "text" };       // "text"
var v3 = new AnyVariable() { Value = new Foo() };    // instance of Foo
var v4 = new NullVariable();                         // null
</code></pre>
You can create custom Variables by inheriting the `OutVariable`, `InVariable` or `InOutVariable` class. 
<pre><code>public class UserCountVariable : OutVariable
{
    private readonly DbContext _context;
    public UserCountVariable(DbContext context)
    {
        _context = context;
    }
    protected override object getValue()
    {
        return context.Users.Count;
    }
}
</code></pre>