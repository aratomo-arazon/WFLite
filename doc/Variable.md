# Variable

## Description

Variable is an element that stores any data. Examples of using the predefined variables are shown below.

<pre><code>var v1 = new AnyVariable() { Value = 1 };            // 1
var v2 = new AnyVariable() { Value = "text" };       // "text"
var v3 = new AnyVariable() { Value = new Foo() };    // instance of Foo
var v4 = new NullVariable();                         // null
</code></pre>
You can create custom variables by inheriting the [`OutVariable`](), [`InVariable`]() or [`InOutVariable`]() class. 
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

## References

Interfaces

* [IOutVariable](https://github.com/aratomo-arazon/WFLite/tree/master/doc/)
* [IOutVariable&lt;TValue&gt;](https://github.com/aratomo-arazon/WFLite/tree/master/doc/)
* [IInVariable](https://github.com/aratomo-arazon/WFLite/tree/master/doc/)
* [IInVariable&lt;TValue&gt;](https://github.com/aratomo-arazon/WFLite/tree/master/doc/)

Base classes

* [OutVariable](https://github.com/aratomo-arazon/WFLite/tree/master/doc/)
* [OutVariable&lt;TValue&gt;](https://github.com/aratomo-arazon/WFLite/tree/master/doc/)
* [InVariable](https://github.com/aratomo-arazon/WFLite/tree/master/doc/)
* [InVariable&lt;TValue&gt;](https://github.com/aratomo-arazon/WFLite/tree/master/doc/)
* [InOutVariable](https://github.com/aratomo-arazon/WFLite/tree/master/doc/)
* [InOutVariable&lt;TValue&gt;](https://github.com/aratomo-arazon/WFLite/tree/master/doc/)
* [InOutVariable&lt;TOutValue,TInValue&gt;](https://github.com/aratomo-arazon/WFLite/tree/master/doc/)

Predefined classes

* [AnyVariable](https://github.com/aratomo-arazon/WFLite/tree/master/doc/)
* [AnyVariable&lt;TValue&gt;](https://github.com/aratomo-arazon/WFLite/tree/master/doc/)
* [ConditionVariable](https://github.com/aratomo-arazon/WFLite/tree/master/doc/)
* [CountVariable](https://github.com/aratomo-arazon/WFLite/tree/master/doc/)
* [DisposableVariable](https://github.com/aratomo-arazon/WFLite/tree/master/doc/)
* [FuncVariable](https://github.com/aratomo-arazon/WFLite/tree/master/doc/)
* [LockVariable](https://github.com/aratomo-arazon/WFLite/tree/master/doc/)
* [NullVariable](https://github.com/aratomo-arazon/WFLite/tree/master/doc/)
* Diagnostics/[ProcessStartInfoVariable](https://github.com/aratomo-arazon/WFLite/tree/master/doc/)
* IO/[PathCombineVariable](https://github.com/aratomo-arazon/WFLite/tree/master/doc/)