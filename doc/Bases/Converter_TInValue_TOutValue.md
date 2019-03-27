# Converter&lt;TInValue,TOutValue&gt; Class

Converter&lt;TInValue,TOutValue&gt; class is a base class of converter classes.

<pre><code>public abstract class Converter&lt;TInValue,TOutValue&gt; : IConverter&lt;TInValue,TOutValue&gt;
</code></pre>

## Constructors

### public Converter()

Initializes a new isntance of the Converter class.

## Methods

### public object ConvertToObject(object value)

Converts the value.

### public TOutValue Convert(object value)

Converts the value.

### public TOutValue Convert(TInValue value)

Converts the value.

### protected abstract TOutValue convert(TInValue value)

Converts the value.