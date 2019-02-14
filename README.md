WFLite
=====
WFLite is a lightweight workflow library.

<img src="https://github.com/aratomo-arazon/WFLite/blob/master/images/logo.png" width=192 />

- [Get WFLite T-shirt!](https://suzuri.jp/aratomo-arazon/1615875/t-shirt/s/white)

## Why workflow?

As the scale of the program grows larger, the overall flow of the program becomes more difficult to understand. Parallel processing and asynchronous processing also reduce readability.
The workflow can improve readability and reusability by separating the overall flow and processing details and by hiding concurrency and asynchronicity behind. 

## Description

WFLite can construct a workflow with just four elements. They are <i>Variable</i>, <i>Converter</i>, <i>Condition</i> and <i>Activity</i>.

### Variable

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

### Converter

Converter is an element for converting data and is used with Variable. Examples of using the predefined Converters are shown below.


<pre><code>var c1 = new CastConverter<<int>int</int>>();
var c2 = new DictionaryConverter()
{
    Dictionary = new Dictionary<</>object, object>()
    {
        { 1, "Jan" }, { 2, "Feb" }, { 3, "Mar" }
    },
    Default = "Unknown"
};

var v1 = new AnyVariable() { Value = "20", Converter = c1 };    // 20
var v2 = new AnyVariable() { Value = 2, Converter = c2 };       // "Feb"
</code></pre>

You can create custom Converters by inheriting the `Converter` class. 

<pre><code>public class MillisecondToSecondConverter : Converter
{
    protected override object convert(object value)
    {
        return Convert.ToDouble(value) / 1000.0;
    }
}
</code></pre>

### Condition

Condition is an element expressing any condition and returns a boolean value. Examples of using the predefined Conditions are shown below.

<pre><code>var v1 = new AnyVariable() { Value = true };
var v2 = new AnyVariable() { Value = 1 };
var v3 = new AnyVariable() { Value = 2 };

var c1 = new TrueCondition() { Value = v1 };       // true -> true
var c2 = new FalseCondition() { Value = v1 };      // true -> false
var c3 = new EqualsCondition()                     // 1 == 2 -> false
{
    Value1 = v2,
    Value2 = v3
};
var c4 = new NullCondition() { Value = v2 };       // 1 is null -> false
var c5 = new NotCondition() { Condition = c2 };    // !false -> true
var c6 = new OrCondition()                         // true || false -> true
{
    Conditions = new List<</>ICondition>() { c1, c2 }
};
var c7 = new AndCondition()                        // true && false -> false
{
    Conditions = new List<</>ICondition>() { c1, c2 }
};
</code></pre>
You can create custom Conditions by inheriting the `Condition` class.
<pre><code>public class MorningCondition : Condition
{
    protected override bool check()
    {
        var hour = DateTime.Now.Hour;
        return hour >= 6 && hour < 12;
    }
}
</code></pre>

### Activity

Activity is an element that represents program flow and behavior.
An example of assigning to a Variable is shown below.
<pre><code>var to = new AnyVariable() { Value = 0 };
var value = new AnyVariable() { Value = 10 };
var assign = new AssingActivity() { To = to, Value = value };
await assign.Start();    // to = value; -> to == 10
</code></pre>

Activities are divided into Single and Control Activities. You can create a workflow by combining these Activities.

#### Single Activity
Single Activity is the activity that actually performs the operation. Examples of using predefined activities are shown below.

<pre><code>var v1 = new AnyVariable() { Value = 0 };
var v2 = new AnyVariable() { Value = 10 };
var v3 = new AnyVariable() { Value = 1000 };

var a1 = new AssignActivity()                      // v1 = v2; -> v1 == 10
{
    To = v1,
    Value = v2
};
var a2 = new DelayActivity() { Duration = v3 };    // Task.Delay(1000);
var a3 = new NullActivity();                       // ; (do nothing)
</code></pre>


You can create custom synchronous Activities by inheriting the `SyncActivity` class.

<pre><code>public class FileCopyActivity : SyncActivity
{
    public IVariable SrcFilePath { private get; set; }
    public IVariable DstFilePath { private get; set; }
    protected sealed override bool run()
    {
        var srcFilePath = Convert.ToString(SrcFilePath.GetValue());
        var dstFilePath = Convert.ToString(DstFilePath.GetValue());
        File.Copy(srcFilePath, dstFilePath);
        return true;
    }
}
</code></pre>

You can create custom asynchronous Activities by inheriting the `AsyncActivity` class.
<pre><code>public class FileCopyActivity : AsyncActivity
{
    public IVariable SrcFilePath { private get; set; }
    public IVariable DstFilePath { private get; set; }
    protected sealed override async Task<</>bool> run(CancellationToken cancellationToken)
    {
        var srcFilePath = Convert.ToString(SrcFilePath.GetValue());
        var dstFilePath = Convert.ToString(DstFilePath.GetValue());
        var bytes = await File.ReadAllBytesAsync(srcFilePath, cancellationToken);
        await File.WriteAllBytesAsync(dstFilePath, bytes, cancellationToken);
        return true;
    }
}
</code></pre>

#### Control Activity
Control Activity expresses the control syntax by using the composite structure. The syntaxes of the predefined Control Activities are shown below.

`SequenceActivity` executes multiple Activities in turn.
<pre><code>new SequenceActivity()
{
    Activities = new List<</>IActivity>()    // Required
    {
        <</>Activity>,
        <</>Activity>,
        ...
    }
};
</code></pre>
`ParallelActivity` performs multiple Activities in parallel.
<pre><code>new ParallelActivity()
{
    Activities = new List<</>IActivity>()    // Required
    {
        <</>Activity>,
        <</>Activity>,
        ...
    }
};
</code></pre>
`IfActivity` implements if-then-else syntax.
<pre><code>new IfActivity()
{
    Condition = <</>Condition>,    // Required
    Then = <</>Activity>,
    Else = <</>Activity>
};
</code></pre>
`SwitchActivity` implements switch-case syntax.
<pre><code>new SwitchActivity()
{
    Value = <</>Variable>,                            // Required
    Cases = new Dictionary<</>object, IActivity>()    // Required
    {
        { <</>value>, <</>Activity> },
        { <</>value>, <</>Activity> }
        ... 
    },
    Default = <</>Activity>
};
</code></pre>
`WhileActivity` implements while-loop syntax.
<pre><code>new WhileActivity()
{
    Condition = <</>Condition>,    // Required
    Activity = <</>Activity>       // Required
};
</code></pre>
`ForEachActivity` implements foreach-loop syntax.
<pre><code>new ForEachActivity()
{
    Collection = <</>Variable>,    // Required (List or Dictionary)
    Key = <</>Variable>,           // Required (if Collection is Dictionary)
    Value = <</>Variable>,         // Required
    Activity = <</>Activity>       // Required
};
</code></pre>
`TryCatchActivity` implements try-catch-finally syntax.
<pre><code>new TryCatchActivity()
{
    Try = <</>Activity>,    // Required
    Catch = <</>Activity>,
    Finally = <</>Activity>
};
</code></pre>
`ThrowActivity` implements throw-exception syntax.
<pre><code>new ThrowActivity();
</code></pre>
`UsingActivity` implements using syntax.
<pre><code>new UsingActivity()
{
    Disposable = <</>Variable>,    // Must be DisposableVariable
    Activity = <</>Activity>
};
</code></pre>
`LockActivity` implements lock syntax.
<pre><code>new LockActivity()
{
    Lock = <</>Variable>,          // Must be LockVariable
    Activity = <</>Activity>
};
</code></pre>
`DelegateActivity` simply delegates processing to an Activity.
<pre><code>new DelegateActivity()
{
    Activity = <</>Activity>
};
</code></pre>

Inheriting `DelegateActivity` allows you to group Activities as a reusable unit.
<pre><code>public class FileReadAndDeleteActivity  : DelegateActivity
{
    public FileReadAndDeleteActivity(IVariable filePath, IVariale content)
    {
        Activity = new IfActivity()
        {
            Condition = new FileExistsCondition(filePath),
            Then = new SequenceActivity()
            {
                Activities = new List<</>IActivity>()
                {
                    new FileReadActivity(filePath, content),
                    new FileDeleteActivity(filePath)
                }
            }
        }
    }
}
</code></pre>

## Examples

- [HelloWorld](https://github.com/aratomo-arazon/WFLite/tree/master/examples/WFLite.HelloWorld)
- [Greeting](https://github.com/aratomo-arazon/WFLite/tree/master/examples/WFLite.Greeting)
- [Stopwatch](https://github.com/aratomo-arazon/WFLite/tree/master/examples/WFLite.Stopwatch)

## License

[MIT](https://github.com/aratomo-arazon/WFLite/blob/master/LICENSE)

## Author

[aratomo-arazon](https://github.com/aratomo-arazon)