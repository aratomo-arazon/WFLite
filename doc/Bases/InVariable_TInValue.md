# InVariable&lt;TInValue&gt; Class

InVariable&lt;TInValue&gt; class is a base class of input variable classes.

<pre><code>public abstract class InVariable&lt;TInValue&gt; : IInVariable&lt;TInValue&gt;
</code></pre>

## Constructors

### public InVariable()
Initializes a new instance of the InVariable&lt;TValue&gt; class.

## Methods

### public void SetValue(object value)
Sets the value.
### public void SetValue&lt;TValue&gt;(TValue value)
Sets the value.
### public void SetValue(TInValue value)
Sets the value.

### protected abstract void setValue(object value)
Sets the value.