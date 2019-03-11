Activity
===

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
    Enumerable = <</>Variable>,    // Required (IEnumerable)
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
